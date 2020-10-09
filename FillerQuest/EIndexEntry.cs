using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG
{
    [ProtoContract]
    public class EIndexEntry
    {
        [ProtoMember(1)]
        public string Image { get; set; }
        [ProtoMember(2)]
        public int DType { get; set; }
        [ProtoMember(3)]
        public int Tier { get; set; }
        [ProtoMember(4)]
        public bool IsBoss { get; set; }
        [ProtoMember(5)]
        public string Name { get; set; }

        public EIndexEntry() { }

        public string GetDescString()
        {
            string[] dungeonTypes = { "Normal", "EX", "Ascended" };
            string tiers = (Name.Contains("Pot of")) ? $"Any {dungeonTypes[DType]} floor" : $"Tier {Tier}";
            string boss = (IsBoss) ? "Boss" : "Enemy";
            return $"Name: {Name}*Type: {boss}*Last seen: {tiers}*Found in {dungeonTypes[DType]} dungeons.";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
