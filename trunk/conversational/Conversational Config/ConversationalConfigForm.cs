﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using ConversationalAPI;

namespace Conversational_Config
{
    public partial class ConversationalConfigForm : Form
    {
        public ConversationalConfigForm()
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFile = new OpenFileDialog();

            loadFile.Filter = "Conversational Brains DB (*.db3)|*.db3";
            loadFile.FilterIndex = 1;

            DialogResult result = loadFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    Conversational.Initialize(new FileInfo(loadFile.FileName));
                }
                catch (ApplicationException)
                {
                    MessageBox.Show("This is not a conversational brains file.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadData();
            }
        }

        private void LoadData()
        {
            ReloadBotList();

            Text = Conversational.Instance.DatabaseFile;

            doInterfaceEnables(true);
        }

        private void quitConversationalConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to close these brains?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Conversational.Destroy();

                Text = "Conversational Config 1.0";

                doInterfaceEnables(false);
            }
        }

        private void doInterfaceEnables(bool loaded)
        {
            if (loaded)
            {
                loadToolStripMenuItem.Enabled = false;
                closeToolStripMenuItem.Enabled = true;
                cleanBrainToolStripMenuItem.Enabled = true;

                tabControl.Visible = true;
            }
            else
            {
                loadToolStripMenuItem.Enabled = true;
                closeToolStripMenuItem.Enabled = false;
                cleanBrainToolStripMenuItem.Enabled = false;

                tabControl.Visible = false;
            }
        }

        private void newBrainsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon.");
        }

        private void addBotToolStripTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripControlHost addNewBotTextBox = sender as ToolStripControlHost;

                string newName = Regex.Replace(addNewBotTextBox.Text, @"[\d+\W]+", "");

                if (newName.Length != 0)
                {
                    if (!Conversational.Instance.CreateNewBot(newName))
                    {
                        MessageBox.Show("This bot name is already in use, please try a variation...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ReloadBotList();
                        addNewBotTextBox.Text = string.Empty;
                        botsContextMenuStrip.Hide();
                    }
                }
            }
        }

        private void ReloadBotList()
        {
            List<string> bots = Conversational.Instance.ListAllBots();

            listBoxOfBots.Items.Clear();

            if (bots.Count != 0)
            {
                foreach (string bot in bots)
                {
                    listBoxOfBots.Items.Add(bot);
                }
            }            
        }

        private void listBoxOfBots_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int indexOver = listBoxOfBots.IndexFromPoint(e.X, e.Y);

                if (indexOver >= 0 && indexOver < listBoxOfBots.Items.Count)
                {
                    listBoxOfBots.SelectedIndex = indexOver;
                    botsContextMenuStrip.Items["deleteToolStripMenuItem"].Enabled = true;
                }
                else
                {
                    botsContextMenuStrip.Items["deleteToolStripMenuItem"].Enabled = false;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxOfBots.SelectedIndex >= 0 && listBoxOfBots.SelectedIndex < listBoxOfBots.Items.Count)
            {
                string botName = listBoxOfBots.Items[listBoxOfBots.SelectedIndex].ToString();

                if (MessageBox.Show("Are you sure you want to delete the '" + botName + "' bot?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Conversational.Instance.DeleteBot(botName);

                    conversationDataGrid.Visible = false;
                    
                    ReloadBotList();
                }
            }
        }

        private void listBoxOfBots_SelectedValueChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(listBoxOfBots.SelectedIndex.ToString());

            if (listBoxOfBots.SelectedIndex >= 0 && listBoxOfBots.SelectedIndex < listBoxOfBots.Items.Count)
            {
                LoadConversationalGrid();
            }
        }

        private void LoadConversationalGrid()
        {
            conversationDataGrid.Visible = false;

            Dictionary<int, string> conversations = Conversational.Instance.GetBotConversations(listBoxOfBots.Items[listBoxOfBots.SelectedIndex].ToString());

            conversationDataGrid.Rows.Clear();

            if (conversations.Count != 0)
            {
                foreach (int key in conversations.Keys)
                {
                    conversationDataGrid.Rows.Add(key, conversations[key]);
                }
            }

            conversationDataGrid.Visible = true;
        }

        private void testBotsConversationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by:\nFox Diller\n\nVersion 0.1\nMagrathean Technologies Internal Product\nFor Internal Use\n\nReleased Under GPL 2", "About Conversational Config", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewConversationWindow conversationWindow = new AddNewConversationWindow(listBoxOfBots.Items[listBoxOfBots.SelectedIndex].ToString());
            conversationWindow.ShowDialog();
            conversationWindow.Dispose();

            LoadConversationalGrid();
        }

        private void ConversationalConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit Conversational Config?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void conversationDataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = conversationDataGrid.HitTest(e.X, e.Y);

                if (hit.RowIndex != -1)
                {
                    conversationDataGrid.Rows[hit.RowIndex].Selected = true;

                    conversationContextMenuStrip.Items["editConversationResponseItemsToolStripMenuItem"].Enabled = true;
                    conversationContextMenuStrip.Items["deleteConversationToolStripMenuItem"].Enabled = true;
                }
                else
                {
                    if (conversationDataGrid.SelectedRows.Count != 0)
                    {
                        conversationDataGrid.SelectedRows[0].Selected = false;
                    }

                    conversationContextMenuStrip.Items["editConversationResponseItemsToolStripMenuItem"].Enabled = false;
                    conversationContextMenuStrip.Items["deleteConversationToolStripMenuItem"].Enabled = false;
                }
            }
        }

        private void editConversationResponseItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conversationDataGrid.SelectedRows.Count != 0)
            {
                string botName = listBoxOfBots.Items[listBoxOfBots.SelectedIndex].ToString();

                DataGridViewRow row = conversationDataGrid.SelectedRows[0];

                int conversationID = int.Parse(row.Cells[0].Value.ToString());
                string say = row.Cells[1].Value.ToString();

                LoadEditConversationWindow(botName, conversationID, say);              
            }
        }

        private void LoadEditConversationWindow(string botName, int conversationID, string say)
        {
            ConversationalResponseItems cri = Conversational.Instance.GetBotCRI(botName, conversationID);

            EditConversationWindow editWindow = new EditConversationWindow(botName, conversationID, say, cri);
            editWindow.ShowDialog();
            editWindow.Dispose();

            LoadConversationalGrid();
        }

        private void deleteConversationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string botname = listBoxOfBots.Items[listBoxOfBots.SelectedIndex].ToString();
            int id = int.Parse(conversationDataGrid.SelectedRows[0].Cells[0].Value.ToString());

            if (MessageBox.Show("Are you sure you want to delete this conversation from bot '" + botname + "'?\n\n" + conversationDataGrid.SelectedRows[0].Cells[1].Value.ToString(), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Conversational.Instance.DeleteConversation(botname, id);
                LoadConversationalGrid();
            }
        }

        private void conversationDataGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = conversationDataGrid.HitTest(e.X, e.Y);

            if (hit.RowIndex != -1)
            {
                conversationDataGrid.Rows[hit.RowIndex].Selected = true;

                string botName = listBoxOfBots.Items[listBoxOfBots.SelectedIndex].ToString();

                DataGridViewRow row = conversationDataGrid.Rows[hit.RowIndex];

                int conversationID = int.Parse(row.Cells[0].Value.ToString());
                string say = row.Cells[1].Value.ToString();

                LoadEditConversationWindow(botName, conversationID, say);
            }
        }

        private void tabPageTesting_Enter(object sender, EventArgs e)
        {
            testBotGroupBox.Visible = false;

            whichBotTestComboBox.Items.Clear();
            whichBotTestComboBox.SelectedIndex = -1;
            whichBotTestComboBox.Text = string.Empty;

            foreach (object obj in listBoxOfBots.Items)
            {
                string bot = (string)obj;

                whichBotTestComboBox.Items.Add(bot);
            }
        }

        private void whichBotTestComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            string selectedBot = (string)comboBox.SelectedItem;

            ConversationalItem ci = Conversational.Instance.GetBotFirstConversationItem(selectedBot);

            if (ci != null)
            {
                ChangeConversation(ci);
            }
            else
            {
                testBotGroupBox.Visible = false;

                MessageBox.Show("This bot has no conversations to test, please add some...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeConversation(ConversationalItem ci)
        {
            string selectedBot = ci.BotName;

            conversationSayTextBox.Text = ci.Say;

            conversationResponseListBox.Items.Clear();

            foreach (ConversationalResponseItem responseItem in ci.ConversationalResponseItems.ResponseItems)
            {
                conversationResponseListBox.Items.Add(responseItem);
            }


            testBotGroupBox.Text = "Testing '" + selectedBot + "'";

            testBotGroupBox.Visible = true;
        }

        private void conversationResponseListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string botName = (string)whichBotTestComboBox.SelectedItem;

            int selectedItem = conversationResponseListBox.IndexFromPoint(e.X, e.Y);

            ConversationalResponseItem cri = (ConversationalResponseItem)conversationResponseListBox.Items[selectedItem];

            if (cri.To != 0)
            {
                ConversationalItem ci = Conversational.Instance.GetBotConversationByID(botName, cri.To);

                if (ci != null)
                {
                    ChangeConversation(ci);
                }
                else
                {
                    testBotGroupBox.Visible = false;

                    MessageBox.Show("There is no conversation at ID: " + cri.To.ToString() + "\nPlease check your logic", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                testBotGroupBox.Visible = false;

                whichBotTestComboBox.SelectedIndex = -1;
                whichBotTestComboBox.Text = string.Empty;

                MessageBox.Show("You have completed your conversation with " + botName, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
