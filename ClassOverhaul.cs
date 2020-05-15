using ClassOverhaul.Jobs;
using ClassOverhaul.ModSupport;
using ClassOverhaul.UI;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace ClassOverhaul
{
    public class ClassOverhaul : Mod
    {
        public static Mod instance { get { return ModLoader.GetMod("ClassOverhaul"); } }
        public ClassOverhaul() { }
        internal JobSelectionUI jobSelectionUI;
        internal MagicDefenseUI magicDefenseUI;
        public UserInterface jobSelectionInterface;
        public UserInterface magicDefenseInterface;
        public override void PostSetupContent()
        {
            base.PostSetupContent();
            RecipeFinder recipeFinder = new RecipeFinder();
            recipeFinder.SetResult(ItemID.BeetleScaleMail);
            recipeFinder.AddIngredient(ItemID.TurtleScaleMail);
            foreach(Recipe recip in recipeFinder.SearchRecipes())
            {
                RecipeEditor recipeEditor = new RecipeEditor(recip);
                recipeEditor.DeleteRecipe();
            }
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Gel, 10);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.SlimeStaff);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 14);
            recipe.AddIngredient(ItemID.BeetleHusk, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.BeetleHelmet);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 27);
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.BeetleScaleMail);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 21);
            recipe.AddIngredient(ItemID.BeetleHusk, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.BeetleLeggings);
            recipe.AddRecipe();
            AlchemistRecipe crecipe = new AlchemistRecipe(this);
            crecipe.AddIngredient(ItemID.Bottle, 15);
            crecipe.AddIngredient(ItemID.Deathweed, 1);
            crecipe.AddIngredient(ItemID.VialofVenom, 1);
            crecipe.AddIngredient(ItemID.Fireblossom, 1);
            crecipe.AddIngredient(ItemID.ExplosivePowder, 1);
            crecipe.AddTile(TileID.AlchemyTable);
            crecipe.SetResult(ItemID.ToxicFlask, 15);
            crecipe.AddRecipe();
            ModMethods.PostSetupContent();
        }
        public override void Load()
        {
            if (!Main.dedServ)
            {
                jobSelectionUI = new JobSelectionUI();
                jobSelectionUI.Initialize();
                jobSelectionInterface = new UserInterface();
                jobSelectionInterface.SetState(jobSelectionUI);
                magicDefenseUI = new MagicDefenseUI();
                magicDefenseUI.Initialize();
                magicDefenseInterface = new UserInterface();
                magicDefenseInterface.SetState(magicDefenseUI);
            }
            base.Load();
        }

        public override void UpdateUI(GameTime gameTime)
        {
            base.UpdateUI(gameTime);
            // it will only draw if the player is not on the main menu
            if (!Main.gameMenu && JobSelectionUI.visible)
            {
                jobSelectionInterface?.Update(gameTime);
            }
            if (!Main.gameMenu)
            {
                magicDefenseInterface?.Update(gameTime);
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int hotbarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Hotbar"));
            if (hotbarIndex != -1)
            {
                layers.Insert(hotbarIndex, new LegacyGameInterfaceLayer("ClassOverhaul: JobSelectionUI", DrawJobSelectionUI, InterfaceScaleType.UI));
            }
            int defenseIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Info Accessories Bar"));
            if (defenseIndex != -1)
            {
                layers.Insert(defenseIndex, new LegacyGameInterfaceLayer("ClassOverhaul: MagicDefenseUI", DrawMagicDefenseUI, InterfaceScaleType.UI));
            }
        }
        private bool DrawJobSelectionUI()
        {
            // it will only draw if the player is not on the main menu
            if (!Main.gameMenu && JobSelectionUI.visible)
            {
                jobSelectionInterface.Draw(Main.spriteBatch, new GameTime());
            }
            return true;
        }
        private bool DrawMagicDefenseUI()
        {
            if (!Main.gameMenu)
            {
                magicDefenseInterface.Draw(Main.spriteBatch, new GameTime());
            }
            return true;
        }
    }
}
