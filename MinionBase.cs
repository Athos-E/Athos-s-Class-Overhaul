using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul
{
    public abstract class MinionBase : ModNPC
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            npc.width = 32;
            npc.height = 32;
            npc.lifeMax = 100;
            npc.life = npc.lifeMax;
            npc.noTileCollide = false;
            npc.noGravity = true;
            modNPC.isMinion = true;
            modNPC.minionSlots = 1;
            modNPC.inertia = 30f;
            modNPC.idleAccel = 10f;
            modNPC.spacingMult = 1f;
            modNPC.viewDist = 300f;
            modNPC.chaseDist = 200f;
            modNPC.chaseAccel = 20f;
        }

        public abstract void Behavior();

        public override void AI()
        {
            base.AI();
            Behavior();
        }

        public virtual void CreateDust()
        {

        }

        public virtual void SelectFrame()
        {

        }
    }
}
