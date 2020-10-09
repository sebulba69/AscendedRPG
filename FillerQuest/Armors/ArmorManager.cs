using AscendedRPG;
using AscendedRPG.GUIs;
using AscendedRPG.Skill_Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Files
{
    public class ArmorManager
    {
        private readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "armor.bin");

        private readonly string[] pieces = { "Head", "Torso", "Arms", "Waist", "Legs", "Charm" };

        private string[] armorNames;

        public ArmorManager()
        {
            armorNames = EncryptionManager.DeCrypt<string[]>(path);
        }

        public Armor GetRandomArmorPiece(FormState state, int tier, int piece)
        {
            Armor armor = new Armor();
            int i = state.Random.Next(0, armorNames.Length);
            armor.Name = $"{armorNames[i]} {pieces[piece]}";
            armor.Piece = piece;
            armor.Defense = state.Random.Next(tier * 10, (tier + 10) * 10);
            armor.Skills = new List<ArmorSkill>();
            armor.UpgradeLevel = 1;
            armor.UpXP = 0;
            var skills = state.SManager.GetRandomArmorSkills(tier, state.Random);
            skills.ForEach(s =>
            {
                var armorSkill = new ArmorSkill()
                {
                    Slot = piece,
                    Skill = s
                };
                armor.Skills.Add(armorSkill);
            });

            return armor;
        }
    }
}
