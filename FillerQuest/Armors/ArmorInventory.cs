using AscendedRPG;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Armors
{
    [ProtoContract]
    public class ArmorInventory
    {
        private const int CAP = 100;

        [ProtoMember(3, AsReference = true)]
        public List<Armor> Inventory { get; set; }

        public ArmorInventory()
        {
            if (Inventory == null)
                Inventory = new List<Armor>();
        }

        public void AddArmor(Armor a)
        {
            if (Inventory.Count < CAP)
            {
                Inventory.Add(a);
            }
        }

        public void RemoveArmor(Armor a) => Inventory.Remove(a);

        public void RemoveArmor(int pos) => Inventory.RemoveAt(pos);

        public bool CanAdd() => Inventory.Count < CAP;
    }
}
