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

            client.OnPubSubServiceConnected += onPubSubServiceConnected;
            client.OnListenResponse += onListenResponse;
            client.OnStreamUp += onStreamUp;
            client.OnStreamDown += onStreamDown;
            client.OnFollow += onFollow;
            client.OnBitsReceived += onBitsReceived;

            client.ListenToVideoPlayback("itslittany");

            client.Connect();
        }

        private void onBitsReceived(object sender, OnBitsReceivedArgs e)
        {
            throw new NotImplementedException();
        }

        private void onFollow(object sender, OnFollowArgs e)
        {
            form.AddEvent(e.DisplayName + " Followed");
            form.WriteChat("Thankyou " + e.DisplayName + " for following!");
        }

        private void onStreamDown(object sender, OnStreamDownArgs e)
        {
            form.WriteChat("Stream down, disconnecting...");
        }

        private void onStreamUp(object sender, OnStreamUpArgs e)
        {
            form.WriteChat("Connecting to stream now");
        }

        private void onListenResponse(object sender, OnListenResponseArgs e)
        {
            string successful = e.Successful ? "Successful" : "Unsuccessful";

            form.WriteChat($"{DateTime.Now.ToLocalTime()}: PubSub: {e.Topic}: {successful}");
        }

        private void onPubSubServiceConnected(object sender, EventArgs e)
        {
            client.SendTopics();
        }
    }
}
