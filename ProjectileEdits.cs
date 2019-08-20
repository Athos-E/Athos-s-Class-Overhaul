using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ClassOverhaul
{
    public class ProjectileEdits : GlobalProjectile
    {
        public override void SetDefaults(Projectile projectile)
        {
            base.SetDefaults(projectile);
            if (projectile.type == ProjectileID.BeeArrow)
            {
                projectile.ranged = false;
                projectile.minion = true;
                projectile.arrow = false;
            }
            if (projectile.type == ProjectileID.SpectreWrath)
            {
                projectile.magic = false;
                projectile.minion = true;
            }
            if (projectile.type == ProjectileID.Skull)
            {
                projectile.magic = false;
                projectile.minion = true;
            }
            if (projectile.type == ProjectileID.GreenLaser)
            {
                projectile.magic = false;
                projectile.ranged = true;
            }
            if (projectile.type == ProjectileID.HeatRay)
            {
                projectile.magic = false;
                projectile.ranged = true;
            }
            if (projectile.type == ProjectileID.LaserMachinegun)
            {
                projectile.magic = false;
                projectile.ranged = true;
            }
            if (projectile.type == ProjectileID.LaserMachinegunLaser)
            {
                projectile.magic = false;
                projectile.ranged = true;
            }
            if (projectile.type == ProjectileID.ChargedBlasterCannon)
            {
                projectile.magic = false;
                projectile.ranged = true;
            }
            if (projectile.type == ProjectileID.ChargedBlasterLaser)
            {
                projectile.magic = false;
                projectile.ranged = true;
            }
            if (projectile.type == ProjectileID.ChargedBlasterOrb)
            {
                projectile.magic = false;
                projectile.ranged = true;
            }
            if (projectile.type == ProjectileID.Leaf)
            {
                projectile.magic = false;
                projectile.ranged = true;
            }
            if (projectile.type == ProjectileID.PineNeedleFriendly)
            {
                projectile.magic = false;
                projectile.ranged = true;
            }
        }
    }
}
