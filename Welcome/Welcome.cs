using Exiled.API.Enums;
using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using World = Exiled.Events.Handlers.Map;
using System;

namespace Welcome
{
    public class Welcome : Plugin<Config>
    {
        private static readonly Lazy<Welcome> LazyInstance = new Lazy<Welcome>(() => new Welcome());
        public static Welcome Instance => LazyInstance.Value;
        public override PluginPriority Priority { get; } = PluginPriority.Medium;
        private Handlers.Player player;
        private Handlers.Server server;
        private Handlers.World world;

        public override string Author { get; } = "NOTIF";

        public override string Name { get; } = "Welcome-Main";

        public override string Prefix { get; } = "Welcome";

        public override Version Version { get; } = new Version(1, 0, 1);

        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 1);
        private Welcome()
        {
        }
        public override void OnEnabled()
        {
            RegisterEvents();
            Log.Warn("plugins Welcome Was loaded");
            Log.Info("No error detected");
        }
        public override void OnDisabled()
        {
            UnRegisterEvents();
        }
        public void RegisterEvents()
        {
            player = new Handlers.Player();
            server = new Handlers.Server();
            world = new Handlers.World();

            Server.WaitingForPlayers += server.OnWatingForPlayers;
            Server.RoundStarted += server.OnRoundSterted;
            Server.RoundEnded += server.OnRoundEnded;
            Server.RespawningTeam += server.OnRespawningTeam;
            

            Player.Left += player.OnLeft;
            Player.Joined += player.OnJoin;
            Player.ChangingRole += player.OnChangingRole;
            Player.Banned += player.OnBanned;
            Player.Kicked += player.OnKicked;
            
            
        }

        public void UnRegisterEvents()
        {
            Server.WaitingForPlayers -= server.OnWatingForPlayers;
            Server.RoundStarted -= server.OnRoundSterted;
            Server.RoundEnded -= server.OnRoundEnded;
            Server.RespawningTeam -= server.OnRespawningTeam;

            Player.Left -= player.OnLeft;
            Player.Joined -= player.OnJoin;
            Player.ChangingRole -= player.OnChangingRole;
            Player.Banned -= player.OnBanned;
            Player.Kicked -= player.OnKicked;

            player = null;
            server = null;
        }
    }
}