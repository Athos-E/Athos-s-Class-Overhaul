using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClassOverhaul.ConsolariaSupport
{
    public class ItemSupport
    {
        public ItemSupport() { }
        public static void SetDefaults(Item item)
        {
            if (Consolaria.consolariaExists)
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
                if (item.type == consolaria.ItemType("AncientDragonBreastplate") || item.type == consolaria.ItemType("DragonBreastplate")
                ) {
                    item.defense += 20;
                }
                if (item.modItem != null)
                {
                    if (item.magic == true && item.type == consolaria.ItemType(item.modItem.Name))
                    {
                        item.damage += (10 + (item.mana / 2) + item.rare);
                        if (item.crit > 4)
                        {
                            item.damage += item.crit - 4;
                        }
                    }
                    if (item.magic == true && item.type == consolaria.ItemType(item.modItem.Name))
                    {
                        item.crit = 0;
                    }
                    if (item.thrown == true && item.type == consolaria.ItemType(item.modItem.Name))
                    {
                        if (item.crit >= 4)
                        {
                            item.crit -= 4;
                        }
                        else
                        {
                            item.crit = 0;
                        }
                    }
                }
                if (item.type == consolaria.ItemType("SpectralArrow"))
                {
                    item.alpha = 127;
                }
            }
        }
    }
}
