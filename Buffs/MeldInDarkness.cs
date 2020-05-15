using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.Buffs
{
    public class MeldInDarkness : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            player.nightVision = true;
            player.invis = true;
            modPlayer.enInvis = true;
        }
    }
}
