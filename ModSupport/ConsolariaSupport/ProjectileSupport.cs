using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul.ModSupport.ConsolariaSupport
{
    public class ProjectileSupport
    {
        public ProjectileSupport() { }
        public static void SetDefaults(Projectile projectile)
        {
            if (projectile.modProjectile != null) {
                Mod consolaria = Consolaria.instance;
                if (projectile.type == consolaria.ProjectileType("SpectralArrowPro"))
                {
                    projectile.modProjectile.aiType = ProjectileID.Bullet;
                    projectile.arrow = true;
                    projectile.alpha = 127;
                }
            }
        }
        public static void AI(Projectile projectile)
        {
            if (projectile.modProjectile != null)
            {
                Mod consolaria = Consolaria.instance;
                if (projectile.type == consolaria.ProjectileType("SpectralArrowPro"))
                {
                    projectile.alpha = 127;
                    
                }
            }
        }
        public static void Kill(Projectile projectile)
        {
            if (projectile.modProjectile != null)
            {
                Mod consolaria = Consolaria.instance;
                if (projectile.owner == Main.myPlayer && projectile.type == consolaria.ProjectileType("SpectralArrowPro"))
                {
                    int item =
                    Main.rand.NextBool(3)
                        ? Item.NewItem(projectile.getRect(), consolaria.ItemType("SpectralArrow"))
                        : 0;
                    if (Main.netMode == NetmodeID.MultiplayerClient && item >= 0)
                    {
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
                    }
                }
            }
        }
    }
}
