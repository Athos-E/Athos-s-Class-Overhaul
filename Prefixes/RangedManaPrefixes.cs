using Terraria.ModLoader;
using Terraria;
using System.Collections.Generic;

namespace ClassOverhaul.Prefixes
{
    public class RangedManaPrefixes : ModPrefix
    {
        private readonly byte id;
        public override PrefixCategory Category => PrefixCategory.Ranged;
        public RangedManaPrefixes() { }
        public RangedManaPrefixes(byte id) => this.id = id;

        public override bool Autoload(ref string name)
        {
            if(base.Autoload(ref name))
            {
                mod.AddPrefix("Bionic", new RangedManaPrefixes(1));
                mod.AddPrefix("Energized", new RangedManaPrefixes(2));
                mod.AddPrefix("Blurring", new RangedManaPrefixes(3));
                mod.AddPrefix("Enchanted", new RangedManaPrefixes(4));
                mod.AddPrefix("Otherworldly", new RangedManaPrefixes(5));
            }
            return false;
        }

        public override float RollChance(Item item)
            => 1f;

        public override bool CanRoll(Item item)
        {
            if (item.mana > 0) return true;
            return false;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            switch (id)
            {
                case 1:
                    damageMult += 0.1f;
                    manaMult -= 0.1f;
                    critBonus += 3;
                    break;
                case 2:
                    shootSpeedMult += 0.1f;
                    useTimeMult -= 0.2f;
                    manaMult -= 0.2f;
                    break;
                case 3:
                    shootSpeedMult += 0.15f;
                    manaMult += 0.1f;
                    useTimeMult -= 0.1f;
                    break;
                case 4:
                    damageMult += 0.1f;
                    shootSpeedMult += 0.1f;
                    useTimeMult -= 0.1f;
                    manaMult -= 0.1f;
                    critBonus += 2;
                    break;
                case 5:
                    damageMult += 0.15f;
                    knockbackMult += 0.1f;
                    shootSpeedMult += 0.15f;
                    useTimeMult -= 0.15f;
                    manaMult -= 0.1f;
                    critBonus += 5;
                    break;
            }
        }

        public override void ModifyValue(ref float valueMult)
        {
            switch (id)
            {
                case 1:
                    valueMult += 0.4350f;
                    break;
                case 2:
                    valueMult += 0.6002f;
                    break;
                case 3:
                    valueMult += 0.3225f;
                    break;
                case 4:
                    valueMult += 0.9283f;
                    break;
                case 5:
                    valueMult += 2.0985f;
                    break;
            }
        }

        public override void Apply(Item item)
        {
            switch (id)
            {
                case 1:
                case 3:
                    item.rare -= 1;
                    break;
                case 2:
                case 4:
                case 5:
                    break;
            }
        }
    }
}