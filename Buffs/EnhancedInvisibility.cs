using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.Buffs
{
    public class EnhancedInvisibility : ModBuff
    {
        public override bool Autoload(ref string name, ref string texture) => false;
        public override void SetDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            player.invis = true;
            modPlayer.enInvis = true;
        }
    }
}
