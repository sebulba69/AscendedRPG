using AscendedRPG.Files;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG
{
    public class SaveManager
    {
        private readonly string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "saves");

        public SaveManager() { }

        public bool DoesSaveFileExist(string name)
        {
            string path = Path.Combine(PATH, $"{name}.bin");
            return File.Exists(path);
        }

        public void SaveGame(Player p)
        {
            string path = Path.Combine(PATH, p.Name + ".bin");
            EncryptionManager.EncryptFile(path, p);
        }

        public Player LoadGame(string name)
        {
            string path = Path.Combine(PATH, $"{name}.bin");
            return EncryptionManager.DeCrypt<Player>(path);
        }

        public List<string> GetFileNames()
        {
            var files = Directory.GetFiles(PATH);
            var names = files.ToList();
            var result = new List<string>();
            foreach (string n in names) result.Add(Path.GetFileNameWithoutExtension(n));
            return result;
        }
    }
}
