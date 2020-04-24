using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace ClassOverhaul.UI
{
    internal class MagicDefenseUI : UIState
    {
        private UIElement area;
        private UIImage backImage;
        private UIText text;
        private float oldScale;

        public override void OnInitialize()
        {
            area = new UIElement();
            area.Left.Set(-area.Width.Pixels - 3 - (Main.screenWidth / 6), 1f);
            area.Top.Set(-area.Height.Pixels - 3 - (Main.screenHeight / 6), 1f);
            area.Width.Set(36, 0f);
            area.Height.Set(36, 0f);

            backImage = new UIImage(GetTexture("ClassOverhaul/UI/Textures/ManaShield"));
            backImage.Top.Set(0, 0f);
            backImage.Left.Set(0, 0f);
            backImage.Width.Set(area.Width.Pixels, 0f);
            backImage.Height.Set(area.Width.Pixels, 0f);
            backImage.ImageScale = 0.9f;

            text = new UIText("0", 0.9f);
            text.Top.Set(area.Width.Pixels / 2 - 10, 0f);
            text.Left.Set(area.Height.Pixels / 2 - 11, 0f);
            text.Width.Set(area.Width.Pixels / 2 + 6, 0f);
            text.Height.Set(area.Height.Pixels / 2 + 6, 0f);

            area.Append(backImage);
            area.Append(text);
            Append(area);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Main.playerInventory)
                return;
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            PlayerEdits modPlayer = Main.LocalPlayer.GetModPlayer<PlayerEdits>();
            text.SetText($"{modPlayer.magicDefense}");
            if (oldScale != Main.inventoryScale)
            {
                oldScale = Main.inventoryScale;
                Recalculate();
            }
            base.Update(gameTime);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (backImage.IsMouseHovering)
            {
                PlayerEdits modPlayer = Main.LocalPlayer.GetModPlayer<PlayerEdits>();
                Main.hoverItemName = $"{modPlayer.magicDefense} Magic Defense";
            }
            base.DrawSelf(spriteBatch);
        }
    }
}
