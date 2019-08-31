using Terraria.ModLoader;
using System.Collections.Generic;
using System.Linq;
using Terraria;

namespace ClassOverhaul.Items
{
    public abstract class ChemicalItem : ModItem
    {
        public static bool chemical = true;
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.thrown = true;
            item.melee = false;
            item.magic = false;
            item.ranged = false;
            item.summon = false;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
            var tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                string[] split = tt.text.Split(' ');
                tt.text = split.First() + " thrown chemical " + split.Last();
            }
        }
        public override void GetWeaponDamage(Player player, ref int damage)
        {
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>(mod);
            int originalDamage = damage;
            float globalDamage = 1f;
            damage = (int)(damage * (((player.thrownDamage - 1f) / 2) + modPlayer.chemicalDamage));
            globalDamage = player.meleeDamage - 1;
            if (player.magicDamage - 1 < globalDamage)
                globalDamage = player.magicDamage - 1;
            if (player.rangedDamage - 1 < globalDamage)
                globalDamage = player.rangedDamage - 1;
            if (player.minionDamage - 1 < globalDamage)
                globalDamage = player.minionDamage - 1;
            if (player.thrownDamage - 1 < globalDamage)
                globalDamage = player.thrownDamage - 1;
            if (globalDamage > 1)
                damage = damage + (int)(originalDamage * globalDamage);
        }
    }
}