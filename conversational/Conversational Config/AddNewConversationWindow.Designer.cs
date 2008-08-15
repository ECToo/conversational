﻿namespace Conversational_Config
{
    partial class AddNewConversationWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.newConversationSayTextBox = new System.Windows.Forms.TextBox();
            this.addNewConversationCancelButton = new System.Windows.Forms.Button();
            this.addNewConversationSaveButton = new System.Windows.Forms.Button();
            this.criButton = new System.Windows.Forms.Button();
            this.criTotalLabel = new System.Windows.Forms.Label();
            this.criTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newConversationSayTextBox
            // 
            this.newConversationSayTextBox.Location = new System.Drawing.Point(0, 0);
            this.newConversationSayTextBox.Multiline = true;
            this.newConversationSayTextBox.Name = "newConversationSayTextBox";
            this.newConversationSayTextBox.Size = new System.Drawing.Size(633, 182);
            this.newConversationSayTextBox.TabIndex = 0;
            // 
            // addNewConversationCancelButton
            // 
            this.addNewConversationCancelButton.Location = new System.Drawing.Point(545, 189);
            this.addNewConversationCancelButton.Name = "addNewConversationCancelButton";
            this.addNewConversationCancelButton.Size = new System.Drawing.Size(75, 23);
            this.addNewConversationCancelButton.TabIndex = 1;
            this.addNewConversationCancelButton.Text = "&Cancel";
            this.addNewConversationCancelButton.UseVisualStyleBackColor = true;
            this.addNewConversationCancelButton.Click += new System.EventHandler(this.addNewConversationCancelButton_Click);
            // 
            // addNewConversationSaveButton
            // 
            this.addNewConversationSaveButton.Location = new System.Drawing.Point(464, 189);
            this.addNewConversationSaveButton.Name = "addNewConversationSaveButton";
            this.addNewConversationSaveButton.Size = new System.Drawing.Size(75, 23);
            this.addNewConversationSaveButton.TabIndex = 2;
            this.addNewConversationSaveButton.Text = "&Save";
            this.addNewConversationSaveButton.UseVisualStyleBackColor = true;
            this.addNewConversationSaveButton.Click += new System.EventHandler(this.addNewConversationSaveButton_Click);
            // 
            // criButton
            // 
            this.criButton.Location = new System.Drawing.Point(13, 188);
            this.criButton.Name = "criButton";
            this.criButton.Size = new System.Drawing.Size(215, 23);
            this.criButton.TabIndex = 3;
            this.criButton.Text = "Conversational Response Items";
            this.criButton.UseVisualStyleBackColor = true;
            this.criButton.Click += new System.EventHandler(this.criButton_Click);
            // 
            // criTotalLabel
            // 
            this.criTotalLabel.AutoSize = true;
            this.criTotalLabel.Location = new System.Drawing.Point(234, 192);
            this.criTotalLabel.Name = "criTotalLabel";
            this.criTotalLabel.Size = new System.Drawing.Size(44, 17);
            this.criTotalLabel.TabIndex = 4;
            this.criTotalLabel.Text = "Total:";
            // 
            // criTotal
            // 
            this.criTotal.AutoSize = true;
            this.criTotal.Location = new System.Drawing.Point(275, 192);
            this.criTotal.Name = "criTotal";
            this.criTotal.Size = new System.Drawing.Size(16, 17);
            this.criTotal.TabIndex = 5;
            this.criTotal.Text = "0";
            // 
            // AddNewConversationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 224);
            this.Controls.Add(this.criTotal);
            this.Controls.Add(this.criTotalLabel);
            this.Controls.Add(this.criButton);
            this.Controls.Add(this.addNewConversationSaveButton);
            this.Controls.Add(this.addNewConversationCancelButton);
            this.Controls.Add(this.newConversationSayTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddNewConversationWindow";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Conversation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddNewConversationWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newConversationSayTextBox;
        private System.Windows.Forms.Button addNewConversationCancelButton;
        private System.Windows.Forms.Button addNewConversationSaveButton;
        private System.Windows.Forms.Button criButton;
        private System.Windows.Forms.Label criTotalLabel;
        private System.Windows.Forms.Label criTotal;
    }
}