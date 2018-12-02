using System;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;

namespace Twitch_Bot
{
    class Client
    {
        private TwitchClient client;
        private Form1 form;

        public Client(Form1 formIn)
        {
            form = formIn;

            ConnectionCredentials credentials = new ConnectionCredentials(Resources.bot_name, Resources.bot_access_token);

            client = new TwitchClient();
            client.Initialize(credentials, "itslittany");

            client.OnConnected        += OnConnected;
            client.OnJoinedChannel    += OnJoinedChannel;
            client.OnMessageReceived  += OnMessageReceived;
            client.OnWhisperReceived  += OnWhisperReceived;
            client.OnNewSubscriber    += OnNewSubscriber;
            client.OnUserJoined       += OnUserJoined;
            client.OnUserLeft         += OnUserLeft;
            client.OnBeingHosted      += OnBeingHosted;
            client.OnRaidNotification += OnRaidNotification;

            client.Connect();
        }

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

        private void OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            form.WriteChat(e.ChatMessage.Username + ": " + e.ChatMessage.Message);

            //Lets check for a command
            //if(e.ChatMessage.)

            if (e.ChatMessage.Message.Contains("badword"))
                client.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30), "Bad word! 30 minute timeout!");
        }

        private void OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            if (e.WhisperMessage.Username == "thumpersfriend")
            {
                form.WriteChat(e.WhisperMessage.Username + " >>> " + e.WhisperMessage.Message);
                client.SendWhisper(e.WhisperMessage.Username, "Hey! Whispers are so cool!!");
            }


        }

        private void OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            if (e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime)
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points! So kind of you to use your Twitch Prime on this channel!");
            else
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points!");
        }

        //Just for external calls
        public void Send(String channel, String message)
        {
            client.SendMessage(channel, message);
        }

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
