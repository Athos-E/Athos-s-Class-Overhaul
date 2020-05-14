using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class PalladiumHood : ModItem
    {
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
            player.meleeSpeed += 0.14f;
            player.meleeCrit += 14;
            player.thrownDamage += 0.15f;
            player.thrownVelocity += 0.10f;
            player.moveSpeed += 0.07f;

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
            player.setBonus = Language.GetTextValue("Mods.ClassOverhaul.ArmorSetBonus.PalladiumRogue");
        }
    }
}
