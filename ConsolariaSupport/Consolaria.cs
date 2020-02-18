using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.ConsolariaSupport
{
    public class Consolaria
    {
        public static Mod instance = ModLoader.GetMod("Consolaria");
        public static bool consolariaExists = instance != null;
        public Consolaria() { }
    }
}
