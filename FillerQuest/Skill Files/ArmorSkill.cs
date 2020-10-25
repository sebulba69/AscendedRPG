using ProtoBuf;

namespace AscendedRPG.Skill_Files
{
    [ProtoContract]
    public class ArmorSkill
    {
        [ProtoMember(1)]
        public int Slot { get; set; }
        [ProtoMember(2)]
        public Skill Skill { get; set; }
        public ArmorSkill() { }

        public override string ToString()
        {
            return Skill.ToString();
        }
    }
}
