using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using ClassOverhaul.Jobs;

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
        private UIText buttonChemist;
        private UIText dialogue;
        private float oldScale;
        public override void OnInitialize()
        {
            visible = false;
            panel = new JobSelectionPanel();
            panel.SetPadding(0);
            panel.Left.Set(410, 0);
            panel.Top.Set(250, 0);
            panel.Width.Set(500, 0);
            panel.Height.Set(150, 0);
            buttonKnight = new UIText("Knight", 0.8f);
            buttonKnight.Left.Set(15, 0);
            buttonKnight.Top.Set(110, 0);
            buttonKnight.TextColor = Color.Gold;
            buttonKnight.OnClick += new MouseEvent(OnClickKnight);
            buttonKnight.OnMouseOver += new MouseEvent(OnHoverKnight);
            buttonKnight.OnMouseOut += new MouseEvent(OnOutKnight);
            panel.Append(buttonKnight);
            buttonRogue = new UIText("Rogue", 0.8f);
            buttonRogue.Left.Set(85, 0);
            buttonRogue.Top.Set(110, 0);
            buttonRogue.TextColor = Color.Gold;
            buttonRogue.OnClick += new MouseEvent(OnClickRogue);
            buttonRogue.OnMouseOver += new MouseEvent(OnHoverRogue);
            buttonRogue.OnMouseOut += new MouseEvent(OnOutRogue);
            panel.Append(buttonRogue);
            buttonRanger = new UIText("Ranger", 0.8f);
            buttonRanger.Left.Set(160, 0);
            buttonRanger.Top.Set(110, 0);
            buttonRanger.TextColor = Color.Gold;
            buttonRanger.OnClick += new MouseEvent(OnClickRanger);
            buttonRanger.OnMouseOver += new MouseEvent(OnHoverRanger);
            buttonRanger.OnMouseOut += new MouseEvent(OnOutRanger);
            panel.Append(buttonRanger);
            buttonMage = new UIText("Mage", 0.8f);
            buttonMage.Left.Set(245, 0);
            buttonMage.Top.Set(110, 0);
            buttonMage.TextColor = Color.Gold;
            buttonMage.OnClick += new MouseEvent(OnClickMage);
            buttonMage.OnMouseOver += new MouseEvent(OnHoverMage);
            buttonMage.OnMouseOut += new MouseEvent(OnOutMage);
            panel.Append(buttonMage);
            buttonSummoner = new UIText("Summoner", 0.8f);
            buttonSummoner.Left.Set(320, 0);
            buttonSummoner.Top.Set(110, 0);
            buttonSummoner.TextColor = Color.Gold;
            buttonSummoner.OnClick += new MouseEvent(OnClickSummoner);
            buttonSummoner.OnMouseOver += new MouseEvent(OnHoverSummoner);
            buttonSummoner.OnMouseOut += new MouseEvent(OnOutSummoner);
            panel.Append(buttonSummoner);
            buttonChemist = new UIText("Chemist", 0.8f);
            buttonChemist.Left.Set(420, 0);
            buttonChemist.Top.Set(110, 0);
            buttonChemist.TextColor = Color.Gold;
            buttonChemist.OnClick += new MouseEvent(OnClickChemist);
            buttonChemist.OnMouseOver += new MouseEvent(OnHoverChemist);
            buttonChemist.OnMouseOut += new MouseEvent(OnOutChemist);
            //panel.Append(buttonChemist);
            dialogue = new UIText("Choose your preferred job, you won't be able to change this.\n(You won't be able to use hardmode items of other jobs.)", 0.8f);
            dialogue.Left.Set(25, 0);
            dialogue.Top.Set(25, 0);
            panel.Append(dialogue);
            Append(panel);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            PlayerEdits modPlayer = Main.LocalPlayer.GetModPlayer<PlayerEdits>();
            if (modPlayer.defeatedWoF == true && modPlayer.choseJob == false)
            {
                visible = true;
            }
            if (oldScale != Main.inventoryScale)
            {
                oldScale = Main.inventoryScale;
                Recalculate();
            }
            
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
            buttonKnight.SetText("Knight", 1.0f, false);
            Main.PlaySound(SoundID.MenuTick);
        }
        private void OnOutKnight(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonKnight.SetText("Knight", 0.8f, false);
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
            buttonRogue.SetText("Rogue", 1f, false);
            Main.PlaySound(SoundID.MenuTick);
        }
        private void OnOutRogue(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonRogue.SetText("Rogue", 0.8f, false);
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
            buttonRanger.SetText("Ranger", 1f, false);
            Main.PlaySound(SoundID.MenuTick);
        }
        private void OnOutRanger(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonRanger.SetText("Ranger", 0.8f, false);
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
            buttonMage.SetText("Mage", 1f, false);
            Main.PlaySound(SoundID.MenuTick);
        }
        private void OnOutMage(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonMage.SetText("Mage", 0.8f, false);
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
            buttonSummoner.SetText("Summoner", 1f, false);
            Main.PlaySound(SoundID.MenuTick);
        }
        private void OnOutSummoner(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonSummoner.SetText("Summoner", 0.8f, false);
        }
        private void OnClickChemist(UIMouseEvent evt, UIElement listeningElement)
        {
            PlayerEdits modPlayer = Main.LocalPlayer.GetModPlayer<PlayerEdits>();
            modPlayer.job = JobID.chemist;
            modPlayer.choseJob = true;
            modPlayer.immune = false;
            Main.PlaySound(SoundID.MenuClose);
            visible = false;
        }
        private void OnHoverChemist(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonChemist.SetText("Chemist", 1f, false);
            Main.PlaySound(SoundID.MenuTick);
        }
        private void OnOutChemist(UIMouseEvent evt, UIElement listeningElement)
        {
            buttonChemist.SetText("Chemist", 0.8f, false);
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
