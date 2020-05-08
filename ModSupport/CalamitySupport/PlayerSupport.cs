using System;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.ModSupport.CalamitySupport
{
    public class PlayerSupport
    {
        internal static Mod calamity = Calamity.instance;
        public PlayerSupport() { }

        internal static ModPlayer calamityPlayerMaster()
        {
            if(Calamity.exists)
            {
                return calamity.GetPlayer("CalamityPlayer");
            }
            return null;
        }
        
        public static ModPlayer calamityPlayer(Player player)
        {
            if (calamityPlayerMaster() != null)
            {
                return player.GetModPlayer(calamity, "CalamityPlayer");
            }
            return null;
        }

        public class throwingDamage
        {
            public throwingDamage() { }
            private static FieldInfo field(Player player) => calamityPlayer(player).GetType().GetField("throwingDamage", BindingFlags.Public | BindingFlags.Instance);
            public static float GetValue(Player player) => (float)field(player).GetValue(calamityPlayer(player));
            public static void SetValue(Player player, float value) { field(player).SetValue(calamityPlayer(player), value); }
        }

        public class throwingVelocity
        {
            public throwingVelocity() { }
            private static FieldInfo field(Player player) => calamityPlayer(player).GetType().GetField("throwingVelocity", BindingFlags.Public | BindingFlags.Instance);
            public static float GetValue(Player player) => (float)field(player).GetValue(calamityPlayer(player));
            public static void SetValue(Player player, float value) { field(player).SetValue(calamityPlayer(player), value); }
        }

        public class throwingCrit
        {
            public throwingCrit() { }
            private static FieldInfo field(Player player) => calamityPlayer(player).GetType().GetField("throwingCrit", BindingFlags.Public | BindingFlags.Instance);
            public static int GetValue(Player player) => (int)field(player).GetValue(calamityPlayer(player));
            public static void SetValue(Player player, int value) { field(player).SetValue(calamityPlayer(player), value); }
        }

        public class gloveOfPrecision
        {
            public gloveOfPrecision() { }
            private static FieldInfo field(Player player) => calamityPlayer(player).GetType().GetField("GloveOfPrecision", BindingFlags.Public | BindingFlags.Instance);
            public static bool GetValue(Player player) => (bool)field(player).GetValue(calamityPlayer(player));
            public static void SetValue(Player player, bool value) { field(player).SetValue(calamityPlayer(player), value); }
        }

        public class gloveOfRecklessness
        {
            public gloveOfRecklessness() { }
            private static FieldInfo field(Player player) => calamityPlayer(player).GetType().GetField("GloveOfRecklessness", BindingFlags.Public | BindingFlags.Instance);
            public static bool GetValue(Player player) => (bool)field(player).GetValue(calamityPlayer(player));
            public static void SetValue(Player player, bool value) { field(player).SetValue(calamityPlayer(player), value); }
        }

        public static void ResetEffects(Player player)
        {
            if(calamityPlayer(player) != null)
            {
                throwingDamage.SetValue(player, 0f);
                throwingVelocity.SetValue(player, 0f);
                throwingCrit.SetValue(player, 0);
            }
        }

        public static void PostUpdateBuffs(Player player)
        {
            if(calamityPlayer(player) != null)
            {
                player.thrownDamage += throwingDamage.GetValue(player) - 1f;
                player.thrownVelocity += throwingVelocity.GetValue(player) - 1f;
                player.thrownCrit += throwingCrit.GetValue(player) / 2;
                player.meleeDamage += (throwingDamage.GetValue(player) - 1f) / 2;
                player.meleeSpeed += throwingDamage.GetValue(player) - 1f;
                player.meleeCrit += throwingCrit.GetValue(player);
                throwingDamage.SetValue(player, 0f);
                throwingVelocity.SetValue(player, 0f);
                throwingCrit.SetValue(player, 0);
            }
        }
    }
}
