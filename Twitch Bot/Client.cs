using System;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using System.Collections.Generic;

namespace Twitch_Bot
{
    class Client
    {
        private TwitchClient client;
        private Form1 form;
        private List<string> mods = new List<string>();
        private List<string> vips = new List<string>();

        public Client(Form1 formIn)
        {
            form = formIn;

            ConnectionCredentials credentials = new ConnectionCredentials(Resources.bot_name, Resources.bot_access_token);

            client = new TwitchClient();
            client.Initialize(credentials, Resources.channel_name);

            client.OnConnected          += OnConnected;
            client.OnJoinedChannel      += OnJoinedChannel;
            client.OnMessageReceived    += OnMessageReceived;
            client.OnWhisperReceived    += OnWhisperReceived;
            client.OnNewSubscriber      += OnNewSubscriber;
            client.OnGiftedSubscription += OnGiftedSubscription;
            client.OnReSubscriber       += OnReSubscriber;
            client.OnUserJoined         += OnUserJoined;
            client.OnUserLeft           += OnUserLeft;
            client.OnBeingHosted        += OnBeingHosted;
            client.OnRaidNotification   += OnRaidNotification;

            client.Connect();

        }

        #region "Subscriptions"
        private void OnReSubscriber(object sender, OnReSubscriberArgs e)
        {
            switch (e.ReSubscriber.SubscriptionPlan)
            {
                case SubscriptionPlan.Prime:
                    form.WriteChat(e.ReSubscriber.DisplayName + " just resubscribed with Twitch Prime for " + e.ReSubscriber.Months + " months!!! itslitHype itslitHype itslitHype");
                    client.SendMessage(e.Channel, e.ReSubscriber.DisplayName + " just resubscribed with Twitch Prime for " + e.ReSubscriber.Months + " months!!! itslitHype itslitHype itslitHype");
                    form.AddEvent("Twitch Prime resub " + e.ReSubscriber.DisplayName + "(" + e.ReSubscriber.Months + ")");

                    break;
                case SubscriptionPlan.Tier1:
                    form.WriteChat(e.ReSubscriber.DisplayName + " just resubscribed for " + e.ReSubscriber.Months + " months!!! itslitHype itslitHype itslitHype");
                    client.SendMessage(e.Channel, e.ReSubscriber.DisplayName + " just resubscribed for " + e.ReSubscriber.Months + " months!!! itslitHype itslitHype itslitHype");
                    form.AddEvent("Tier 1 resub " + e.ReSubscriber.DisplayName + "(" + e.ReSubscriber.Months + ")");

                    break;
                case SubscriptionPlan.Tier2:
                    form.WriteChat(e.ReSubscriber.DisplayName + " just resubscribed at Tier 2 for " + e.ReSubscriber.Months + " months!!! itslitHype itslitHype itslitHype");
                    client.SendMessage(e.Channel, e.ReSubscriber.DisplayName + " just resubscribed at Tier 2 for " + e.ReSubscriber.Months + " months!!! itslitHype itslitHype itslitHype");
                    form.AddEvent("Tier 2 resub " + e.ReSubscriber.DisplayName + "(" + e.ReSubscriber.Months + ")");

                    break;
                case SubscriptionPlan.Tier3:
                    form.WriteChat(e.ReSubscriber.DisplayName + " just resubscribed at Tier 3 for " + e.ReSubscriber.Months + " months!!! itslitHype itslitHype itslitHype");
                    client.SendMessage(e.Channel, e.ReSubscriber.DisplayName + " just resubscribed at Tier 3 for " + e.ReSubscriber.Months + " months!!! itslitHype itslitHype itslitHype");
                    form.AddEvent("Tier 3 resub " + e.ReSubscriber.DisplayName + "(" + e.ReSubscriber.Months + ")");

                    break;
            }
        }

