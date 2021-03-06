using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.API.Interfaces;

namespace Welcome.Handlers
{
    class Server
    {
        public void OnWatingForPlayers()
        {
            string wbc = Welcome.Instance.Config.WaitRoundMessage;
            Log.Warn(wbc);
        }
        public void OnRoundSterted()
        {
            string nrnd = Welcome.Instance.Config.OnRoundSterted;
            Log.Warn(nrnd);
        }
        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            string ernd = Welcome.Instance.Config.OnRoundEnded;
            Log.Warn(ernd);
        }
        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            string afg = ev.SpawnableTeam.ToString();
            if (afg == "Respawning.ChaosInsurgencySpawnHandler")
            {
                string amder = "ChaosInsurgency";
                string em = Welcome.Instance.Config.OnRespawningTeam.Replace("{team}", amder);
                Log.Warn(em);
            }
            else
            {
                string amder = "NTFCommand";
                string em = Welcome.Instance.Config.OnRespawningTeam.Replace("{team}", amder);
                Log.Warn(em);
            }
        }
        public void OnReloadedConfigs()
        {
            bool enbalews = Welcome.Instance.Config.Scp682OnEnable;
        }
    }
}
