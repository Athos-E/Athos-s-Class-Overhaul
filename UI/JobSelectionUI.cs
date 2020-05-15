using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using ClassOverhaul.Jobs;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;

namespace ClassOverhaul.UI
{
    internal class JobSelectionUI : UIState
    {
        public static bool visible;
        private JobSelectionPanel panel;
        private UIText buttonKnight;
        private UIText buttonRogue;
        private UIText buttonRanger;
        private UIText buttonMage;
        private UIText buttonSummoner;
        private UIText buttonAlchemist;
        private UIText dialogue;
        private float oldScale;
        string Root = "Mods.ClassOverhaul";
        public override void OnInitialize()
        {
            visible = false;
            panel = new JobSelectionPanel();
            panel.SetPadding(0);
            panel.Left.Set(Main.screenWidth / 3, 0);
            panel.Top.Set(Main.screenHeight / 3, 0);
            panel.Width.Set(500, 0);
            panel.Height.Set(150, 0);
            buttonKnight = new UIText("", 0.8f);
            buttonKnight.Left.Set(15, 0);
            buttonKnight.Top.Set(110, 0);
            buttonKnight.TextColor = Color.Gold;
            buttonKnight.OnClick += new MouseEvent(OnClickKnight);
            buttonKnight.OnMouseOver += new MouseEvent(OnHoverKnight);
            buttonKnight.OnMouseOut += new MouseEvent(OnOutKnight);
            panel.Append(buttonKnight);
            buttonRogue = new UIText("", 0.8f);
            buttonRogue.Left.Set(85, 0);
            buttonRogue.Top.Set(110, 0);
            buttonRogue.TextColor = Color.Gold;
            buttonRogue.OnClick += new MouseEvent(OnClickRogue);
            buttonRogue.OnMouseOver += new MouseEvent(OnHoverRogue);
            buttonRogue.OnMouseOut += new MouseEvent(OnOutRogue);
            panel.Append(buttonRogue);
            buttonRanger = new UIText("", 0.8f);
            buttonRanger.Left.Set(160, 0);
            buttonRanger.Top.Set(110, 0);
            buttonRanger.TextColor = Color.Gold;
            buttonRanger.OnClick += new MouseEvent(OnClickRanger);
            buttonRanger.OnMouseOver += new MouseEvent(OnHoverRanger);
            buttonRanger.OnMouseOut += new MouseEvent(OnOutRanger);
            panel.Append(buttonRanger);
            buttonMage = new UIText("", 0.8f);
            buttonMage.Left.Set(245, 0);
            buttonMage.Top.Set(110, 0);
            buttonMage.TextColor = Color.Gold;
            buttonMage.OnClick += new MouseEvent(OnClickMage);
            buttonMage.OnMouseOver += new MouseEvent(OnHoverMage);
            buttonMage.OnMouseOut += new MouseEvent(OnOutMage);
            panel.Append(buttonMage);
            buttonSummoner = new UIText("", 0.8f);
            buttonSummoner.Left.Set(320, 0);
            buttonSummoner.Top.Set(110, 0);
            buttonSummoner.TextColor = Color.Gold;
            buttonSummoner.OnClick += new MouseEvent(OnClickSummoner);
            buttonSummoner.OnMouseOver += new MouseEvent(OnHoverSummoner);
            buttonSummoner.OnMouseOut += new MouseEvent(OnOutSummoner);
            panel.Append(buttonSummoner);
            buttonAlchemist = new UIText("", 0.8f);
            buttonAlchemist.Left.Set(420, 0);
            buttonAlchemist.Top.Set(110, 0);
            buttonAlchemist.TextColor = Color.Gold;
            buttonAlchemist.OnClick += new MouseEvent(OnClickAlchemist);
            buttonAlchemist.OnMouseOver += new MouseEvent(OnHoverAlchemist);
            buttonAlchemist.OnMouseOut += new MouseEvent(OnOutAlchemist);
            //panel.Append(buttonAlchemist);
            dialogue = new UIText("", 0.8f);
            dialogue.Left.Set(25, 0);
            dialogue.Top.Set(25, 0);
            panel.Append(dialogue);
            Append(panel);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            PlayerEdits modPlayer = Main.LocalPlayer.GetModPlayer<PlayerEdits>();
            if(modPlayer.defeatedWoF == true && modPlayer.choseJob == false)
            {
                visible = true;
            }
            else
                visible = false;
            if (oldScale != Main.inventoryScale)
            {
                oldScale = Main.inventoryScale;
                Recalculate();
            }
            buttonKnight.SetText(Language.GetTextValue($"{Root}.CommonName.Knight"));
            buttonRogue.SetText(Language.GetTextValue($"{Root}.CommonName.Rogue"));
            buttonRanger.SetText(Language.GetTextValue($"{Root}.CommonName.Ranger"));
            buttonMage.SetText(Language.GetTextValue($"{Root}.CommonName.Mage"));
            buttonSummoner.SetText(Language.GetTextValue($"{Root}.CommonName.Summoner"));
            buttonAlchemist.SetText(Language.GetTextValue($"{Root}.CommonName.Alchemist"));
            dialogue.SetText(Language.GetTextValue($"{Root}.UIText.JobSelection"));
        }

