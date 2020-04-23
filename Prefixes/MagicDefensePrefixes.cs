using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.Prefixes
{
    public class MagicDefensePrefixes : ModPrefix
    {
        private readonly byte id;
        public MagicDefensePrefixes() { }
        public MagicDefensePrefixes(byte id) => this.id = id;
        public override PrefixCategory Category => PrefixCategory.Accessory;
        public override float RollChance(Item item) => 1f;
        public override bool CanRoll(Item item) => true;

        public override bool Autoload(ref string name)
        {
            if(base.Autoload(ref name))
            {
                mod.AddPrefix("Magic", new MagicDefensePrefixes(1));
                mod.AddPrefix("Blessed", new MagicDefensePrefixes(2));
                mod.AddPrefix("Runic", new MagicDefensePrefixes(3));
                mod.AddPrefix("Witchs", new MagicDefensePrefixes(4));
            }
            return false;
        }

        public override void SetDefaults()
        {
            switch (id)
            {
                case 1:
                    DisplayName.SetDefault("Magic");
                    break;
                case 2:
                    DisplayName.SetDefault("Blessed");
                    break;
                case 3:
                    DisplayName.SetDefault("Runic");
                    break;
                case 4:
                    DisplayName.SetDefault("Witch's");
                    break;
            }
        }

        public override void ModifyValue(ref float valueMult)
        {
            switch (id)
            {
                case 1:
                    valueMult += 0.1025f;
                    break;
                case 2:
                    valueMult += 0.21f;
                    break;
                case 3:
                    valueMult += 0.3225f;
                    break;
                case 4:
                    valueMult += 0.44f;
                    break;
            }
        }

        public override void Apply(Item item)
        {
            switch (id)
            {
                case 1:
                case 2:
                case 3:
                    item.rare -= 1;
                    break;
                case 4:
                    break;

            }
            base.Apply(item);
        }
    }
}
