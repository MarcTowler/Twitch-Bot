namespace Twitch_Bot
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.EventsBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Viewers = new System.Windows.Forms.Label();
            this.ViewersBox = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chat = new System.Windows.Forms.RichTextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1166, 43);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 647);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.EventsBox);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.Viewers);
            this.panel3.Controls.Add(this.ViewersBox);
            this.panel3.Location = new System.Drawing.Point(966, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 647);
            this.panel3.TabIndex = 2;
            // 
            // EventsBox
            // 
            this.EventsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EventsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.EventsBox.ForeColor = System.Drawing.SystemColors.Window;
            this.EventsBox.FormattingEnabled = true;
            this.EventsBox.Location = new System.Drawing.Point(3, 352);
            this.EventsBox.Name = "EventsBox";
            this.EventsBox.Size = new System.Drawing.Size(194, 238);
            this.EventsBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(32, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "Events";
            // 
            // Viewers
            // 
            this.Viewers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Viewers.AutoSize = true;
            this.Viewers.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
            this.Viewers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Viewers.Location = new System.Drawing.Point(23, 3);
            this.Viewers.Name = "Viewers";
            this.Viewers.Size = new System.Drawing.Size(155, 44);
            this.Viewers.TabIndex = 1;
            this.Viewers.Text = "Viewers";
            // 
            // ViewersBox
            // 
            this.ViewersBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewersBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.ViewersBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ViewersBox.FormattingEnabled = true;
            this.ViewersBox.Location = new System.Drawing.Point(3, 50);
            this.ViewersBox.Name = "ViewersBox";
            this.ViewersBox.Size = new System.Drawing.Size(194, 238);
            this.ViewersBox.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox1.Location = new System.Drawing.Point(206, 666);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(669, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // chat
            // 
            this.chat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chat.ForeColor = System.Drawing.SystemColors.Window;
            this.chat.Location = new System.Drawing.Point(206, 49);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(754, 605);
            this.chat.TabIndex = 4;
            this.chat.Text = "";
            this.chat.TextChanged += new System.EventHandler(this.chat_TextChanged);
            // 
            // Submit
            // 
            this.Submit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Submit.Location = new System.Drawing.Point(881, 666);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 5;
            this.Submit.Text = "Send";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1166, 690);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Viewers;
        private System.Windows.Forms.ListBox ViewersBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox chat;
        private System.Windows.Forms.ListBox EventsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Submit;
    }
}

