using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class HallowedHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Hallowed Hood");
            Tooltip.SetDefault("12% increased melee damage\n25% increased thrown damage\n25% increased melee speed\n30% increased melee critical strike chance\n8% increased move speed");
        }
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            globalItem.rogueItem = true;
            item.defense = 18;
            globalItem.magicDefense = 21;
            item.rare = 5;
            item.value = 15000;
            item.width = 18;
            item.height = 18;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.12f;
            player.thrownDamage += 0.25f;
            player.meleeSpeed += 0.25f;
            player.meleeCrit += 28;
            player.moveSpeed += 0.8f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.meleeSpeed += 0.25f;
            player.moveSpeed += 0.23f;
            player.thrownVelocity += 0.25f;
            player.setBonus = "25% increased melee speed\n23% increased move speed\n25% increased thrown velocity";
        }
    }
}
