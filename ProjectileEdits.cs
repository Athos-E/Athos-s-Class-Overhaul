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
            if (projectile.type == ProjectileID.SpectreWrath ^ projectile.type == ProjectileID.Skull 
                ^ projectile.type == ProjectileID.Bat ^ projectile.type == ProjectileID.Wasp 
                ^ projectile.type == ProjectileID.Bee ^ projectile.type == ProjectileID.Hellwing
                ^ projectile.type == ProjectileID.MechanicalPiranha)
            {
                projectile.magic = false;
                projectile.ranged = false;
                projectile.minion = true;
            }
            if (projectile.type == ProjectileID.GreenLaser ^ projectile.type == ProjectileID.PurpleLaser
                ^ projectile.type == ProjectileID.HeatRay ^ projectile.type == ProjectileID.LaserMachinegun
                ^ projectile.type == ProjectileID.LaserMachinegunLaser ^ projectile.type == ProjectileID.ChargedBlasterCannon
                ^ projectile.type == ProjectileID.ChargedBlasterLaser ^ projectile.type == ProjectileID.ChargedBlasterOrb
                ^ projectile.type == ProjectileID.Leaf ^ projectile.type == ProjectileID.PineNeedleFriendly)
            {
                projectile.magic = false;
                projectile.ranged = true;
            }
            if (projectile.type == ProjectileID.WoodenBoomerang ^ projectile.type == ProjectileID.EnchantedBoomerang
                ^ projectile.type == ProjectileID.IceBoomerang ^ projectile.type == ProjectileID.FruitcakeChakram ^ projectile.type == ProjectileID.ThornChakram
                ^ projectile.type == ProjectileID.Flamarang ^ projectile.type == ProjectileID.FlyingKnife ^ projectile.type == ProjectileID.LightDisc
                ^ projectile.type == ProjectileID.Bananarang ^ projectile.type == ProjectileID.PossessedHatchet
                ^ projectile.type == ProjectileID.ShadowFlameKnife ^ projectile.type == ProjectileID.EatersBite ^ projectile.type == ProjectileID.TinyEater
                ^ projectile.type == ProjectileID.Daybreak ^ projectile.type == ProjectileID.Anchor ^ projectile.type == ProjectileID.ChainGuillotine 
                ^ projectile.type == ProjectileID.BoxingGlove ^ projectile.type == ProjectileID.GolemFist ^ projectile.type == ProjectileID.WoodYoyo
                ^ projectile.type == ProjectileID.CorruptYoyo ^ projectile.type == ProjectileID.CrimsonYoyo ^ projectile.type == ProjectileID.JungleYoyo
                ^ projectile.type == ProjectileID.Code1 ^ projectile.type == ProjectileID.Valor ^ projectile.type == ProjectileID.Cascade ^ projectile.type == ProjectileID.FormatC
                ^ projectile.type == ProjectileID.Gradient ^ projectile.type == ProjectileID.Chik ^ projectile.type == ProjectileID.HelFire ^ projectile.type == ProjectileID.Amarok
                ^ projectile.type == ProjectileID.Code2 ^ projectile.type == ProjectileID.Yelets ^ projectile.type == ProjectileID.RedsYoyo ^ projectile.type == ProjectileID.ValkyrieYoyo
                ^ projectile.type == ProjectileID.Kraken ^ projectile.type == ProjectileID.TheEyeOfCthulhu ^ projectile.type == ProjectileID.Terrarian)
            {
                projectile.melee = false;
                projectile.thrown = true;
            }
        }
    }
}
