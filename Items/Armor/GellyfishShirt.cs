using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class GellyfishShirt : ModItem
    {
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            item.width = 18;
            item.height = 18;
            item.value = 9000;
            item.rare = ItemRarityID.Blue;
            item.defense = 6;
            globalItem.magicDefense = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.07f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vine);
            recipe.AddIngredient(ItemID.PinkJellyfish);
            recipe.AddIngredient(ItemID.PinkGel, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FishingSeaweed);
            recipe.AddIngredient(ItemID.PinkJellyfish);
            recipe.AddIngredient(ItemID.PinkGel, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
