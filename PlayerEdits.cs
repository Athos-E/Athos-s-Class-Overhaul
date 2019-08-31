using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul
{
    class PlayerEdits : ModPlayer
    {
        public float chemicalDamage = 1f;
        public bool GellyfishBuff;
        public override void ResetEffects()
        {
            base.ResetEffects();
            chemicalDamage = 1f;
            GellyfishBuff = false;
        }
        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            base.OnHitByNPC(npc, damage, crit);
            if (GellyfishBuff)
            {
                player.ApplyDamageToNPC(npc, (int)((1 + (player.statDefense / 2)) * player.minionDamage), 5f, npc.direction * -1, false);
            }
        }
    }
}
