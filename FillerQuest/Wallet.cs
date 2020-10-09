using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG
{
    [ProtoContract]
    public class Wallet
    {
        [ProtoMember(6)]
        public long Coins { get; set; }

        [ProtoMember(8)]
        public List<int> Keys { get; set; }

        [ProtoMember(9)]
        public int MinionShards { get; set; }

        public Wallet()
        {
            if (Keys == null)
                Keys = new List<int>(7);
        }

        public void AddDellenCoin(long amount)
        {
            try { Coins = checked(Coins + amount); } catch (OverflowException) { Coins = long.MaxValue; }
        }
    }
}
