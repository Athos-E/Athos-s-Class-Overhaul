using System;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.ModSupport.CalamitySupport
{
    public class ProjectileSupport
    {
        internal static Mod calamity = Calamity.instance;
        public ProjectileSupport() { }

        public static GlobalProjectile calamityProjectileMaster()
        {
            if(Calamity.exists)
            {
                return calamity.GetGlobalProjectile("CalamityGlobalProjectile");
            }
            return null;
        }

        public static GlobalProjectile calamityProjectile(Projectile projectile)
        {
            if(calamityProjectileMaster() != null)
            {
                return calamityProjectileMaster().Instance(projectile);
            }
            return null;
        }

        public static FieldInfo[] calamityProjectileInfo(Projectile projectile)
        {
            FieldInfo stealthStrike = calamityProjectile(projectile).GetType().GetField("stealthStrike", BindingFlags.Public | BindingFlags.Instance);
            return new FieldInfo[] { stealthStrike };
        }

        public static void SetDefaults(Projectile projectile)
        {
            if(calamityProjectile(projectile) != null)
            {
                FieldInfo rogue = calamityProjectile(projectile).GetType().GetField("rogue", BindingFlags.Public | BindingFlags.Instance);
                if ((bool)rogue.GetValue(calamityProjectile(projectile)) == true)
                {
                    rogue.SetValue(calamityProjectile(projectile), (bool)false);
                    projectile.thrown = true;
                }
            }
        }
    }
}
