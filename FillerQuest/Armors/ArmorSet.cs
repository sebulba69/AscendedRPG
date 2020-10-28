using AscendedRPG.Files;
using AscendedRPG.Armors;
using AscendedRPG.Skill_Files;
using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AscendedRPG
{
    [ProtoContract]
    public class ArmorSet
    {
        [ProtoMember(1)]
        public List<Armor> Armor { get; set; }

        [ProtoMember(2)]
        public List<ArmorSkill> Skills{ get; set; }

        [ProtoMember(4)]
        public int TotalDef { get; set; }

        public ArmorSet()
        {
            Skills = (Skills == null) ? new List<ArmorSkill>() : Skills;
            Armor = (Armor == null) ? new List<Armor>(ArmorPiece.TOTAL) : Armor;
        }

        public void CalculateTotalDef()
        {
            TotalDef = 0;
            Armor.ForEach(a => TotalDef += a.Defense);
        }

        public void AddArmor(Armor a)
        {
            Armor.Add(a);
            Skills.AddRange(a.Skills);
            TotalDef += a.Defense;
            Skills.Sort((a1,a2) => a1.Slot.CompareTo(a2.Slot));
            Armor.Sort((a1,a2) => a1.Piece.CompareTo(a2.Piece));
        }

        public void ExchangeArmor(ArmorInventory inv, Armor a)
        {
            // remove the skills that the old armor had
            var old = Armor[a.Piece];
            TotalDef -= old.Defense;
            Skills.RemoveAll(s => s.Slot == old.Piece);
            inv.RemoveArmor(a);
            inv.AddArmor(old);
            Armor.Remove(old);
            AddArmor(a);
        }
        
        public List<Skill> GetListOfSkillType(int type)
        {
            var skills = new List<Skill>();
            Skills.ForEach(s =>
            {
                if (s.Skill.S_Type == type) skills.Add(s.Skill);
            });
            return skills;
        }

    }
}