        private void OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs e)
        {
            switch (e.GiftedSubscription.MsgParamSubPlan)
            {
                case SubscriptionPlan.Tier1:
                    form.WriteChat(e.GiftedSubscription.DisplayName + " just gifted a Tier 1 sub to " + e.GiftedSubscription.MsgParamRecipientDisplayName + " a sub!!! itslitHype itslitHype itslitHype");
                    client.SendMessage(e.Channel, e.GiftedSubscription.DisplayName + " just gifted a Tier 1 sub to " + e.GiftedSubscription.MsgParamRecipientDisplayName + " a sub!!! itslitHype itslitHype itslitHype");
                    form.AddEvent("Tier 1 gift from " + e.GiftedSubscription.DisplayName + " to " + e.GiftedSubscription.MsgParamRecipientDisplayName);

                    break;
                case SubscriptionPlan.Tier2:
                    form.WriteChat(e.GiftedSubscription.DisplayName + " just gifted a Tier 2 sub to " + e.GiftedSubscription.MsgParamRecipientDisplayName + " a sub!!! itslitHype itslitHype itslitHype");
                    client.SendMessage(e.Channel, e.GiftedSubscription.DisplayName + " just gifted a Tier 2 sub to " + e.GiftedSubscription.MsgParamRecipientDisplayName + " a sub!!! itslitHype itslitHype itslitHype");
                    form.AddEvent("Tier 2 gift from " + e.GiftedSubscription.DisplayName + " to " + e.GiftedSubscription.MsgParamRecipientDisplayName);

                    break;
                case SubscriptionPlan.Tier3:
                    form.WriteChat(e.GiftedSubscription.DisplayName + " just gifted a Tier 3 sub to " + e.GiftedSubscription.MsgParamRecipientDisplayName + " a sub!!! itslitHype itslitHype itslitHype");
                    client.SendMessage(e.Channel, e.GiftedSubscription.DisplayName + " just gifted a Tier 3 sub to " + e.GiftedSubscription.MsgParamRecipientDisplayName + " a sub!!! itslitHype itslitHype itslitHype");
                    form.AddEvent("Tier 3 gift from " + e.GiftedSubscription.DisplayName + " to " + e.GiftedSubscription.MsgParamRecipientDisplayName);

                    break;
            }
        }

