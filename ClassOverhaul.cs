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
        public static Mod instance { get { return ModLoader.GetMod("ClassOverhaul"); } }
        public ClassOverhaul() { }
        internal JobSelection jobSelectionUI;
        public UserInterface jobSelectionInterface;
        public override void PostSetupContent()
        {
            base.PostSetupContent();
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Gel, 10);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.SlimeStaff);
            recipe.AddRecipe();
            ChemistRecipe crecipe = new ChemistRecipe(this);
            crecipe.AddIngredient(ItemID.Bottle, 15);
            crecipe.AddIngredient(ItemID.Deathweed, 1);
            crecipe.AddIngredient(ItemID.VialofVenom, 1);
            crecipe.AddIngredient(ItemID.Fireblossom, 1);
            crecipe.AddIngredient(ItemID.ExplosivePowder, 1);
            crecipe.AddTile(TileID.AlchemyTable);
            crecipe.SetResult(ItemID.ToxicFlask, 15);
            crecipe.AddRecipe();
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
            if (!Main.gameMenu && JobSelection.visible)
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
            if (!Main.gameMenu && JobSelection.visible)
            {
                jobSelectionInterface.Draw(Main.spriteBatch, new GameTime());
            }
            return true;
        }
    }
}
