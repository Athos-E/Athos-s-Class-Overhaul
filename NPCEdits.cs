using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul
{
    public class NPCEdits : GlobalNPC
    {
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
    }
}