        private void OnClickKnight(UIMouseEvent evt, UIElement listeningElement)
        {
            PlayerEdits modPlayer = Main.LocalPlayer.GetModPlayer<PlayerEdits>();
            modPlayer.job = JobID.knight;
            modPlayer.choseJob = true;
            modPlayer.immune = false;
            Main.PlaySound(SoundID.MenuClose);
            visible = false;
        }
        private void OnHoverKnight(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonKnight.SetText(buttonKnight.Text, 1.0f, false);
            Main.PlaySound(SoundID.MenuTick);
        }
        private void OnOutKnight(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonKnight.SetText(buttonKnight.Text, 0.8f, false);
        }
        private void OnClickRogue(UIMouseEvent evt, UIElement listeningElement)
        {
            PlayerEdits modPlayer = Main.LocalPlayer.GetModPlayer<PlayerEdits>();
            modPlayer.job = JobID.rogue;
            modPlayer.choseJob = true;
            modPlayer.immune = false;
            Main.PlaySound(SoundID.MenuClose);
            visible = false;
        }
        private void OnHoverRogue(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonRogue.SetText(buttonRogue.Text, 1f, false);
            Main.PlaySound(SoundID.MenuTick);
        }
        private void OnOutRogue(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonRogue.SetText(buttonRogue.Text, 0.8f, false);
        }
        private void OnClickRanger(UIMouseEvent evt, UIElement listeningElement)
        {
            PlayerEdits modPlayer = Main.LocalPlayer.GetModPlayer<PlayerEdits>();
            modPlayer.job = JobID.ranger;
            modPlayer.choseJob = true;
            modPlayer.immune = false;
            Main.PlaySound(SoundID.MenuClose);
            visible = false;
        }
        private void OnHoverRanger(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonRanger.SetText(buttonRanger.Text, 1f, false);
            Main.PlaySound(SoundID.MenuTick);
        }
        private void OnOutRanger(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonRanger.SetText(buttonRanger.Text, 0.8f, false);
        }
        private void OnClickMage(UIMouseEvent evt, UIElement listeningElement)
        {
            PlayerEdits modPlayer = Main.LocalPlayer.GetModPlayer<PlayerEdits>();
            modPlayer.job = JobID.mage;
            modPlayer.choseJob = true;
            modPlayer.immune = false;
            Main.PlaySound(SoundID.MenuClose);
            visible = false;
        }
        private void OnHoverMage(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonMage.SetText(buttonMage.Text, 1f, false);
            Main.PlaySound(SoundID.MenuTick);
        }
        private void OnOutMage(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonMage.SetText(buttonMage.Text, 0.8f, false);
        }
        private void OnClickSummoner(UIMouseEvent evt, UIElement listeningElement)
        {
            PlayerEdits modPlayer = Main.LocalPlayer.GetModPlayer<PlayerEdits>();
            modPlayer.job = JobID.summoner;
            modPlayer.choseJob = true;
            modPlayer.immune = false;
            Main.PlaySound(SoundID.MenuClose);
            visible = false;
        }
        private void OnHoverSummoner(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonSummoner.SetText(buttonSummoner.Text, 1f, false);
            Main.PlaySound(SoundID.MenuTick);
        }
        private void OnOutSummoner(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonSummoner.SetText(buttonSummoner.Text, 0.8f, false);
        }
        private void OnClickAlchemist(UIMouseEvent evt, UIElement listeningElement)
        {
            PlayerEdits modPlayer = Main.LocalPlayer.GetModPlayer<PlayerEdits>();
            modPlayer.job = JobID.alchemist;
            modPlayer.choseJob = true;
            modPlayer.immune = false;
            Main.PlaySound(SoundID.MenuClose);
            visible = false;
        }
        private void OnHoverAlchemist(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonAlchemist.SetText(buttonAlchemist.Text, 1f, false);
            Main.PlaySound(SoundID.MenuTick);
        }
        private void OnOutAlchemist(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonAlchemist.SetText(buttonAlchemist.Text, 0.8f, false);
        }
    }
    internal class JobSelectionPanel : UIPanel
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (ContainsPoint(Main.MouseScreen))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            var parentSpace = Parent.GetDimensions().ToRectangle();
            if (!GetDimensions().ToRectangle().Intersects(parentSpace))
            {
                Left.Pixels = Utils.Clamp(Left.Pixels, 0, parentSpace.Right - Width.Pixels);
                Top.Pixels = Utils.Clamp(Top.Pixels, 0, parentSpace.Bottom - Height.Pixels);
                // Recalculate forces the UI system to do the positioning math again.
                Recalculate();
            }
        }
    }
}
