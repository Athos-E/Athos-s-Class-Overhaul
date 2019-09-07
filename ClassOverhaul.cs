using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.UI;
using ClassOverhaul.UI;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ClassOverhaul
{
    public class ClassOverhaul : Mod
    {
        internal JobSelection jobSelectionUI;
        public UserInterface jobSelectionInterface;
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
        }
        public override void Load()
        {
            if (!Main.dedServ)
            {
                jobSelectionUI = new JobSelection();
                jobSelectionUI.Initialize();
                jobSelectionInterface = new UserInterface();
                jobSelectionInterface.SetState(jobSelectionUI);
            }
            base.Load();
        }
        public override void UpdateUI(GameTime gameTime)
        {
            base.UpdateUI(gameTime);
            // it will only draw if the player is not on the main menu
            if (!Main.gameMenu
                && JobSelection.visible)
            {
                jobSelectionInterface?.Update(gameTime);
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int hotbarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Hotbar"));
            if (hotbarIndex != -1)
            {
                layers.Insert(hotbarIndex, new LegacyGameInterfaceLayer("ClassOverhaul: JobSelectionUI", DrawJobSelection, InterfaceScaleType.UI));
            }
        }
        private bool DrawJobSelection()
        {
            // it will only draw if the player is not on the main menu
            if (!Main.gameMenu
                && JobSelection.visible)
            {
                jobSelectionInterface.Draw(Main.spriteBatch, new GameTime());
            }
            return true;
        }
        public static void DisableRecipe(Mod mod, int result, int quantity)
        {
            RecipeFinder finder = new RecipeFinder();
            finder.SetResult(result, quantity);
            foreach (Recipe recipe in finder.SearchRecipes())
            {
                RecipeEditor editor = new RecipeEditor(recipe);
                editor.DeleteRecipe();
            }
        }
        public static void EnableRecipeVanillaItem(Mod mod, int result, int quantity = 1, int ingredient1 = 1, int units1 = 1, int ingredient2 = 0, int units2 = 1, int ingredient3 = 0, int units3 = 1, int ingredient4 = 0, int units4 = 1, int ingredient5 = 0, int units5 = 1, int tile = 0)
        {
            ModRecipe recipe = new ModRecipe(mod);
            if (tile > 0) recipe.AddTile(tile);
            recipe.AddIngredient(ingredient1, units1);
            if (ingredient2 > 0) recipe.AddIngredient(ingredient2);
            if (ingredient3 > 0) recipe.AddIngredient(ingredient3);
            if (ingredient4 > 0) recipe.AddIngredient(ingredient4);
            if (ingredient5 > 0) recipe.AddIngredient(ingredient5);
            recipe.SetResult(result, quantity);
            recipe.AddRecipe();
        }
        public static void EnableRecipeModItem(Mod mod, ModItem result, int quantity = 1, int ingredient1 = 1, int units1 = 1, int ingredient2 = 0, int units2 = 1, int ingredient3 = 0, int units3 = 1, int ingredient4 = 0, int units4 = 1, int ingredient5 = 0, int units5 = 1, int tile = 0)
        {
            ModRecipe recipe = new ModRecipe(mod);
            if (tile > 0) recipe.AddTile(tile);
            recipe.AddIngredient(ingredient1);
            if (ingredient2 > 0) recipe.AddIngredient(ingredient2);
            if (ingredient3 > 0) recipe.AddIngredient(ingredient3);
            if (ingredient4 > 0) recipe.AddIngredient(ingredient4);
            if (ingredient5 > 0) recipe.AddIngredient(ingredient5);
            recipe.SetResult(mod.GetItem(result.Name).item.type, quantity);
            recipe.AddRecipe();
            
        }
    }
}
