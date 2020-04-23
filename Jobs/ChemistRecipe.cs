using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.Jobs
{
    public class ChemistRecipe : ModRecipe
    {
        public PlayerEdits modPlayer;

        public ChemistRecipe(Mod mod) : base(mod)
        {
            if (Main.LocalPlayer.whoAmI > 0)
            {
                modPlayer = Main.LocalPlayer.GetModPlayer<PlayerEdits>();
            }
        }

        public override bool RecipeAvailable()
        {
            if (modPlayer != null && modPlayer.job == JobID.chemist)
            {
                return base.RecipeAvailable();
            }
            return false;
        }
    }
}
