using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;

namespace Twitch_Bot
{
    class Pubsub
    {
        private TwitchPubSub client;
        private Form1 form;

        public Pubsub(Form1 formIn)
        {
            form = formIn;
            client = new TwitchPubSub();

            client.OnPubSubServiceConnected += OnPubSubServiceConnected;
            client.OnListenResponse         += OnListenResponse;
            client.OnStreamUp               += OnStreamUp;
            client.OnStreamDown             += OnStreamDown;
            client.OnFollow                 += OnFollow;
            client.OnBitsReceived           += OnBitsReceived;

            client.ListenToVideoPlayback("itslittany");

            client.Connect();
        }

        private void OnBitsReceived(object sender, OnBitsReceivedArgs e)
        {
            form.WriteChat(e.Username + " just dropped " + e.TotalBitsUsed + " bits! Thank you itslitHype itslitHype itslitHype", true);
            form.AddEvent(e.Username + " " + e.TotalBitsUsed + " bits");
            //Twitch_Bot.Client.Send(Resources.channel_name, e.Username + " just dropped " + e.TotalBitsUsed + " bits! Thank you itslitHype itslitHype itslitHype");
        }

        private void OnFollow(object sender, OnFollowArgs e)
        {
            form.AddEvent(e.DisplayName + " Followed");
            form.WriteChat("Thankyou " + e.DisplayName + " for following!", true);
        }

        private void OnStreamDown(object sender, OnStreamDownArgs e)
        {
            form.WriteChat("Stream down, disconnecting...", false);
        }

        private void OnStreamUp(object sender, OnStreamUpArgs e)
        {
            form.WriteChat("Connecting to stream now", false);
        }

        private void OnListenResponse(object sender, OnListenResponseArgs e)
        {
            string successful = e.Successful ? "Successful" : "Unsuccessful";

            form.WriteChat($"{DateTime.Now.ToLocalTime()}: PubSub: {e.Topic}: {successful}", false);
        }

        private void OnPubSubServiceConnected(object sender, EventArgs e)
        {
            client.SendTopics();
        }
    }
}
