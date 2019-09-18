using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClassOverhaul.Minions
{
    public class Imp : MinionBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            npc.width = 32;
            npc.height = 32;
            npc.lifeMax = 300;
            npc.life = 300;
            modNPC.inertia = 30f;
            modNPC.shootSpeed = 10f;
            modNPC.idleAccel = 10f;
            modNPC.spacingMult = 1f;
            modNPC.viewDist = 300f;       //minion view Distance
            modNPC.chaseDist = 200f;       //how far the minion can go
            modNPC.chaseAccel = 20f;
            modNPC.shootCool = 80f;       //how fast the minion can shoot
            modNPC.shoot = ProjectileID.ImpFireball;
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.25f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
            npc.spriteDirection = npc.direction;
        }

        public override void CreateDust()
        {
            if (npc.frameCounter % 2 == 0)
            {
                int num45 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 6, 0f, 0f, 100, default(Color), 2f);
                Dust obj2 = Main.dust[num45];
                obj2.velocity *= 0.3f;
                Main.dust[num45].noGravity = true;
                Main.dust[num45].noLight = true;
            }
        }

        public override void Behavior()
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            Player player = Main.player[modNPC.owner];
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            float spacing = (float)npc.width * modNPC.spacingMult;
            for (int k = 0; k < 1000; k++)
            {
                Projectile otherProj = Main.projectile[k];
                if (k != npc.whoAmI && otherProj.active && otherProj.owner == modNPC.owner && otherProj.type == npc.type && System.Math.Abs(npc.position.X - otherProj.position.X) + System.Math.Abs(npc.position.Y - otherProj.position.Y) < spacing)
                {
                    if (npc.position.X < Main.projectile[k].position.X)
                    {
                        npc.velocity.X -= modNPC.idleAccel;
                    }
                    else
                    {
                        npc.velocity.X += modNPC.idleAccel;
                    }
                    if (npc.position.Y < Main.projectile[k].position.Y)
                    {
                        npc.velocity.Y -= modNPC.idleAccel;
                    }
                    else
                    {
                        npc.velocity.Y += modNPC.idleAccel;
                    }
                }
            }
            Vector2 targetPos = npc.position;
            float targetDist = modNPC.viewDist;
            bool target = false;
            npc.noTileCollide = false;
            for (int k = 0; k < 200; k++)
            {
                NPC othernpc = Main.npc[k];
                if (othernpc.CanBeChasedBy(this, false))
                {
                    float distance = Vector2.Distance(othernpc.Center, npc.Center);
                    if ((distance < targetDist || !target) && Collision.CanHitLine(npc.position, npc.width, npc.height, othernpc.position, othernpc.width, othernpc.height))
                    {
                        targetDist = distance;
                        targetPos = othernpc.Center;
                        target = true;
                    }
                }
            }
            if (Vector2.Distance(player.Center, npc.Center) > (target ? 1000f : 500f))
            {
                npc.ai[0] = 1f;
                npc.netUpdate = true;
            }
            if (npc.ai[0] == 1f)
            {
                npc.noTileCollide = true;
            }
            if (target && npc.ai[0] == 0f)
            {
                Vector2 direction = targetPos - npc.Center;
                if (direction.Length() > modNPC.chaseDist)
                {
                    direction.Normalize();
                    npc.velocity = (npc.velocity * modNPC.inertia + direction * modNPC.chaseAccel) / (modNPC.inertia + 1);
                }
                else
                {
                    npc.velocity *= (float)Math.Pow(0.97, 40.0 / modNPC.inertia);
                }
            }
            else
            {
                if (!Collision.CanHitLine(npc.Center, 1, 1, player.Center, 1, 1))
                {
                    npc.ai[0] = 1f;
                }
                float speed = 6f;
                if (npc.ai[0] == 1f)
                {
                    speed = 15f;
                }
                Vector2 center = npc.Center;
                Vector2 direction = player.Center - center;
                npc.ai[1] = 3600f;
                npc.netUpdate = true;
                int num = 1;
                for (int k = 0; k < npc.whoAmI; k++)
                {
                    if (Main.npc[k].active && Main.npc[k].GetGlobalNPC<NPCEdits>().owner == modNPC.owner && Main.npc[k].type == npc.type)
                    {
                        num++;
                    }
                }
                direction.X -= (float)((10 + num * 40) * player.direction);
                direction.Y -= 70f;
                float distanceTo = direction.Length();
                if (distanceTo > 200f && speed < modNPC.chaseAccel)
                {
                    speed = modNPC.chaseAccel;
                }
                if (distanceTo < 100f && npc.ai[0] == 1f && !Collision.SolidCollision(npc.position, npc.width, npc.height))
                {
                    npc.ai[0] = 0f;
                    npc.netUpdate = true;
                }
                if (distanceTo > 2000f)
                {
                    npc.Center = player.Center;
                }
                if (distanceTo > 48f)
                {
                    direction.Normalize();
                    direction *= speed;
                    float temp = modNPC.inertia / 2f;
                    npc.velocity = (npc.velocity * temp + direction) / (temp + 1);
                }
                else
                {
                    npc.direction = Main.player[modNPC.owner].direction;
                    npc.velocity *= (float)Math.Pow(0.9, 40.0 / modNPC.inertia);
                }
            }
            npc.rotation = npc.velocity.X * 0.05f;
            CreateDust();
            if (npc.velocity.X > 0f)
            {
                npc.spriteDirection = (npc.direction = 1);
            }
            else if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = (npc.direction = -1);
            }
            if (npc.ai[1] > 0f)
            {
                npc.ai[1] += 1f;
                if (Main.rand.Next(3) == 0)
                {
                    npc.ai[1] += 1f;
                }
            }
            if (npc.ai[1] > modNPC.shootCool)
            {
                npc.ai[1] = 0f;
                npc.netUpdate = true;
            }
            if (npc.ai[0] == 0f)
            {
                if (target == true)
                {
                    if ((targetPos - npc.Center).X > 0f)
                    {
                        npc.spriteDirection = (npc.direction = 1);
                    }
                    else if ((targetPos - npc.Center).X < 0f)
                    {
                        npc.spriteDirection = (npc.direction = -1);
                    }
                    if (npc.ai[1] == 0f)
                    {
                        npc.ai[1] = 1f;
                        if (Main.myPlayer == modNPC.owner)
                        {
                            Vector2 shootVel = targetPos - npc.Center;
                            if (shootVel == Vector2.Zero)
                            {
                                shootVel = new Vector2(0f, 1f);
                            }
                            shootVel.Normalize();
                            shootVel *= modNPC.shootSpeed;
                            int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, shootVel.X, shootVel.Y, modNPC.shoot, npc.damage, modNPC.knockback, Main.myPlayer, 0f, 0f);
                            Main.projectile[proj].timeLeft = 300;
                            Main.projectile[proj].netUpdate = true;
                            npc.netUpdate = true;
                        }
                    }
                }
            }
        }
    }
}
