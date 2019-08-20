using Terraria.ModLoader;
using Terraria.ID;

namespace ClassOverhaul
{
    public class ClassOverhaul : Mod
    {
        public override void AddRecipes()
        {
            base.AddRecipes();
            ModRecipe recipe = new ModRecipe(this);
            //recipe.AddIngredient(ItemID.Wood, 1);
            //recipe.SetResult(this.GetItem("StaffOfFireball"), 1);
            //recipe.AddRecipe();
            //recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Gel, 10);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.SlimeStaff);
            recipe.AddRecipe();
        }
    }
}
