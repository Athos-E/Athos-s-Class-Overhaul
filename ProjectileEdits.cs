using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

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
                projectile.magic = false;
                projectile.thrown = true;
            }
        }
        public override void AI(Projectile projectile)
        {
            base.AI(projectile);
            Player owner = Main.player[projectile.owner];
            if (projectile.owner == Main.myPlayer)
            {
                if (projectile.thrown && owner.meleeEnchant > 0)
                {
                    if (owner.meleeEnchant == 1)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            int num438 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 171, 0f, 0f, 100, default(Color), 1f);
                            Main.dust[num438].noGravity = true;
                            Main.dust[num438].fadeIn = 1.5f;
                            Dust obj26 = Main.dust[num438];
                            obj26.velocity *= 0.25f;
                        }
                    }
                    else if (owner.meleeEnchant == 2)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            int num437 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 2.5f);
                            Main.dust[num437].noGravity = true;
                            Dust obj27 = Main.dust[num437];
                            obj27.velocity *= 0.7f;
                            Dust expr_E2EE_cp_0 = Main.dust[num437];
                            expr_E2EE_cp_0.velocity.Y = expr_E2EE_cp_0.velocity.Y - 0.5f;
                        }
                    }
                    else if (owner.meleeEnchant == 3)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            int num435 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 2.5f);
                            Main.dust[num435].noGravity = true;
                            Dust obj28 = Main.dust[num435];
                            obj28.velocity *= 0.7f;
                            Dust expr_E3D4_cp_0 = Main.dust[num435];
                            expr_E3D4_cp_0.velocity.Y = expr_E3D4_cp_0.velocity.Y - 0.5f;
                        }
                    }
                    else if (owner.meleeEnchant == 4)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            int num432 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 1.1f);
                            Main.dust[num432].noGravity = true;
                            Dust expr_E4A1_cp_0 = Main.dust[num432];
                            expr_E4A1_cp_0.velocity.X = expr_E4A1_cp_0.velocity.X / 2f;
                            Dust expr_E4C1_cp_0 = Main.dust[num432];
                            expr_E4C1_cp_0.velocity.Y = expr_E4C1_cp_0.velocity.Y / 2f;
                        }
                    }
                    else if (owner.meleeEnchant == 5)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            int num426 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 169, 0f, 0f, 100, default(Color), 1f);
                            Dust expr_E55A_cp_0 = Main.dust[num426];
                            expr_E55A_cp_0.velocity.X = expr_E55A_cp_0.velocity.X + (float)projectile.direction;
                            Dust expr_E57C_cp_0 = Main.dust[num426];
                            expr_E57C_cp_0.velocity.Y = expr_E57C_cp_0.velocity.Y + 0.2f;
                            Main.dust[num426].noGravity = true;
                        }
                    }
                    else if (owner.meleeEnchant == 6)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            int num424 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, 0f, 0f, 100, default(Color), 1f);
                            Dust expr_E625_cp_0 = Main.dust[num424];
                            expr_E625_cp_0.velocity.X = expr_E625_cp_0.velocity.X + (float)projectile.direction;
                            Dust expr_E647_cp_0 = Main.dust[num424];
                            expr_E647_cp_0.velocity.Y = expr_E647_cp_0.velocity.Y + 0.2f;
                            Main.dust[num424].noGravity = true;
                        }
                    }
                    else if (owner.meleeEnchant == 7)
                    {
                        if (Main.rand.Next(20) == 0)
                        {
                            int type16 = Main.rand.Next(139, 143);
                            int num422 = Dust.NewDust(projectile.position, projectile.width, projectile.height, type16, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1.2f);
                            Dust expr_E713_cp_0 = Main.dust[num422];
                            expr_E713_cp_0.velocity.X = expr_E713_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
                            Dust expr_E749_cp_0 = Main.dust[num422];
                            expr_E749_cp_0.velocity.Y = expr_E749_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
                            Dust expr_E77F_cp_0 = Main.dust[num422];
                            expr_E77F_cp_0.velocity.X = expr_E77F_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
                            Dust expr_E7AF_cp_0 = Main.dust[num422];
                            expr_E7AF_cp_0.velocity.Y = expr_E7AF_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
                            Main.dust[num422].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
                        }
                        if (Main.rand.Next(40) == 0)
                        {
                            int type15 = Main.rand.Next(276, 283);
                            int num421 = Gore.NewGore(projectile.position, projectile.velocity, type15, 1f);
                            Gore expr_E86A_cp_0 = Main.gore[num421];
                            expr_E86A_cp_0.velocity.X = expr_E86A_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
                            Gore expr_E8A0_cp_0 = Main.gore[num421];
                            expr_E8A0_cp_0.velocity.Y = expr_E8A0_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
                            Main.gore[num421].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
                            Gore expr_E907_cp_0 = Main.gore[num421];
                            expr_E907_cp_0.velocity.X = expr_E907_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
                            Gore expr_E937_cp_0 = Main.gore[num421];
                            expr_E937_cp_0.velocity.Y = expr_E937_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
                        }
                    }
                    else if (owner.meleeEnchant == 8 && Main.rand.Next(4) == 0)
                    {
                        int num420 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 46, 0f, 0f, 100, default(Color), 1f);
                        Main.dust[num420].noGravity = true;
                        Main.dust[num420].fadeIn = 1.5f;
                        Dust obj29 = Main.dust[num420];
                        obj29.velocity *= 0.25f;
                    }
                }
                if (owner.magmaStone && projectile.thrown && Main.rand.Next(3) != 0)
                {
                    int num419 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 2.5f);
                    Main.dust[num419].noGravity = true;
                    Dust expr_EAE2_cp_0 = Main.dust[num419];
                    expr_EAE2_cp_0.velocity.X = expr_EAE2_cp_0.velocity.X * 2f;
                    Dust expr_EB02_cp_0 = Main.dust[num419];
                    expr_EB02_cp_0.velocity.Y = expr_EB02_cp_0.velocity.Y * 2f;
                }
                if (owner.frostBurn && projectile.thrown && Main.rand.Next(2) == 0)
                {
                    int num440 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 2.5f);
                    Main.dust[num440].noGravity = true;
                    Dust obj25 = Main.dust[num440];
                    obj25.velocity *= 0.7f;
                    Dust expr_E123_cp_0 = Main.dust[num440];
                    expr_E123_cp_0.velocity.Y = expr_E123_cp_0.velocity.Y - 0.5f;
                }
            }
        }
    }
}
