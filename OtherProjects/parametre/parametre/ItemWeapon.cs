using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace parametre
{
    public enum Rarity
    {

        Common, Uncommon, Rare, Epic, Legendary

    }
    [Serializable]
    public class ItemWeapon
    {

        public int ID;
        public string Name;
        public int Durability;
        public int Value;
        public int MinDamage;
        public int MaxDamage;
        public int CriticalDamage;
        public Rarity rarity;

    }
}


