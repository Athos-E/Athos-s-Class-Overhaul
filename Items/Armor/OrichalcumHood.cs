using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class OrichalcumHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Orichalcum Hood");
            Tooltip.SetDefault("8% increased melee damage\n20% increased thrown damage\n18% increased melee speed\n60% increased melee critical strike chance\n11% increased move speed");
        }
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            globalItem.rogueItem = true;
            item.defense = 14;
            globalItem.magicDefense = 16;
            item.rare = 4;
            item.value = 22500;
            item.width = 18;
            item.height = 18;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.08f;
            player.thrownDamage += 0.20f;
            player.meleeSpeed += 0.18f;
            player.meleeCrit += 60;
            player.moveSpeed += 0.11f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.OrichalcumBreastplate && legs.type == ItemID.OrichalcumLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.onHitPetal = true;
            player.thrownVelocity += 0.13f;
            player.setBonus = "Flower petals will fall on your target for extra damage\n13% thrown velocity";
        }
    }
}
