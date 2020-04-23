using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.ModSupport
{
    public class ProjectileMethods
    {
        public ProjectileMethods() { }

        public static void SetDefaults(Projectile projectile)
        {
            if (ConsolariaSupport.Consolaria.exists)
            {
                ConsolariaSupport.ProjectileSupport.SetDefaults(projectile);
            }
            //if (CalamitySupport.Calamity.exists)
            //{
            //    CalamitySupport.ProjectileSupport.SetDefaults(projectile);
            //}
        }
        public static void AI(Projectile projectile)
        {
            if (ConsolariaSupport.Consolaria.exists)
            {
                ConsolariaSupport.ProjectileSupport.AI(projectile);
            }
        }
        public static void Kill(Projectile projectile)
        {
            if (ConsolariaSupport.Consolaria.exists)
            {
                ConsolariaSupport.ProjectileSupport.Kill(projectile);
            }
        }
    }
}
