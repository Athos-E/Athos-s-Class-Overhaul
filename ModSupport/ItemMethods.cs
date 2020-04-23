using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.ModSupport
{
    public class ItemMethods
    {
        public ItemMethods() { }
        public static void SetDefaults(Item item)
        {
            if (ConsolariaSupport.Consolaria.exists)
            {
                ConsolariaSupport.ItemSupport.SetDefaults(item);
            }
            //if (CalamitySupport.Calamity.exists)
            //{
            //    CalamitySupport.ItemSupport.SetDefaults(item);
            //}
        }
        public static void UpdateInventory(Item item)
        {

        }
        public static void PostUpdate(Item item)
        {
            //if (CalamitySupport.Calamity.exists)
            //{
            //    CalamitySupport.ItemSupport.PostUpdate(item);
            //}
        }
    }
}
