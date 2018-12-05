using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.Services;
using TwitchLib.Api.Services.Events;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;
using TwitchLib.Api.Services.Events.FollowerService;

namespace Twitch_Bot
{
    class Api
    {
        private LiveStreamMonitorService Monitor;
        private TwitchAPI api;
        TwitchLib.Api.Services.FollowerService followerService;
        List<String> channel = new List<string>();
        readonly DateTime time;

        private Form1 form;

        public Api(Form1 formIn)
        {
            form = formIn;
            time = DateTime.Now;

            channel.Add(Resources.channel_name); //hacky workaround for now

            Task.Run(() => ConfigLiveMonitorAsync());
        }

        private async Task ConfigLiveMonitorAsync()
        {
            api = new TwitchAPI();

            api.Settings.ClientId = Resources.client_id;
            api.Settings.AccessToken = Resources.bot_access_token;

            Monitor = new LiveStreamMonitorService(api, 60);

            List<string> lst = new List<string> { Resources.channel_name};
            Monitor.SetChannelsById(lst);

            Monitor.OnStreamOnline   += Monitor_OnStreamOnline;
            Monitor.OnStreamOffline  += Monitor_OnStreamOffline;
            Monitor.OnStreamUpdate   += Monitor_OnStreamUpdate;
            Monitor.OnServiceStarted += Monitor_OnServiceStarted;
            Monitor.OnChannelsSet    += Monitor_OnChannelsSet;

            followerService = new FollowerService(api);
            followerService.SetChannelsByName(channel);
            followerService.OnNewFollowersDetected += FollowerService_OnNewFollowersDetected;
            //followerService.OnServiceStopped += (o, e) => Console.WriteLine("Follower service started");
            //followerService.OnServiceStarted += (o, e) => Console.WriteLine($"Follower service started with interval: seconds.");
            followerService.OnServiceStopped += (o, e) => form.WriteChat("Follower service started", false);
            followerService.OnServiceStarted += (o, e) => form.WriteChat($"Follower service started with default interval", false);

            followerService.Start();


            Monitor.Start(); //Keep at the end!

            await Task.Delay(-1);
        }

        private void Monitor_OnChannelsSet(object sender, OnChannelsSetArgs e)
        {
            throw new NotImplementedException();
        }

        private void Monitor_OnServiceStarted(object sender, OnServiceStartedArgs e)
        {
            throw new NotImplementedException();
        }

        private void Monitor_OnStreamUpdate(object sender, OnStreamUpdateArgs e)
        {
            throw new NotImplementedException();
        }

        private void Monitor_OnStreamOffline(object sender, OnStreamOfflineArgs e)
        {
            throw new NotImplementedException();
        }

        private void Monitor_OnStreamOnline(object sender, OnStreamOnlineArgs e)
        {
            throw new NotImplementedException();
        }

        private void FollowerService_OnNewFollowersDetected(object sender, OnNewFollowersDetectedArgs e)
        {
            //string users = "";
            TwitchLib.Api.Helix.Models.Users.Follow follower = e.NewFollowers.Last();

            //form.WriteChat(follower.FromUserId);
            //form.AddEvent(follower.FromUserId);

            if(follower.FollowedAt < time)
            {
                //This is an old follow, drop out of the function
                return;
            }

            var username = api.V5.Users.GetUserByIDAsync(follower.FromUserId).GetAwaiter().GetResult();

            form.WriteChat(username.DisplayName + " just followed, thanks!", true);
            form.AddEvent("New follower " + username.DisplayName);
            //form.WriteChat(username + " just followed, thanks!");
            //form.AddEvent("New follower " + username);

            //foreach(var user in e.NewFollowers.Last())
            //{
            //    form.WriteChat(user.FromUserId);
            //    form.AddEvent(user.FromUserId);
            //}
            //form.AddEvent(String.Join(", ", e.NewFollowers));
            //form.WriteChat("Thank you for following " + e.NewFollowers.Select(X => X.FromUserId));
            //form.WriteChat("Thank you for following " + e.NewFollowers.);
        }
    }
}
