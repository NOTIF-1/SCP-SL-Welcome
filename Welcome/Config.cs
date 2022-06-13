using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Welcome
{
    public class Config : IConfig{
        public bool IsEnabled { get; set; } = true;

        public string JoinedMessage { get; set; } = "Player has name is {player} joined the game";

        public string LeftMessage { get; set; } = "Player has name is {player} leaving game";

        public string WelcomeBroadCoast { get; set; } = "welcome <color=\"red\">INEFFABLE PROJECT </color>";
        
        public string WaitRoundMessage { get; set; } = "pls wait connect any players";
    
        public string WeebHookUrl { get; set; } = "Is Null pls write webhook url here";

        public string OnRoundSterted { get; set; } = "New Round Started";

        public string OnRoundEnded { get; set; } = "Round is End";

        public string OnRespawningTeam { get; set; } = "New Team respawning {team}";

        public string OnChangingRole { get; set; } = "{player} has changed role";

        public string OnBanned { get; set; } = "{player} has been banned from this server";

        public string OnKicked { get; set; } = "{player} has been kicked from this server on {reason}";
    
        public bool OnMtfTrigersTesla { get; set; } = true;

        public bool OnEscapeItem { get; set; } = true;

        public bool Scp682OnEnable { get; set; } = false;

        public int AmountDoorHeal { get; set; } = 100;

        public string OnDestroyDoor { get; set; } = "your eat near doors to the map";

    }
}
