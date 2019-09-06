using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class CobaltHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cobalt Hood");
            Tooltip.SetDefault("20% increased melee critical strike chance\n20% increased melee speed\n10% increased thrown velocity\n10% increased movespeed");
        }
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            globalItem.rogueItem = true;
            item.defense = 8;
            item.rare = 4;
            item.value = 15000;
            item.width = 18;
            item.height = 18;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 20;
            player.meleeSpeed += 0.20f;
            player.moveSpeed += 0.10f;
            player.thrownVelocity += 0.10f;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.meleeSpeed = 0.23f;
            player.thrownVelocity = 0.10f;
            player.setBonus = "23% increased melee speed\n10% increased thrown velocity";
        }
    }
}
