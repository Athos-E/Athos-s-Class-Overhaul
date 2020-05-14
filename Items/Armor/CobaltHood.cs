using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class CobaltHood : ModItem
    {
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            globalItem.rogueItem = true;
            item.defense = 8;
            globalItem.magicDefense = 9;
            item.rare = 4;
            item.value = 15000;
            item.width = 18;
            item.height = 18;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 12;
            player.meleeSpeed += 0.14f;
            player.moveSpeed += 0.09f;
            player.thrownVelocity += 0.11f;

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
            player.meleeSpeed += 0.17f;
            player.moveSpeed += 0.05f;
            player.setBonus = Language.GetTextValue("Mods.ClassOverhaul.ArmorSetBonus.CobaltRogue");
        }
    }
}
