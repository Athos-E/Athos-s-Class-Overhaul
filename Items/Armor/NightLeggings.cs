using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class NightLeggings : ModItem
    {
        public override bool Autoload(ref string name) => false;
        public override void SetDefaults()
        {
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            modItem.rogueItem = true;
            item.defense = 20;
            modItem.magicDefense = 23;
            item.rare = 8;
            item.value = Item.sellPrice(gold: 7);
            item.width = 18;
            item.height = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += 0.11f;
            player.moveSpeed += 0.15f;
        }    

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteBar, 8);
            recipe.AddIngredient(mod.ItemType("EvilScales"), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
