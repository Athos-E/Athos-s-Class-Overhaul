using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TitaniumHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Titanium Hood");
            Tooltip.SetDefault("9% increased melee damage\n19% increased thrown damage\n17% increased melee speed\n33% increased melee critical strike chance\n6% increased move speed");
        }
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            globalItem.rogueItem = true;
            item.defense = 18;
            globalItem.magicDefense = 21;
            item.rare = 4;
            item.value = 30000;
            item.width = 18;
            item.height = 18;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.09f;
            player.thrownDamage += 0.19f;
            player.meleeSpeed += 0.17f;
            player.meleeCrit += 33;
            player.moveSpeed += 0.6f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.shadowDodge = true;
            player.thrownVelocity += 0.18f;
            player.setBonus = "Become immune after striking an enemy\n18% increased thrown velocity";
        }
    }
}
