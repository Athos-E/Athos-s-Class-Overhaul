using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class HallowedHood : ModItem
    {
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            globalItem.rogueItem = true;
            item.defense = 18;
            globalItem.magicDefense = 21;
            item.rare = ItemRarityID.Pink;
            item.value = 15000;
            item.width = 18;
            item.height = 18;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.18f;
            player.thrownDamage += 0.25f;
            player.meleeSpeed += 0.23f;
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
            player.thrownDamage += 0.1f;
            player.meleeSpeed += 0.18f;
            player.moveSpeed += 0.10f;
            player.setBonus = Language.GetTextValue("Mods.ClassOverhaul.ArmorSetBonus.HallowedRogue");
        }
    }
}
