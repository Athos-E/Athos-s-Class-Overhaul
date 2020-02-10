using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul
{
    public class Consolaria
    {
        public static Mod instance = ModLoader.GetMod("Consolaria");
        public static bool consolariaExists = instance != null;
        public Consolaria() { }
    }
}
