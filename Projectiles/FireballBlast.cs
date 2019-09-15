using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ClassOverhaul.Projectiles
{
    public class FireballBlast : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball Blast");
        }
        public override void SetDefaults()
        {
            projectile.aiStyle = 50;
            aiType = ProjectileID.InfernoFriendlyBlast;
            projectile.width = 150;
            projectile.height = 150;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 20;
        }
        public void StatusNPC(int i)
        {
            Main.npc[i].AddBuff(24, 60 * Main.rand.Next(8, 16), false);
        }
        public void StatusPVP(int i)
        {
            Main.player[i].AddBuff(24, 60 * Main.rand.Next(8, 16), true);
        }
    }
}