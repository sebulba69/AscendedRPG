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

        private string songPath;

        private WMPLib.WindowsMediaPlayer wplayer;

        private bool isPlaying;

        private readonly string[] imusic = { "didle", "didleEX", "didleASC" };
        private readonly string[] dmusic = { "dmusic", "dmusicEX", "dmusicASC" };

        public MusicManager()
        {
            wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.settings.setMode("loop", true);
            wplayer.settings.volume = 20;
        }

        public void SetIdleTheme(int tier, int type)
        {
            type %= 3;
            string idlePath = Path.Combine(path, imusic[type]);
            var files = Directory.GetFiles(Path.Combine(idlePath), "*.mp3");
            songPath = files[(tier - 1) % files.Length];
        }

        public void SetFloorSong(int tier, int type)
        {
            string floorPath = Path.Combine(path, dmusic[type]);
            var files = Directory.GetFiles(Path.Combine(floorPath), "*.mp3");
            songPath = files[(tier - 1) % files.Length];
        }

        public void SetBossSong(int tier)
        {
            string bossPath = Path.Combine(path, "dboss");
            var files = Directory.GetFiles(Path.Combine(bossPath), "*.mp3");
            songPath = files[(tier - 1) % files.Length];
        }

        public void SetInvaderSong(int tier)
        {
            string invaderPath = Path.Combine(path, "dinvader");
            var files = Directory.GetFiles(Path.Combine(invaderPath), "*.mp3");
            songPath = files[(tier - 1) % files.Length];
        }

        public void SetBountySong(int tier)
        {
            string bountyPath = Path.Combine(path, "dbounty");
            var files = Directory.GetFiles(Path.Combine(bountyPath), "*.mp3");
            songPath = files[(tier - 1) % files.Length];
        }

        public void SetFinalBossSong()
        {
            string finalBoss = Path.Combine(path, "dfinalBoss");
            var files = Directory.GetFiles(Path.Combine(finalBoss), "*.mp3");
            songPath = files[0];
        }

        public void SetEXSong(int tier)
        {
            string exPath = Path.Combine(path, "dexboss");
            var files = Directory.GetFiles(Path.Combine(exPath), "*.mp3");
            songPath = files[(tier - 1) % files.Length];
        }

        public void SetASCSong(int tier)
        {
            string asc = Path.Combine(path, "dascboss");
            var files = Directory.GetFiles(Path.Combine(asc), "*.mp3");
            songPath = files[(tier - 1) % files.Length];
        }

        public void SetElderSong(int tier)
        {
            string elderPath = Path.Combine(path, "delderboss");
            var files = Directory.GetFiles(Path.Combine(elderPath), "*.mp3");
            songPath = files[(tier - 1) % files.Length];
        }

        public void PlaySong()
        {
            isPlaying = true;
            wplayer.controls.stop();
            wplayer.URL = songPath;
            wplayer.controls.play();
        }

        public void Stop()
        {
            isPlaying = false;
            wplayer.controls.stop();
        }



        public bool IsPlaying() => isPlaying;
            
    }
}
