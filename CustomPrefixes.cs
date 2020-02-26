using Terraria.ModLoader;
using Terraria;
using System.Collections.Generic;

namespace ClassOverhaul
{
    public class RangedManaPrefix : ModPrefix
    {
        private readonly byte id;
        internal static List<byte> RangedManaPrefixes = new List<byte>();
        public override PrefixCategory Category => PrefixCategory.AnyWeapon;
        public RangedManaPrefix() { }

        public RangedManaPrefix(byte id)
        {
            this.id = id;
        }

        public override bool Autoload(ref string name)
        {
            if(base.Autoload(ref name))
            {
                mod.AddPrefix("Bionic", new RangedManaPrefix(1));
                mod.AddPrefix("Energized", new RangedManaPrefix(2));
                mod.AddPrefix("Blurring", new RangedManaPrefix(3));
                mod.AddPrefix("Enchanted", new RangedManaPrefix(4));
                mod.AddPrefix("Otherworldly", new RangedManaPrefix(5));
            }
            return false;
        }

        public override float RollChance(Item item)
            => 1f;

        public override bool CanRoll(Item item)
        {
            if (item.magic == false && item.summon == false && item.ranged == true && item.mana > 0) return true;
            return false;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            switch (id)
            {
                case 1:
                    damageMult = 1.1f;
                    manaMult = 0.9f;
                    critBonus = 3;
                    break;
                case 2:
                    shootSpeedMult = 1.1f;
                    useTimeMult = 0.8f;
                    manaMult = 0.8f;
                    break;
                case 3:
                    damageMult = 1f;
                    shootSpeedMult = 1.15f;
                    manaMult = 1.1f;
                    useTimeMult = 0.9f;
                    break;
                case 4:
                    damageMult = 1.1f;
                    shootSpeedMult = 1.1f;
                    useTimeMult = 0.9f;
                    manaMult = 0.9f;
                    critBonus = 2;
                    break;
                case 5:
                    damageMult = 1.15f;
                    knockbackMult = 1.1f;
                    shootSpeedMult = 1.15f;
                    useTimeMult = 0.85f;
                    manaMult = 0.9f;
                    critBonus = 5;
                    break;
            }
        }

        public override void ModifyValue(ref float valueMult)
        {
            switch (id)
            {
                case 1:
                    valueMult = 1.14350f;
                    break;
                case 2:
                    valueMult = 1.16002f;
                    break;
                case 3:
                    valueMult = 1.13225f;
                    break;
                case 4:
                    valueMult = 1.19283f;
                    break;
                case 5:
                    valueMult = 1.20985f;
                    break;
            }
        }
    }
}