using System.Collections.Generic;

namespace AscendedRPG
{
    public class BattleMember
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Skill> Skills { get; set; }
        public Weapon Weapon { get; set; }

        public BattleMember() { }
    }
}
