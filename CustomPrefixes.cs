using Terraria.ModLoader;
using Terraria;
using System.Collections.Generic;

namespace ClassOverhaul
{
    public class RangedManaPrefix : ModPrefix
    {
        internal static List<byte> RangedManaPrefixes = new List<byte>();
        internal int critBonus = 0;
        internal float damageMult = 1f;
        internal float knockbackMult = 1f;
        internal int tileBoost = 0;
        internal float useTimeMult = 1f;
        internal float manaMult = 1f;
        internal float shootSpeedMult = 1f;
        internal int rarity;

        public override PrefixCategory Category => PrefixCategory.AnyWeapon;

        public RangedManaPrefix() { }

        public RangedManaPrefix(float damageMult = 1f, float knockbackMult = 1f, float useTimeMult = 1f, int critBonus = 0, int tileBoost = 0, float manaMult = 1f, float shootSpeedMult = 1f)
        {
            this.damageMult = damageMult;
            this.knockbackMult = knockbackMult;
            this.useTimeMult = useTimeMult;
            this.critBonus = critBonus;
            this.tileBoost = tileBoost;
            this.manaMult = manaMult;
            this.shootSpeedMult = shootSpeedMult;
        }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                AddRangedManaPrefix(mod, RangedManaPrefixType.Bionic, 1.05f, 1f, 1f, 3, 0, 0.95f, 1f);
                AddRangedManaPrefix(mod, RangedManaPrefixType.Energized, 1f, 1f, 0.85f, 0, 0, 0.8f, 1.1f);
                AddRangedManaPrefix(mod, RangedManaPrefixType.Blurring, 1f, 1f, 0.9f, 0, 0, 1.05f, 1.15f);
                AddRangedManaPrefix(mod, RangedManaPrefixType.Enchanted, 1.1f, 1.05f, 0.95f, 2, 0, 0.95f, 1.05f);
                AddRangedManaPrefix(mod, RangedManaPrefixType.Otherworldly, 1.15f, 1.15f, 0.9f, 5, 0, 0.9f, 1.1f);
            }
            return false;
        }

        public override void Apply(Item item) => item.tileBoost += item.tileBoost == 0 && tileBoost < 0 ? -1 : tileBoost;

        public override void ModifyValue(ref float valueMult) => valueMult *= 1 + tileBoost * 0.04f;

        public override bool CanRoll(Item item) => item.ranged & (item.mana != 0);

        public override float RollChance(Item item) => item.noUseGraphic ? 1.15f : 3.3f;
        
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = this.damageMult;
            knockbackMult = this.knockbackMult;
            useTimeMult = this.useTimeMult;
            critBonus = this.critBonus; 
            manaMult = this.manaMult;
            shootSpeedMult = this.shootSpeedMult;
        }

        static void AddRangedManaPrefix(Mod mod, RangedManaPrefixType prefixType, float damageMult = 1f, float knockbackMult = 1f, float useTimeMult = 1f, int critBonus = 0, int tileBoost = 0, float manaMult = 1f, float shootSpeedMult = 1f)
        {
            mod.AddPrefix(prefixType.ToString(), new RangedManaPrefix(damageMult, knockbackMult, useTimeMult, critBonus, tileBoost, manaMult, shootSpeedMult));
            RangedManaPrefixes.Add(mod.GetPrefix(prefixType.ToString()).Type);
        }
    }

    public enum RangedManaPrefixType : byte
    {
        None,
        Bionic,
        Energized,
        Blurring,
        Enchanted,
        Otherworldly
    }
}