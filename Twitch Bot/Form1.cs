using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitch_Bot
{
    public partial class Form1 : Form
    {
        
        private Client client;
        private Api api;
        private Pubsub pubsub;

        public Form1()
        {
            InitializeComponent();

            client = new Client(this);
            api = new Api(this);
            pubsub = new Pubsub(this);
        }

        delegate void SetTextCallback(string text);

        public void WriteChat(string text)
        {
            /*
             * Only works if we want a single write to the box
             
            if (this.chat.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(WriteChat);

                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.chat.Text = text;
            }*/
            if(InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate () { WriteChat(text); });
                return;
            }

            chat.Text = chat.Text + "\n" + text;
        }

        public void AddEvent(string text)
        {
            if(InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate () { AddEvent(text); });
                return;
            }

            EventsBox.Items.Add(text);
        }

        public void UpdateViewerList(string text, bool add)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate () { UpdateViewerList(text, add); });
                return;
            }

            if (add)
            {
                ViewersBox.Items.Add(text);
            } else
            {
                ViewersBox.Items.Remove(text);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                WriteChat(Resources.bot_name + ": " + textBox1.Text);
                client.Send(Resources.channel_name, textBox1.Text);

                //Stops the bing
                e.SuppressKeyPress = true;

                //Lets clear the input
                textBox1.Text = "";
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            //Lets check to see if we actually have text to send, if we do not then ignore
            if(textBox1.Text != "")
            {
                WriteChat(Resources.bot_name + ": " + textBox1.Text);
                client.Send(Resources.channel_name, textBox1.Text);

                //Lets clear the input
                textBox1.Text = "";
            }
        }
    }
}
