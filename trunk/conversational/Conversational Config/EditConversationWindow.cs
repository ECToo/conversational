using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConversationalAPI;

namespace Conversational_Config
{
    public partial class EditConversationWindow : Form
    {
        private bool savedState;
        private string botName;
        private int conversationID;
        private ConversationalResponseItems cri;

        public EditConversationWindow(string bot_name, int id, string say, ConversationalResponseItems cri)
        {
            this.botName = bot_name;
            this.conversationID = id;
            this.cri = cri;

            this.Text = "Edit Conversation For '" + this.botName + "'";

            InitializeComponent();

            conversationSayTextBox.Text = say;
            criTotal.Text = cri.ResponseItems.Count.ToString();
        }

        private void AddNewConversationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!savedState)
            {
                if (MessageBox.Show("Are you sure you want to close this window?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void criButton_Click(object sender, EventArgs e)
        {
            criWindow criWin = new criWindow(botName, ref cri);
            criWin.ShowDialog();
            criWin.Dispose();

            criTotal.Text = cri.ResponseItems.Count.ToString();

        }

        private void addNewConversationSaveButton_Click(object sender, EventArgs e)
        {
            Conversational.Instance.UpdateConversation(botName, conversationID, conversationSayTextBox.Text, cri);

            savedState = true;

            this.Close();
        }

        private void addNewConversationCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
