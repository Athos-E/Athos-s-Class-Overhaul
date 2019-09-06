using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ChlorophyteHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Chlorophyte Hood");
            Tooltip.SetDefault("17% increased melee damage\n23% increased thrown damage\n10% increased melee speed\n32% increased melee critical strike chance\n10% increased move speed");
        }
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            globalItem.rogueItem = true;
            item.defense = 21;
            item.rare = 7;
            item.value = 60000;
            item.width = 18;
            item.height = 18;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.17f;
            player.thrownDamage += 0.23f;
            player.meleeSpeed += 0.15f;
            player.meleeCrit += 32;
            player.moveSpeed += 0.10f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.ChlorophytePlateMail && legs.type == ItemID.ChlorophyteGreaves;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.AddBuff(BuffID.LeafCrystal, 1, true);
            player.thrownVelocity += 0.19f;
            player.setBonus = "Summons a powerful leaf crystal to shoot at nearby enemies\n19% increased thrown velocity";
        }
    }
}
