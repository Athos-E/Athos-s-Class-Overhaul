using Terraria;
using Terraria.ModLoader;
using System;
using System.Reflection;
using ClassOverhaul.Jobs;

namespace ClassOverhaul.ModSupport.CalamitySupport
{
    public class ItemSupport
    {
        public static bool[] calamityDefaultRogueDI;
        public static bool[] calamityAvailableRogueItem;
        internal static Mod calamity = Calamity.instance;
        public ItemSupport() { }

        public static GlobalItem calamityItemMaster()
        {
            if (Calamity.exists)
            {
                return calamity.GetGlobalItem("CalamityGlobalItem");
            }
            return null;
        }

        public static GlobalItem calamityItem(Item item)
        {
            if (calamityItemMaster() != null)
            {
                return calamityItemMaster().Instance(item);
            }
            return null;
        }

        public static bool hasRogueDamage(Item item)
        {
            if (calamityItem(item) != null)
            {
                FieldInfo field = calamityItem(item).GetType().GetField("rogue", BindingFlags.Public | BindingFlags.Instance);
                return (bool)field.GetValue(calamityItem(item));
            }
            return false;
        }

        public static void SetDefaults(Item item)
        {
            if (calamityItem(item) != null) {
                ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
                if (hasRogueDamage(item))
                {
                    calamityDefaultRogueDI[item.type] = hasRogueDamage(item);
                    calamityItem(item).GetType().GetField("rogue").SetValue(calamityItem(item), (bool)false);
                }
                if (item.type == calamity.ItemType("MeteorFist") || item.type == calamity.ItemType("SeafoamBomb")
                    || item.type == calamity.ItemType("BlastBarrel") || item.type == calamity.ItemType("BallisticPoisonBomb")
                    || item.type == calamity.ItemType("BouncingBetty") || item.type == calamity.ItemType("ConsecratedWater")
                    || item.type == calamity.ItemType("BrackishFlask") || item.type == calamity.ItemType("CraniumSmasher")
                    || item.type == calamity.ItemType("DesecratedWater") || item.type == calamity.ItemType("DuststormInABottle")
                    || item.type == calamity.ItemType("Exorcism") || item.type == calamity.ItemType("LatcherMine")
                    || item.type == calamity.ItemType("Plaguenade") || item.type == calamity.ItemType("ShockGrenade")
                    || item.type == calamity.ItemType("SpentFuelContainer") || item.type == calamity.ItemType("StarOfDestruction")
                    || item.type == calamity.ItemType("TotalityBreakers") || item.type == calamity.ItemType("Penumbra")
                    || item.type == calamity.ItemType("Supernova") || item.type == calamity.ItemType("EnchantedAxe")
                    || item.type == calamity.ItemType("Glaive") || item.type == calamity.ItemType("Kylie")
                    || item.type == calamity.ItemType("SandDollar") || item.type == calamity.ItemType("SeashellBoomerang")
                    || item.type == calamity.ItemType("Shroomerang") || item.type == calamity.ItemType("BlazingStar")
                    || item.type == calamity.ItemType("Brimblade") || item.type == calamity.ItemType("DefectiveSphere")
                    || item.type == calamity.ItemType("EpidemicShredder") || item.type == calamity.ItemType("Equanimity")
                    || item.type == calamity.ItemType("SubductionSlicer")
                    || item.type == calamity.ItemType("FrostcrushValari") || item.type == calamity.ItemType("Icebreaker")
                    || item.type == calamity.ItemType("KelvinCatalyst") || item.type == calamity.ItemType("MangroveChakram")
                    || item.type == calamity.ItemType("TerraDisk")
                    || item.type == calamity.ItemType("Celestus") || item.type == calamity.ItemType("ElementalDisk")
                    || item.type == calamity.ItemType("Eradicator") || item.type == calamity.ItemType("GalaxySmasher")
                    || item.type == calamity.ItemType("GhoulishGouger") || item.type == calamity.ItemType("MoltenAmputator")
                    || item.type == calamity.ItemType("NanoblackReaper") || item.type == calamity.ItemType("StellarContempt")
                    || item.type == calamity.ItemType("ToxicantTwister") || item.type == calamity.ItemType("Valediction")
                    || item.type == calamity.ItemType("AshenStalactite") || item.type == calamity.ItemType("Cinquedea")
                    || item.type == calamity.ItemType("Crystalline") || item.type == calamity.ItemType("FeatherKnife")
                    || item.type == calamity.ItemType("GelDart") || item.type == calamity.ItemType("GildedDagger")
                    || item.type == calamity.ItemType("GleamingDagger") || item.type == calamity.ItemType("InfernalKris")
                    || item.type == calamity.ItemType("Mycoroot") || item.type == calamity.ItemType("ShinobiBlade")
                    || item.type == calamity.ItemType("WulfrumKnife") || item.type == calamity.ItemType("CobaltKunai")
                    || item.type == calamity.ItemType("CorpusAvertor") || item.type == calamity.ItemType("CursedDagger")
                    || item.type == calamity.ItemType("LeviathanTeeth") || item.type == calamity.ItemType("Malachite")
                    || item.type == calamity.ItemType("MonkeyDarts") || item.type == calamity.ItemType("MythrilKnife")
                    || item.type == calamity.ItemType("OrichalcumSpikedGemstone") || item.type == calamity.ItemType("Prismalline")
                    || item.type == calamity.ItemType("Quasar") || item.type == calamity.ItemType("RadiantStar")
                    || item.type == calamity.ItemType("StellarKnife") || item.type == calamity.ItemType("StormfrontRazor")
                    || item.type == calamity.ItemType("CosmicKunai") || item.type == calamity.ItemType("DeificThunderbolt")
                    || item.type == calamity.ItemType("EmpyreanKnives") || item.type == calamity.ItemType("IllustrousKnives")
                    || item.type == calamity.ItemType("JawsOfOblivion") || item.type == calamity.ItemType("LunarKunai")
                    || item.type == calamity.ItemType("ShatteredSun") || item.type == calamity.ItemType("TarragonThrowingDart")
                    || item.type == calamity.ItemType("TimeBolt") || item.type == calamity.ItemType("UtensilPoker")
                    || item.type == calamity.ItemType("WulfrumKnife") || item.type == calamity.ItemType("CrystalPiercer")
                    || item.type == calamity.ItemType("DuneHopper") || item.type == calamity.ItemType("EclipsesFall")
                    || item.type == calamity.ItemType("IchorSpear") || item.type == calamity.ItemType("InfernalSpear")
                    || item.type == calamity.ItemType("LuminousStriker") || item.type == calamity.ItemType("NightsGaze")
                    || item.type == calamity.ItemType("PalladiumJavelin") || item.type == calamity.ItemType("PhantasmalRuin")
                    || item.type == calamity.ItemType("PhantomLance") || item.type == calamity.ItemType("ProfanedPartisan")
                    || item.type == calamity.ItemType("ScarletDevil") || item.type == calamity.ItemType("ScourgeoftheCosmos")
                    || item.type == calamity.ItemType("ScourgeoftheDesert") || item.type == calamity.ItemType("ScourgeoftheSeas")
                    || item.type == calamity.ItemType("SpearofDestiny") || item.type == calamity.ItemType("SpearofPaleolith")
                    || item.type == calamity.ItemType("Turbulance") || item.type == calamity.ItemType("XerocPitchfork")
                ) {
                    if (item.melee) item.damage = item.damage * 3 / 4;
                    item.melee = false;
                    item.magic = false;
                    item.ranged = false;
                    item.summon = false;
                    item.thrown = true;
                }
                if (item.type == calamity.ItemType("FallenPaladinsHammer") || item.type == calamity.ItemType("PwnageHammer")
                    || item.type == calamity.ItemType("TriactisTruePaladinianMageHammerofMight") || item.type == calamity.ItemType("GalaxySmasher")
                    || item.type == calamity.ItemType("StellarContempt")
                ) {
                    item.melee = true;
                    item.magic = false;
                    item.ranged = false;
                    item.summon = false;
                    item.thrown = false;
                    modItem.chemical = false;
                }
                if (ItemEdits.IsModItem(item) && item.modItem != null && item.type == calamity.ItemType(item.modItem.Name)) JobHooks.ApplyClassAssigns(item);
                if (item.type == calamity.ItemType("AstralScythe") || item.type == calamity.ItemType("SoulHarvester")
                    || item.type == calamity.ItemType("EssenceFlayer") || item.type == calamity.ItemType("LifeHuntScythe")
                    || item.type == calamity.ItemType("SubductionSlicer") || item.type == calamity.ItemType("NanoblackReaper")
                    || item.type == calamity.ItemType("Celestus") || item.type == calamity.ItemType("GhoulishGouger")
                    || item.type == calamity.ItemType("MoltenAmputator") || item.type == calamity.ItemType("SlickCane")
                    || item.type == calamity.ItemType("CelestialReaper") || item.type == calamity.ItemType("EnchantedAxe")
                    || item.type == calamity.ItemType("Icebreaker") || item.type == calamity.ItemType("DukesDecapitator")
                    || item.type == calamity.ItemType("TheReaper") || item.type == calamity.ItemType("BloodsoakedCrasher")
                    || item.type == calamity.ItemType("AdamantiteThrowingAxe")
                ) {
                    modItem.chemistItem = false;
                } 
                if (calamityDefaultRogueDI[item.type] && hasRogueDamage(item) == false && (item.thrown || item.melee)) calamityAvailableRogueItem[item.type] = true;
            }
        }

