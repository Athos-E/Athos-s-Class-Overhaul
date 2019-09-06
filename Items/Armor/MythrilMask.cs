using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class MythrilMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Mythril Mask");
            Tooltip.SetDefault("11% increased melee damage\n18% increased thrown damage\n13% increased melee speed\n32% increased melee critical strike chance\n8% increased move speed");
        }
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            globalItem.rogueItem = true;
            item.defense = 14;
            item.rare = 4;
            item.value = 22500;
            item.width = 18;
            item.height = 18;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.11f;
            player.thrownDamage += 0.18f;
            player.meleeSpeed += 0.13f;
            player.meleeCrit += 32;
            player.moveSpeed += 0.8f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.meleeCrit += 6;
            player.thrownVelocity += 0.12f;
            player.setBonus = "6% increased melee critical strike chance\n12% increased thrown velocity";
        }
    }
}
