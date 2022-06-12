using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.CustomRoles.API.Features;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.Events.Handlers;
using PlayerStatsSystem;
using UnityEngine;
using System;

namespace Welcome.Handlers
{
    class Player
    {
        public void OnLeft(LeftEventArgs ev){
            string lmessage = Welcome.Instance.Config.LeftMessage.Replace("{player}", ev.Player.Nickname);
            Log.Warn(lmessage);        
        }
        public void OnJoin(JoinedEventArgs ev){
            string jmessage = Welcome.Instance.Config.JoinedMessage.Replace("{player}", ev.Player.DisplayNickname);
            Log.Warn(jmessage);
        }
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            string roles = ev.NewRole.ToString();
            string news = Welcome.Instance.Config.OnRespawningTeam.Replace("{team}", ev.NewRole.ToString());
            bool ifds = Welcome.Instance.Config.OnEscapeItem;
            Log.Info(news);
            if (ifds = true)
                if (roles == "NtfSpecialist")
                {
                    ev.Player.AddItem(ItemType.MicroHID);
                }
            else
            {
                Log.Info("[Settings] EscapeItem turn off");
            }
        }
        public void OnBanned(BannedEventArgs ev)
        {
            string plays = ev.Target.Nickname.ToString();
            string Obp = Welcome.Instance.Config.OnBanned.Replace("{player}", plays);
            Log.Warn(Obp);
        }
        public void OnKicked(KickedEventArgs ev)
        {
            string plays = ev.Target.Nickname;
            string reason = ev.Reason.ToString();
            string Okp = Welcome.Instance.Config.OnKicked.Replace("{player}", plays);
            Okp.Replace("{reason}", reason);
            Log.Warn(Okp);
        }
        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            string player = ev.Player.Role.Team.ToString();
            bool arg1 = Welcome.Instance.Config.OnMtfTrigersTesla;
            if (arg1 == true)
            {
                if (player == "MTF")
                {
                    ev.IsTriggerable = false;
                }

                else
                {
                    ev.IsTriggerable = true;
                }
            }
            else
            {
                Log.Info("[Setting] Tesla not trigers MTF units");
            }
        }
        public void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            string prole = ev.Player.Role.ToString();
            bool enbalews = Welcome.Instance.Config.Scp682OnEnable;
            if (ev.Door.IsBroken)
            {
                ev.Player.SendConsoleMessage("Door not heal as broken sorry", "red");
            }
            else
            {
                if (enbalews = true)
                {
                    if (prole == "Scp93953")
                    {
                        string mes = Welcome.Instance.Config.OnDestroyDoor;
                        ev.Door.BreakDoor();
                        ev.Player.SendConsoleMessage(mes, "red");
                        int amount = Welcome.Instance.Config.AmountDoorHeal;
                        ev.Player.Heal(amount, true);
                    }
                    if (prole == "Scp93989")
                    {
                        string mes = Welcome.Instance.Config.OnDestroyDoor;
                        ev.Door.BreakDoor();
                        ev.Player.SendConsoleMessage(mes, "red");
                        ev.Player.Heal(100, true);
                    }
                }
                else
                {
                    Log.Info("[Settings] Scp682 disabled sorry");
                }
            }
        }
    }
}
