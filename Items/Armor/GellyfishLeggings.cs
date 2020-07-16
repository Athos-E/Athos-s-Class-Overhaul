using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class GellyfishLeggings : ModItem
    {   
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            item.width = 18;
            item.height = 18;
            item.value = 6000;
            item.rare = ItemRarityID.Blue;
            item.defense = 5;
            globalItem.magicDefense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.04f;
        }

        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vine);
            recipe.AddIngredient(ItemID.PinkJellyfish);
            recipe.AddIngredient(ItemID.PinkGel, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FishingSeaweed);
            recipe.AddIngredient(ItemID.PinkJellyfish);
            recipe.AddIngredient(ItemID.PinkGel, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}