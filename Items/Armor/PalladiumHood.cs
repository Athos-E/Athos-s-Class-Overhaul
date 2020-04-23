using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class PalladiumHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Palladium Hood");
            Tooltip.SetDefault("8% increased melee damage\n10% increased thrown damage\n23% increased melee speed\n26% increased melee critical strike chance\n5% increased move speed");
        }
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            globalItem.rogueItem = true;
            item.defense = 10;
            globalItem.magicDefense = 12;
            item.rare = 4;
            item.value = 15000;
            item.width = 18;
            item.height = 18;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.08f;
            player.meleeSpeed += 0.23f;
            player.meleeCrit += 26;
            player.thrownDamage += 0.10f;
            player.moveSpeed += 0.05f;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.PalladiumBreastplate && legs.type == ItemID.PalladiumLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.palladiumRegen = true;
            player.thrownVelocity += 0.10f;
            player.setBonus = "Greatly increases life regeneration after striking an enemy\n10% increased thrown velocity";
        }
    }
}
