using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
