using AscendedRPG;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Skill_Files
{
    [ProtoContract]
    public class ArmorSkill
    {
        [ProtoMember(1)]
        public int Slot { get; set; }
        [ProtoMember(2, AsReference = true)]
        public Skill Skill { get; set; }
        public ArmorSkill() { }

        public override string ToString()
        {
            return Skill.ToString();
        }
    }
}
