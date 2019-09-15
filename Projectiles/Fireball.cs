using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClassOverhaul.Projectiles
{
    public class Fireball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.magic = true;
            projectile.tileCollide = true;
        }
        public void StatusNPC(int i)
        {
            Main.npc[i].AddBuff(24, 60 * Main.rand.Next(8, 16), false);
        }
        public void StatusPVP(int i)
        {
            Main.player[i].AddBuff(24, 60 * Main.rand.Next(8, 16), true);
        }
        public override void Kill(int timeLeft)
        {
            Player owner = Main.player[projectile.owner];
            if (owner.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("FireballBlast"), (int)((double)projectile.damage * 0.65), projectile.knockBack, Main.myPlayer, 0f, 0f);
            }
        }

        public override void AI()
        {
            Color newColor5;
            Dust dust81;
            int num2475;
            for (int num1920 = 0; num1920 < 8; num1920 = num2475 + 1)
            {
                Vector2 position143 = new Vector2(projectile.position.X, projectile.position.Y);
                int width112 = projectile.width;
                int height112 = projectile.height;
                newColor5 = default(Color);
                int num1919 = Dust.NewDust(position143, width112, height112, 174, 0f, 0f, 100, newColor5, 1.2f);
                Main.dust[num1919].noGravity = true;
                dust81 = Main.dust[num1919];
                dust81.velocity *= 0.5f;
                dust81 = Main.dust[num1919];
                dust81.velocity += projectile.velocity * 0.1f;
                num2475 = num1920;
            }
        }
    }
}