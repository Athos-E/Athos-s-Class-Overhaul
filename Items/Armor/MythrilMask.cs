using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class MythrilMask : ModItem
    {
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            globalItem.rogueItem = true;
            item.defense = 14;
            globalItem.magicDefense = 16;
            item.rare = ItemRarityID.LightRed;
            item.value = 22500;
            item.width = 18;
            item.height = 18;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.10f;
            player.thrownDamage += 0.20f;
            player.meleeSpeed += 0.17f;
            player.meleeCrit += 18;
            player.moveSpeed += 0.10f;
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
            player.thrownDamage += 0.05f;
            player.meleeCrit += 6;
            player.setBonus = Language.GetTextValue("Mods.ClassOverhaul.ArmorSetBonus.MythrilRogue");
        }
    }
}
