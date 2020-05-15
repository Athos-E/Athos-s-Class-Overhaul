using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ChlorophyteHood : ModItem
    {
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            globalItem.rogueItem = true;
            item.defense = 21;
            globalItem.magicDefense = 24;
            item.rare = 7;
            item.value = 60000;
            item.width = 18;
            item.height = 18;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.16f;
            player.thrownDamage += 0.28f;
            player.meleeSpeed += 0.24f;
            player.meleeCrit += 30;
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
            player.setBonus = Language.GetTextValue("Mods.ClassOverhaul.ArmorSetBonus.ChlorophyteRogue");
        }
    }
}
