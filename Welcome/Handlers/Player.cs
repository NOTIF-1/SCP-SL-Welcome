using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.API.Extensions;
using Exiled.Events.Handlers;
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
            string role = ev.NewRole.ToString();
            string Ocr1 = Welcome.Instance.Config.OnChangingRole.Replace("{player}", ev.Player.Nickname);
            Log.Warn(Ocr1);
            Log.Warn(role);
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
    }
}