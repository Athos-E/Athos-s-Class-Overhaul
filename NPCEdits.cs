using ClassOverhaul.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul
{
    public class NPCEdits : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
        public int atkCooldown = 0;
        public int atkSpeed = 30;
        public int defaultAtkSpeed = 30;
        public override void SetDefaults(NPC npc)
        {
            base.SetDefaults(npc);
            if (npc.type == NPCID.BlueJellyfish)
            {
                npc.catchItem = ItemID.BlueJellyfish;
            }
            if (npc.type == NPCID.PinkJellyfish)
            {
                npc.catchItem = ItemID.PinkJellyfish;
            }
            if (npc.type == NPCID.GreenJellyfish)
            {
                npc.catchItem = ItemID.GreenJellyfish;
            }
        }
        public override void AI(NPC npc)
        {
            base.AI(npc);
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (modNPC.atkCooldown > 0) atkCooldown -= 1;
            if (modNPC.atkCooldown < 0) atkCooldown = 0;
        }
        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            base.OnHitPlayer(npc, target, damage, crit);
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            modNPC.atkCooldown = modNPC.atkSpeed;
        }
        public override void ResetEffects(NPC npc)
        {
            base.ResetEffects(npc);
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            modNPC.atkSpeed = modNPC.defaultAtkSpeed;
        }
        public override bool CheckDead(NPC npc)
        {
            if (base.CheckDead(npc) && npc.type == NPCID.WallofFlesh)
            {
                PlayerEdits modPlayer = Main.player[Main.myPlayer].GetModPlayer<PlayerEdits>();
                modPlayer.defeatedWoF = true;
                modPlayer.immune = true;
                JobSelection.visible = true;
            }
            return base.CheckDead(npc);
        }
    }
}
