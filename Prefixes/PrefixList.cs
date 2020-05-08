using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ClassOverhaul.Prefixes
{
    public class PrefixList
    {
        public static List<byte> UniversalPrefixes;
        public static List<byte> CommonPrefixes;
        public static List<byte> MeleePrefixes;
        public static List<byte> RangedPrefixes;
        public static List<byte> MagicPrefixes;
        public static List<byte> ManaGunPrefixes;
        public static List<byte> MagicVanillaPrefixes;
        public static List<byte> AccessoryPrefixes;
        private static Mod mod = ClassOverhaul.instance;

        public PrefixList() {
            UniversalPrefixes = UniversalModifiers();
            CommonPrefixes = UniversalModifiers().Concat(CommonModifiers()).ToList();
            MeleePrefixes = CommonPrefixes.Concat(MeleeModifiers()).ToList();
            RangedPrefixes = CommonPrefixes.Concat(RangedModifiers()).ToList();
            var magic = CommonPrefixes.Concat(MagicModifiers()).ToList();
            magic.Remove(mod.PrefixType("COKeen"));
            magic.Remove(mod.PrefixType("COSuperior"));
            magic.Remove(mod.PrefixType("COGodly"));
            magic.Remove(mod.PrefixType("CODemonic"));
            magic.Remove(mod.PrefixType("COZealous"));
            magic.Remove(mod.PrefixType("COAgile"));
            magic.Remove(mod.PrefixType("COMurderous"));
            magic.Remove(mod.PrefixType("CONasty"));
            magic.Remove(mod.PrefixType("COMythical"));
            MagicVanillaPrefixes = magic;
            var magic2 = MagicVanillaPrefixes.ToList();
            magic2.Remove(PrefixID.Keen);
            magic2.Remove(PrefixID.Superior);
            magic2.Remove(PrefixID.Godly);
            magic2.Remove(PrefixID.Demonic);
            magic2.Remove(PrefixID.Zealous);
            magic2.Remove(PrefixID.Agile);
            magic2.Remove(PrefixID.Murderous);
            magic2.Remove(PrefixID.Nasty);
            magic2.Remove(PrefixID.Mythical);
            magic2.Add(mod.PrefixType("COKeen"));
            magic2.Add(mod.PrefixType("COSuperior"));
            magic2.Add(mod.PrefixType("COGodly"));
            magic2.Add(mod.PrefixType("CODemonic"));
            magic2.Add(mod.PrefixType("COZealous"));
            magic2.Add(mod.PrefixType("COAgile"));
            magic2.Add(mod.PrefixType("COMurderous"));
            magic2.Add(mod.PrefixType("CONasty"));
            magic2.Add(mod.PrefixType("COMythical"));
            MagicPrefixes = magic2;
            var manaGun = RangedPrefixes.Concat(MagicVanillaPrefixes).ToList();
            manaGun.Remove(PrefixID.Sighted);
            manaGun.Remove(PrefixID.Rapid);
            manaGun.Remove(PrefixID.Hasty);
            manaGun.Remove(PrefixID.Deadly2);
            manaGun.Remove(PrefixID.Awful);
            manaGun.Remove(PrefixID.Unreal);
            manaGun.Remove(PrefixID.Mystic);
            manaGun.Remove(PrefixID.Masterful);
            manaGun.Remove(PrefixID.Taboo);
            manaGun.Remove(PrefixID.Mythical);
            ManaGunPrefixes = manaGun;
            AccessoryPrefixes = AccessoryModifiers();
        }

        private static List<byte> UniversalModifiers()
        {
            List<byte> result = new List<byte>();
            result.Add(PrefixID.Keen);
            result.Add(PrefixID.Superior);
            result.Add(PrefixID.Forceful);
            result.Add(PrefixID.Broken);
            result.Add(PrefixID.Damaged);
            result.Add(PrefixID.Shoddy);
            result.Add(PrefixID.Hurtful);
            result.Add(PrefixID.Strong);
            result.Add(PrefixID.Unpleasant);
            result.Add(PrefixID.Weak);
            result.Add(PrefixID.Godly);
            result.Add(PrefixID.Demonic);
            result.Add(PrefixID.Zealous);
            for(int i = 0; i < ModPrefix.GetPrefixesInCategory(PrefixCategory.AnyWeapon).Count; i++)
            {
                result.Add(ModPrefix.GetPrefixesInCategory(PrefixCategory.AnyWeapon)[i].Type);
            }
            return result;
        }

        private static List<byte> CommonModifiers()
        {
            List<byte> result = new List<byte>();
            result.Add(PrefixID.Quick);
            result.Add(PrefixID.Deadly);
            result.Add(PrefixID.Agile);
            result.Add(PrefixID.Nimble);
            result.Add(PrefixID.Murderous);
            result.Add(PrefixID.Slow);
            result.Add(PrefixID.Sluggish);
            result.Add(PrefixID.Lazy);
            result.Add(PrefixID.Annoying);
            result.Add(PrefixID.Nasty);
            return result;
        }

        private static List<byte> MeleeModifiers()
        {
            List<byte> result = new List<byte>();
            result.Add(PrefixID.Large);
            result.Add(PrefixID.Massive);
            result.Add(PrefixID.Dangerous);
            result.Add(PrefixID.Savage);
            result.Add(PrefixID.Sharp);
            result.Add(PrefixID.Pointy);
            result.Add(PrefixID.Tiny);
            result.Add(PrefixID.Terrible);
            result.Add(PrefixID.Small);
            result.Add(PrefixID.Dull);
            result.Add(PrefixID.Unhappy);
            result.Add(PrefixID.Bulky);
            result.Add(PrefixID.Shameful);
            result.Add(PrefixID.Heavy);
            result.Add(PrefixID.Light);
            result.Add(PrefixID.Legendary);
            for(int i = 0; i < ModPrefix.GetPrefixesInCategory(PrefixCategory.Melee).Count; i++)
            {
                result.Add(ModPrefix.GetPrefixesInCategory(PrefixCategory.Melee)[i].Type);
            }
            return result;
        }

        private static List<byte> RangedModifiers()
        {
            List<byte> result = new List<byte>();
            result.Add(PrefixID.Sighted);
            result.Add(PrefixID.Rapid);
            result.Add(PrefixID.Hasty);
            result.Add(PrefixID.Intimidating);
            result.Add(PrefixID.Deadly2);
            result.Add(PrefixID.Staunch);
            result.Add(PrefixID.Awful);
            result.Add(PrefixID.Lethargic);
            result.Add(PrefixID.Awkward);
            result.Add(PrefixID.Powerful);
            result.Add(PrefixID.Frenzying);
            result.Add(PrefixID.Unreal);
            for(int i = 0; i < ModPrefix.GetPrefixesInCategory(PrefixCategory.Ranged).Count; i++)
            {
                result.Add(ModPrefix.GetPrefixesInCategory(PrefixCategory.Ranged)[i].Type);
            }
            return result;
        }

        private static List<byte> MagicModifiers()
        {
            List<byte> result = new List<byte>();
            result.Add(PrefixID.Mystic);
            result.Add(PrefixID.Adept);
            result.Add(PrefixID.Masterful);
            result.Add(PrefixID.Inept);
            result.Add(PrefixID.Ignorant);
            result.Add(PrefixID.Deranged);
            result.Add(PrefixID.Intense);
            result.Add(PrefixID.Taboo);
            result.Add(PrefixID.Celestial);
            result.Add(PrefixID.Furious);
            result.Add(PrefixID.Manic);
            result.Add(PrefixID.Mythical);
            for (int i = 0; i < ModPrefix.GetPrefixesInCategory(PrefixCategory.Magic).Count; i++)
            {
                result.Add(ModPrefix.GetPrefixesInCategory(PrefixCategory.Magic)[i].Type);
            }
            return result;
        }

        private static List<byte> AccessoryModifiers()
        {
            List<byte> prefixes = new List<byte>();
            prefixes.Add(PrefixID.Hard);
            prefixes.Add(PrefixID.Guarding);
            prefixes.Add(PrefixID.Armored);
            prefixes.Add(PrefixID.Precise);
            prefixes.Add(PrefixID.Lucky);
            prefixes.Add(PrefixID.Jagged);
            prefixes.Add(PrefixID.Spiked);
            prefixes.Add(PrefixID.Angry);
            prefixes.Add(PrefixID.Menacing);
            prefixes.Add(PrefixID.Brisk);
            prefixes.Add(PrefixID.Fleeting);
            prefixes.Add(PrefixID.Hasty2);
            prefixes.Add(PrefixID.Quick2);
            prefixes.Add(PrefixID.Wild);
            prefixes.Add(PrefixID.Rash);
            prefixes.Add(PrefixID.Intrepid);
            prefixes.Add(PrefixID.Violent);
            prefixes.Add(PrefixID.Arcane);
            for(int i = 0; i < ModPrefix.GetPrefixesInCategory(PrefixCategory.Accessory).Count; i++)
            {
                prefixes.Add(ModPrefix.GetPrefixesInCategory(PrefixCategory.Accessory)[i].Type);
            }
            return prefixes;
        }
    }
}
