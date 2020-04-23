using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.ModSupport.ConsolariaSupport
{
    public class Consolaria
    {
        public static Mod instance = ModLoader.GetMod("Consolaria");
        public static bool exists = instance != null;
        public Consolaria() { }
    }
}
