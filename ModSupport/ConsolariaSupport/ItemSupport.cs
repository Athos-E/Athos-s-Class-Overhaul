using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ClassOverhaul.Jobs;

namespace ClassOverhaul.ModSupport.ConsolariaSupport
{
    public class ItemSupport
    {
        public ItemSupport() { }
        public static void SetDefaults(Item item)
        {
            if (Consolaria.exists)
            {
                Mod consolaria = Consolaria.instance;
                ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
                if (item.type == consolaria.ItemType("AncientDragonMask") || item.type == consolaria.ItemType("AncientDragonBreastplate")
                || item.type == consolaria.ItemType("AncientDragonGreaves") || item.type == consolaria.ItemType("DragonMask")
                || item.type == consolaria.ItemType("DragonGreaves") || item.type == consolaria.ItemType("DragonBreastplate")
                ) {
                    modItem.knightItem = true;
                }
                if (item.type == consolaria.ItemType("AncientTitanHelmet") || item.type == consolaria.ItemType("AncientTitanLeggings")
                || item.type == consolaria.ItemType("AncientTitanMail") || item.type == consolaria.ItemType("TitanHelmet")
                || item.type == consolaria.ItemType("TitanLeggings") || item.type == consolaria.ItemType("TitanMail")
                ) {
                    modItem.rangerItem = true;
                }
                if (item.type == consolaria.ItemType("AncientSpectralArmor") || item.type == consolaria.ItemType("AncientSpectralHeadgear")
                || item.type == consolaria.ItemType("AncientSpectralSubligar") || item.type == consolaria.ItemType("SpectralArmor")
                || item.type == consolaria.ItemType("SpectralHeadgear") || item.type == consolaria.ItemType("SpectralSubligar")
                ) {
                    modItem.mageItem = true;
                }
                if (item.type == consolaria.ItemType("AncientWarlockHood") || item.type == consolaria.ItemType("AncientWarlockLeggings")
                || item.type == consolaria.ItemType("AncientWarlockRobe") || item.type == consolaria.ItemType("WarlockHood")
                || item.type == consolaria.ItemType("WarlockLeggings") || item.type == consolaria.ItemType("WarlockRobe")
                ) {
                    modItem.summonerItem = true;
                }
                if (item.type == consolaria.ItemType("AlbinoMandible"))
                {
                    item.ranged = false;
                    item.thrown = true;
                }
                if (ItemEdits.IsModItem(item) && item.modItem != null && item.type == consolaria.ItemType(item.modItem.Name))
                    JobHooks.ApplyClassAssigns(item);
                if (item.type == consolaria.ItemType("AncientDragonBreastplate") || item.type == consolaria.ItemType("DragonBreastplate")
                ) {
                    item.defense += 20;
                }
                if (item.type == consolaria.ItemType("SpectralArrow"))
                {
                    item.alpha = 127;
                }
            }
        }
    }
}
