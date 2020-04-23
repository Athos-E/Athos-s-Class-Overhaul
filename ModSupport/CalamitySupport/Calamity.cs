using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.ModSupport.CalamitySupport
{
    public class Calamity
    {
        public static Mod instance = ModLoader.GetMod("CalamityMod");
        public static bool exists = instance != null;
        public Calamity() { }
    }
}