        private void OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            switch(e.Subscriber.SubscriptionPlan)
            {
                case SubscriptionPlan.Prime:
                    form.WriteChat(e.Subscriber.DisplayName + " just subscribed with Twitch Prime!!! itslitHype itslitHype itslitHype");
                    client.SendMessage(e.Channel, e.Subscriber.DisplayName + " just subscribed with Twitch Prime!!! itslitHype itslitHype itslitHype");
                    form.AddEvent("New Twitch Prime Sub " + e.Subscriber.DisplayName);

                    break;
                case SubscriptionPlan.Tier1:
                    form.WriteChat(e.Subscriber.DisplayName + " just subscribed!!! itslitHype itslitHype itslitHype");
                    client.SendMessage(e.Channel, e.Subscriber.DisplayName + " just subscribed!!! itslitHype itslitHype itslitHype");
                    form.AddEvent("New Tier 1 Sub " + e.Subscriber.DisplayName);

                    break;
                case SubscriptionPlan.Tier2:
                    form.WriteChat(e.Subscriber.DisplayName + " just subscribed at Tier 2!!! itslitHype itslitHype itslitHype");
                    client.SendMessage(e.Channel, e.Subscriber.DisplayName + " just subscribed at Tier 2!!! itslitHype itslitHype itslitHype");
                    form.AddEvent("New Tier 2 Sub " + e.Subscriber.DisplayName);

                    break;
                case SubscriptionPlan.Tier3:
                    form.WriteChat(e.Subscriber.DisplayName + " just subscribed at Tier 3!!! itslitHype itslitHype itslitHype");
                    client.SendMessage(e.Channel, e.Subscriber.DisplayName + " just subscribed at Tier 3!!! itslitHype itslitHype itslitHype");
                    form.AddEvent("New Tier 3 Sub " + e.Subscriber.DisplayName);

                    break;
            }
        }
        #endregion

        private void OnRaidNotification(object sender, OnRaidNotificationArgs e)
        {
            form.WriteChat(e.RaidNotificaiton.DisplayName + " raided!!!!!!!!");
        }

        private void OnBeingHosted(object sender, OnBeingHostedArgs e)
        {
            form.WriteChat(e.BeingHostedNotification.Channel + " hosted with " + e.BeingHostedNotification.Viewers + " viewers");
            client.SendMessage(Resources.channel_name,e.BeingHostedNotification.HostedByChannel);
            form.AddEvent(e.BeingHostedNotification.Channel + " hosted (" + e.BeingHostedNotification.Viewers + ")");
            form.AddEvent(e.BeingHostedNotification.HostedByChannel + " hosted (" + e.BeingHostedNotification.Viewers + ")");
        }

        private void OnUserLeft(object sender, OnUserLeftArgs e)
        {
            form.UpdateViewerList(e.Username, false);
        }

        private void OnUserJoined(object sender, OnUserJoinedArgs e)
        {
            form.UpdateViewerList(e.Username, true);
        }

        private void OnConnected(object sender, OnConnectedArgs e)
        {
            form.WriteChat("Connected to " + e.AutoJoinChannel);
            client.SendMessage(e.AutoJoinChannel, "Connected to " + e.AutoJoinChannel);
        }

        private void OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            form.WriteChat("Hey guys! I am a bot connected via TwitchLib!");
            client.SendMessage(e.Channel, "Hey guys! I am a bot connected via TwitchLib!");
        }

        #region Messaging
        private void OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            /*foreach(var badge in e.ChatMessage.Badges)
            {
                Console.WriteLine(badge.Key + ": " + badge.Value);
            }
            var test = new TwitchLib.Api.V5.Models.Badges.Badge();
            foreach(var testing in test.Versions)
            {
                Console.WriteLine(testing.Key + ": " + testing.Value);
            }*/
            form.WriteChat(/*e.ChatMessage.Badges + */e.ChatMessage.Username + ": " + e.ChatMessage.Message);

            //Lets check for a command
            //if(e.ChatMessage.)

            if (e.ChatMessage.Message.Contains("badword"))
                client.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30), "Bad word! 30 minute timeout!");
        }

        private void OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            form.WriteChat(e.WhisperMessage.Username + " >>> " + e.WhisperMessage.Message);

            //check for a command else we will send a wtf message back
            if (e.WhisperMessage.Message.Contains("!"))
            {
                //its a command
                client.SendWhisper(e.WhisperMessage.Username, "Sorry commands via whisper is not yet supported");
                form.WriteChat(Resources.bot_name + " >>> " + e.WhisperMessage.Username + " Sorry commands via whisper is not yet supported");
            }
            else
            {
                client.SendWhisper(e.WhisperMessage.Username, "Thanks for the whisper, unfortunately it doesn't get read yet");
                form.WriteChat(Resources.bot_name + " >>> " + e.WhisperMessage.Username + " Thanks for the whisper, unfortunately it doesn't get read yet");
            }

        }

        //Just for external calls
        public void Send(String channel, String message)
        {
            client.SendMessage(channel, message);
        }
        #endregion


        /* public async Task GetUptimeAndSendToChannel(string channelName)
 {
     var foundChannelResponse = await api.Users.v5.GetUserByNameAsync(channelName);
     var foundChannel = foundChannelResponse.Matches.FirstOrDefault();

     if (foundChannel is null) return;

     var online = await api.Streams.v5.BroadcasterOnlineAsync(foundChannel.Id);
     if (!online)
     {
         client.SendMessage(channelName, $".me says {foundChannel.DisplayName} isn't streaming right now Ooops!");
         return;
     }

     var uptime = await api.Streams.v5.GetUptimeAsync(foundChannel.Id);

     if (!uptime.HasValue)
     {
         client.SendMessage(channelName, ".me says Error getting uptime :v");
         return;
     }

     client.SendMessage(channelName, $".me says {foundChannel.DisplayName} Live for {uptime.Value.Hours} {(uptime.Value.Hours == 1 ? "hour" : "hours")} {uptime.Value.Minutes} {(uptime.Value.Minutes == 1 ? "minute" : "minutes")}.");
 } */
    }
}
