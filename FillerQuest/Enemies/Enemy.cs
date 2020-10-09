using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG
{
    [ProtoContract]
    public class Enemy : ICloneable
    {
        //TESTING
        [ProtoMember(1)]
        public int Turns { get; set; }
        [ProtoMember(2)]
        public string Image { get; set; }
        [ProtoMember(3)]
        public string Name { get; set; }
        [ProtoMember(4)]
        public List<Skill> Skills { get; set; }
        [ProtoMember(5)]
        public HashSet<int> Weakness { get; set; }
        [ProtoMember(6)]
        public int HP { get; set; }

        public Enemy() {}

        public override string ToString() => $"{Name}";

        public object Clone() => new Enemy() { Image = Image, Name = Name, Skills = Skills, Weakness = Weakness, Turns = Turns, HP = HP };
    }
}
