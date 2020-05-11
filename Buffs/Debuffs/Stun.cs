using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.Buffs.Debuffs
{
    public class Stun : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            modPlayer.stunned = true;
            modPlayer.stunTimer = 60;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            modNPC.stunned = true;
            modNPC.stunTimer = 60;
        }
    }
}
