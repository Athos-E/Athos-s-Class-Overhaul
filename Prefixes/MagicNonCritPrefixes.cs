using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul.Prefixes
{
    public class MagicNonCritPrefixes : ModPrefix
    {
        private readonly byte id;
        public MagicNonCritPrefixes() { }
        public MagicNonCritPrefixes(byte id) => this.id = id;
        public override PrefixCategory Category => PrefixCategory.Magic;
        public override float RollChance(Item item) => 1f;
        public override bool CanRoll(Item item) => true;

        public override bool Autoload(ref string name)
        {
            if(base.Autoload(ref name))
            {
                mod.AddPrefix("COKeen", new MagicNonCritPrefixes(1));
                mod.AddPrefix("COSuperior", new MagicNonCritPrefixes(2));
                mod.AddPrefix("COGodly", new MagicNonCritPrefixes(3));
                mod.AddPrefix("CODemonic", new MagicNonCritPrefixes(4));
                mod.AddPrefix("COZealous", new MagicNonCritPrefixes(5));
                mod.AddPrefix("COAgile", new MagicNonCritPrefixes(6));
                mod.AddPrefix("COMurderous", new MagicNonCritPrefixes(7));
                mod.AddPrefix("CONasty", new MagicNonCritPrefixes(8));
                mod.AddPrefix("COMythical", new MagicNonCritPrefixes(9));
            }
            return false;
        }

        public override void SetDefaults()
        {
            switch (id)
            {
                case 1:
                    DisplayName.SetDefault("Keen");
                    break;
                case 2:
                    DisplayName.SetDefault("Superior");
                    break;
                case 3:
                    DisplayName.SetDefault("Godly");
                    break;
                case 4:
                    DisplayName.SetDefault("Demonic");
                    break;
                case 5:
                    DisplayName.SetDefault("Zealous");
                    break;
                case 6:
                    DisplayName.SetDefault("Agile");
                    break;
                case 7:
                    DisplayName.SetDefault("Murderous");
                    break;
                case 8:
                    DisplayName.SetDefault("Nasty");
                    break;
                case 9:
                    DisplayName.SetDefault("Mythical");
                    break;
            }
            base.SetDefaults();
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            switch (id)
            {
                case 1:
                    damageMult += 0.09f;
                    break;
                case 2:
                    damageMult += 0.19f;
                    knockbackMult += 0.1f;
                    break;
                case 3:
                    damageMult += 0.30f;
                    knockbackMult += 0.15f;
                    break;
                case 4:
                    damageMult += 0.30f;
                    break;
                case 5:
                    damageMult += 0.15f;
                    break;
                case 6:
                    damageMult += 0.09f;
                    useTimeMult -= 0.1f;
                    break;
                case 7:
                    damageMult += 0.16f;
                    useTimeMult -= 0.06f;
                    break;
                case 8:
                    damageMult += 0.11f;
                    useTimeMult -= 0.1f;
                    knockbackMult -= 0.1f;
                    break;
                case 9:
                    damageMult += 0.30f;
                    useTimeMult -= 0.1f;
                    manaMult -= 0.1f;
                    knockbackMult += 0.15f;
                    break;
            }
            base.SetStats(ref damageMult, ref knockbackMult, ref useTimeMult, ref scaleMult, ref shootSpeedMult, ref manaMult, ref critBonus);
        }

        public override void ModifyValue(ref float valueMult)
        {
            switch (id)
            {
                case 1:
                    valueMult += 0.1236f;
                    break;
                case 2:
                    valueMult += 0.6451f;
                    break;
                case 3:
                    valueMult += 1.1163f;
                    break;
                case 4:
                    valueMult += 0.6002f;
                    break;
                case 5:
                    valueMult += 0.21f;
                    break;
                case 6:
                    valueMult += 0.3596f;
                    break;
                case 7:
                    valueMult += 0.4454f;
                    break;
                case 8:
                    valueMult += 0.1687f;
                    break;
                case 9:
                    valueMult += 2.0985f;
                    break;
            }
            base.ModifyValue(ref valueMult);
        }

        public override void Apply(Item item)
        {
            switch (id)
            {
                case 1:
                case 5:
                case 6:
                case 8:
                    item.rare -= 1;
                    break;
                case 2:
                case 3:
                case 4:
                case 7:
                case 9:
                    break;
            }
            base.Apply(item);
        }
    }
}