        public static void UpdateEquip(Item item, Player player)
        {
            if (calamityItem(item) != null && PlayerSupport.calamityPlayer(player) != null)
            {
                ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
                PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();

            }
        }

        public static void UpdateInventory(Item item)
        {
            if (calamityItem(item) != null)
            {
                if (calamityDefaultRogueDI[item.type] == true && calamityAvailableRogueItem[item.type] == false)
                    item.active = false;
                if (item.type == calamity.ItemType("AccretionDiskMelee") || item.type == calamity.ItemType("CorpusAvertorMelee")
                    || item.type == calamity.ItemType("FlameScytheMelee") || item.type == calamity.ItemType("GalaxySmasherMelee")
                    || item.type == calamity.ItemType("KelvinCatalystMelee") || item.type == calamity.ItemType("MangroveChakramMelee")
                    || item.type == calamity.ItemType("NanoblackReaperMelee") || item.type == calamity.ItemType("PwnagehammerMelee")
                    || item.type == calamity.ItemType("RoyalKnivesMelee") || item.type == calamity.ItemType("SeashellBoomerangMelee")
                    || item.type == calamity.ItemType("TerraDiskMelee") || item.type == calamity.ItemType("TruePaladinsHammerMelee")
                    || item.type == calamity.ItemType("TriactisTruePaladinianMageHammerofMightMelee")
                )
                {
                    item.active = false;
                }
            }
        }

        public static void PostUpdate(Item item)
        {
            if (calamityItem(item) != null)
            {
                if(calamityDefaultRogueDI[item.type] == true && calamityAvailableRogueItem[item.type] == false)
                    item.active = false;
                if(item.type == calamity.ItemType("AccretionDiskMelee") || item.type == calamity.ItemType("CorpusAvertorMelee")
                    || item.type == calamity.ItemType("FlameScytheMelee") || item.type == calamity.ItemType("GalaxySmasherMelee")
                    || item.type == calamity.ItemType("KelvinCatalystMelee") || item.type == calamity.ItemType("MangroveChakramMelee")
                    || item.type == calamity.ItemType("NanoblackReaperMelee") || item.type == calamity.ItemType("PwnagehammerMelee")
                    || item.type == calamity.ItemType("RoyalKnivesMelee") || item.type == calamity.ItemType("SeashellBoomerangMelee")
                    || item.type == calamity.ItemType("TerraDiskMelee") || item.type == calamity.ItemType("TruePaladinsHammerMelee")
                    || item.type == calamity.ItemType("TriactisTruePaladinianMageHammerofMightMelee")
                ) {
                    item.active = false;
                }
            }
        }
    }
}
