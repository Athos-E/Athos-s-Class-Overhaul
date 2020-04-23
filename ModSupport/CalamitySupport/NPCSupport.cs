using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.ModSupport.CalamitySupport
{
    public class NPCSupport
    {
        internal static Mod calamity = Calamity.instance;
        public NPCSupport() { }

        public static GlobalNPC calamityNPCMaster()
        {
            if (Calamity.exists)
            {
                return calamity.GetGlobalNPC("CalamityGlobalNPC");
            }
            return null;
        }

        public static GlobalNPC calamityNPC(NPC npc)
        {
            if (calamityNPCMaster() != null)
            {
                return calamityNPCMaster().Instance(npc);
            }
            return null;
        }
    }
}
