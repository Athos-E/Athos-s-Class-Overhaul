using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul.ModSupport.CalamitySupport
{
    public class RecipeSupport
    {
        internal static Mod calamity = Calamity.instance;
        public RecipeSupport() { }

        public static void UpdateRecipes()
        {
            if (Calamity.exists)
            {
                int[] idList = new int[] { };
                int idListIndex = 0;
                for(int i = 0; i < ItemLoader.ItemCount; i++)
                {
                    if (ItemSupport.calamityDefaultRogueDI[i] == true && ItemSupport.calamityAvailableRogueItem[i] == false) {
                        idList[idListIndex] = i;
                        idListIndex++;
                    } else if(i == calamity.ItemType("AccretionDiskMelee") || i == calamity.ItemType("CorpusAvertorMelee")
                        || i == calamity.ItemType("FlameScytheMelee") || i == calamity.ItemType("GalaxySmasherMelee")
                        || i == calamity.ItemType("KelvinCatalystMelee") || i == calamity.ItemType("MangroveChakramMelee")
                        || i == calamity.ItemType("NanoblackReaperMelee") || i == calamity.ItemType("PwnagehammerMelee")
                        || i == calamity.ItemType("RoyalKnivesMelee") || i == calamity.ItemType("SeashellBoomerangMelee")
                        || i == calamity.ItemType("TerraDiskMelee") || i == calamity.ItemType("TruePaladinsHammerMelee")
                        || i == calamity.ItemType("TriactisTruePaladinianMageHammerofMightMelee")
                    ) {
                        idList[idListIndex] = i;
                        idListIndex++;
                    }
                }
                for (idListIndex = 0; idListIndex < idList.Length; idListIndex++)
                {
                    RecipeFinder finder = new RecipeFinder();
                    finder.SetResult(idList[idListIndex]);
                    foreach(Recipe recipe in finder.SearchRecipes())
                    {
                        RecipeEditor editor = new RecipeEditor(recipe);
                        editor.DeleteRecipe();
                    }
                }
            }
        }
    }
}
