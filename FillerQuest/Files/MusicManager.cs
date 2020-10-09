using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AxWMPLib;

namespace AscendedRPG.Files
{
    public class MusicManager
    {
        private readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "music");

        private string floorSong, bossSong, idleSong, invaderSong, exBossSong, bountySong, elderBossSong, finalBossSong;

        private WMPLib.WindowsMediaPlayer wplayer;

        private bool isPlaying;

        public MusicManager()
        {
            wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.settings.setMode("loop", true);
            wplayer.settings.volume = 20;
        }

        public void SetIdleTheme(int tier)
        {
            string idlePath = Path.Combine(path, "didle");
            var files = Directory.GetFiles(Path.Combine(idlePath), "*.mp3");
            idleSong = files[(tier - 1) % files.Length];
        }

        public void SetFloorSong(int tier)
        {
            string floorPath = Path.Combine(path, "dmusic");
            var files = Directory.GetFiles(Path.Combine(floorPath), "*.mp3");
            floorSong = files[(tier - 1) % files.Length];
        }

        public void SetBossSong(int tier)
        {
            string bossPath = Path.Combine(path, "dboss");
            var files = Directory.GetFiles(Path.Combine(bossPath), "*.mp3");
            bossSong = files[(tier - 1) % files.Length];
        }

        public void SetInvaderSong(int tier)
        {
            string invaderPath = Path.Combine(path, "dinvader");
            var files = Directory.GetFiles(Path.Combine(invaderPath), "*.mp3");
            invaderSong = files[(tier - 1) % files.Length];
        }

        public void SetBountySong(int tier)
        {
            string bountyPath = Path.Combine(path, "dbounty");
            var files = Directory.GetFiles(Path.Combine(bountyPath), "*.mp3");
            bountySong = files[(tier - 1) % files.Length];
        }

        public void SetFinalBossSong()
        {
            string finalBoss = Path.Combine(path, "dfinalBoss");
            var files = Directory.GetFiles(Path.Combine(finalBoss), "*.mp3");
            finalBossSong = files[0];
        }

        public void SetEXSong()
        {
            string exPath = Path.Combine(path, "dexboss");
            var files = Directory.GetFiles(Path.Combine(exPath), "*.mp3");
            exBossSong = files[0];
        }

        public void SetElderSong(int tier)
        {
            string elderPath = Path.Combine(path, "delderboss");
            var files = Directory.GetFiles(Path.Combine(elderPath), "*.mp3");
            elderBossSong = files[(tier - 1) % files.Length];
        }

        public void PlayIdleSong()
        {
            PlaySong(idleSong);
        }

        public void PlayFloorSong()
        {
            PlaySong(floorSong);
        }

        public void PlayBossSong()
        {
            PlaySong(bossSong);
        }

        public void PlayInvaderSong()
        {
            PlaySong(invaderSong);
        }

        public void PlayElderSong()
        {
            PlaySong(elderBossSong);
        }

        public void PlayBountySong()
        {
            PlaySong(bountySong);
        }

        public void PlayEXSong()
        {
            PlaySong(exBossSong);
        }

        public void PlayFinalBossSong()
        {
            PlaySong(finalBossSong);
        }

        public void Stop()
        {
            isPlaying = false;
            wplayer.controls.stop();
        }

        private void PlaySong(string song)
        {
            isPlaying = true;
            wplayer.controls.stop();
            wplayer.URL = song;
            wplayer.controls.play();
        }

        public bool IsPlaying() => isPlaying;
            
    }
}
