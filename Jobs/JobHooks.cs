using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.Jobs
{
    public class JobHooks
    {
        public JobHooks() { }

        public static void ApplyClassAssigns(Item item)
        {
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            if (item.defense < 1)
            {
                modItem.knightItem = false;
                modItem.rogueItem = false;
                modItem.rangerItem = false;
                modItem.mageItem = false;
                modItem.summonerItem = false;
                modItem.chemistItem = false;
            }
            if (item.melee) { modItem.knightItem = true; modItem.rogueItem = true; }
            if (item.thrown) { modItem.rogueItem = true; modItem.chemistItem = true; }
            if (item.ranged) modItem.rangerItem = true;
            if (item.magic) { modItem.mageItem = true; }
            if (item.summon) { modItem.summonerItem = true; modItem.mageItem = true; }
            if (modItem.chemical) modItem.chemistItem = true;
        }

        public static bool CanEquip(Item item, Player player)
        {
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if (modItem.blocked == true) return false;
            if (modItem.isBasic == true) return true;
            if (modPlayer.choseJob == true)
            {
                if (modItem.knightItem || modItem.rogueItem || modItem.rangerItem || modItem.mageItem || modItem.summonerItem || modItem.chemistItem)
                {
                    switch (modPlayer.job)
                    {
                        case JobID.knight:
                            switch (modPlayer.armorJob)
                            {
                                case 0:
                                    if (modItem.knightItem) return true;
                                    break;
                                case JobID.summoner:
                                    if (modItem.knightItem || modItem.summonerItem) return true;
                                    break;
                                case JobID.ranger:
                                    if (modItem.knightItem || modItem.rangerItem) return true;
                                    break;
                            }
                            break;
                        case JobID.rogue:
                            if (modPlayer.armorJob == JobID.summoner)
                            {
                                if (modItem.rogueItem || modItem.summonerItem) return true;
                            }
                            else
                            {
                                if (modItem.rogueItem) return true;
                            }
                            break;
                        case JobID.ranger:
                            switch (modPlayer.armorJob)
                            {
                                case 0:
                                    if (modItem.rangerItem) return true;
                                    break;
                                case JobID.summoner:
                                    if (modItem.rangerItem || modItem.summonerItem) return true;
                                    break;
                                case JobID.knight:
                                    if (modItem.rangerItem || modItem.knightItem) return true;
                                    break;
                            }
                            break;
                        case JobID.mage:
                            switch (modPlayer.armorJob)
                            {
                                case 0:
                                    if (modItem.mageItem) return true;
                                    break;
                                case JobID.summoner:
                                    if (modItem.mageItem || modItem.summonerItem) return true;
                                    break;
                            }
                            break;
                        case JobID.summoner:
                            switch (modPlayer.armorJob)
                            {
                                case 0:
                                    if (modItem.summonerItem) return true;
                                    break;
                                case JobID.knight:
                                    if (modItem.summonerItem || modItem.knightItem) return true;
                                    break;
                                case JobID.rogue:
                                    if (modItem.summonerItem || modItem.rogueItem) return true;
                                    break;
                                case JobID.ranger:
                                    if (modItem.summonerItem || modItem.rangerItem) return true;
                                    break;
                                case JobID.mage:
                                    if (modItem.summonerItem || modItem.mageItem) return true;
                                    break;
                                case JobID.chemist:
                                    if (modItem.summonerItem || modItem.chemistItem) return true;
                                    break;
                            }
                            if (modItem.chemistItem) return true;
                            break;
                        case JobID.chemist:
                            if (modPlayer.armorJob == JobID.summoner)
                            {
                                if (modItem.chemistItem || modItem.summonerItem) return true;
                            }
                            else
                            {
                                if (modItem.chemistItem) return true;
                            }
                            break;
                    }
                }
                else
                {
                    if (item.melee == false && item.thrown == false && item.ranged == false && item.magic == false && item.summon == false && modItem.chemical == false && item.accessory == false && ItemEdits.IsModItem(item) == true && ItemEdits.IsCOItem(item) == false && item.defense > 0)
                        return true;
                    switch (modPlayer.job)
                    {
                        case JobID.knight:
                            switch (modPlayer.armorJob)
                            {
                                case 0:
                                    if (item.melee) return true;
                                    break;
                                case JobID.summoner:
                                    if (item.melee || item.summon) return true;
                                    break;
                                case JobID.ranger:
                                    if (item.melee || item.ranged) return true;
                                    break;
                            }
                            break;
                        case JobID.rogue:
                            if (modPlayer.armorJob == JobID.summoner)
                            {
                                if (item.thrown || item.melee || item.summon) return true;
                            }
                            else
                            {
                                if (item.thrown || item.melee) return true;
                            }
                            break;
                        case JobID.ranger:
                            switch (modPlayer.armorJob)
                            {
                                case 0:
                                    if (item.ranged) return true;
                                    break;
                                case JobID.summoner:
                                    if (item.ranged || item.summon) return true;
                                    break;
                                case JobID.knight:
                                    if (item.ranged || item.melee) return true;
                                    break;
                            }
                            break;
                        case JobID.mage:
                            switch (modPlayer.armorJob)
                            {
                                case 0:
                                    if (item.magic) return true;
                                    break;
                                case JobID.summoner:
                                    if (item.magic || item.summon) return true;
                                    break;
                            }
                            break;
                        case JobID.summoner:
                            switch (modPlayer.armorJob)
                            {
                                case 0:
                                    if (item.summon) return true;
                                    break;
                                case JobID.knight:
                                    if (item.summon || item.melee) return true;
                                    break;
                                case JobID.rogue:
                                    if (item.summon || item.thrown || item.melee) return true;
                                    break;
                                case JobID.ranger:
                                    if (item.summon || item.ranged) return true;
                                    break;
                                case JobID.mage:
                                    if (item.summon || item.magic) return true;
                                    break;
                                case JobID.chemist:
                                    if (item.summon || modItem.chemical) return true;
                                    break;
                            }
                            if (item.summon) return true;
                            break;
                        case JobID.chemist:
                            if (modPlayer.armorJob == JobID.summoner)
                            {
                                if (item.thrown || modItem.chemical || item.summon) return true;
                            }
                            else
                            {
                                if (item.thrown || modItem.chemical) return true;
                            }
                            break;
                    }
                }
            }
            return modItem.preHardmode;
        }
    }
}
