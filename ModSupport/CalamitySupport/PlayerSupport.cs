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

        public static FieldInfo[] throwingInfo(Player player)
        {
            FieldInfo throwingDamage = calamityPlayer(player).GetType().GetField("throwingDamage", BindingFlags.Public | BindingFlags.Instance);
            FieldInfo throwingVelocity = calamityPlayer(player).GetType().GetField("throwingDamage", BindingFlags.Public | BindingFlags.Instance);
            FieldInfo throwingCrit = calamityPlayer(player).GetType().GetField("throwingDamage", BindingFlags.Public | BindingFlags.Instance);
            return new FieldInfo[] { throwingDamage, throwingVelocity, throwingCrit };
        }

        public static void ResetEffects(Player player)
        {
            if(calamityPlayer(player) != null)
            {
                throwingInfo(player)[0].SetValue(calamityPlayer(player), (float)1f);
                throwingInfo(player)[1].SetValue(calamityPlayer(player), (float)1f);
                throwingInfo(player)[2].SetValue(calamityPlayer(player), (int)0);
            }
        }

        public static void PostUpdate(Player player)
        {
            if(calamityPlayer(player) != null)
            {
                player.thrownDamage += (float)throwingInfo(player)[0].GetValue(calamityPlayer(player)) - 1f;
                player.thrownVelocity += (float)throwingInfo(player)[1].GetValue(calamityPlayer(player)) - 1f;
                player.thrownCrit += (int)throwingInfo(player)[2].GetValue(calamityPlayer(player));
                throwingInfo(player)[0].SetValue(calamityPlayer(player), (float)0f);
                throwingInfo(player)[1].SetValue(calamityPlayer(player), (float)0f);
                throwingInfo(player)[2].SetValue(calamityPlayer(player), (int)0);
            }
        }

        public static void ModifyHitNPCWithProj(Player player, Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if(calamityPlayer(player) != null)
            {
                GlobalProjectile calamityProjectile = ProjectileSupport.calamityProjectile(projectile);
                if((bool)ProjectileSupport.calamityProjectileInfo(projectile)[0].GetValue(calamityProjectile) == true && (projectile.melee || projectile.thrown))
                {
                        
                }
            }
        }
    }
}
