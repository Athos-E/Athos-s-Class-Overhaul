using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClassOverhaul.NPCs
{
    public abstract class MinionBase : ModNPC
    {
        public override bool CloneNewInstances => true;
        public override bool CheckDead() => false;
        public virtual void Behavior() { }

        public override void SetDefaults()
        {
            base.SetDefaults();
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            npc.width = 32;
            npc.height = 32;
            npc.lifeMax = 100;
            npc.life = npc.lifeMax;
            npc.friendlyRegen = 100;
            npc.HitSound = SoundID.NPCHit1;
            npc.noTileCollide = false;
            npc.noGravity = true;
            modNPC.isMinion = true;
            modNPC.inertia = 30f;
            modNPC.idleAccel = 10f;
            modNPC.spacingMult = 1f;
            modNPC.viewDist = 300f;
            modNPC.chaseDist = 200f;
            modNPC.chaseAccel = 20f;

        }

        public override void AI()
        {
            base.AI();
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            Player player = Main.player[modNPC.owner];
            Check(npc);
            //if (player.talkNPC == npc.whoAmI)
            //{
            //    PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            //    modPlayer.usedMinionSlots -= modNPC.minionSlots;
            //    Main.player[modNPC.owner].numMinions--;
            //    npc.active = false;
            //}
            Behavior();
        }

        public void Check(NPC npc)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            Player player = Main.player[modNPC.owner];
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if (IfHoverNPC(npc)) { if (Main.mouseRight && Main.npcChatRelease) npc.life = 0; }
            if (player.dead) npc.life = 0;
            if (npc.life <= 0)
            {
                modPlayer.usedMinionSlots -= modNPC.minionSlots;
                Main.player[modNPC.owner].numMinions--;
                Main.PlaySound(SoundID.NPCDeath1);
                npc.active = false;
            }
        }

        public bool IfHoverNPC(NPC npc)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (!Main.player[Main.myPlayer].dead && Main.myPlayer == modNPC.owner)
            {
                Rectangle rectangle = new Rectangle((int)((float)Main.mouseX + Main.screenPosition.X), (int)((float)Main.mouseY + Main.screenPosition.Y), 1, 1);
                bool flag5;
                bool flag4;
                if (npc.active)
                {
                    flag5 = rectangle.Intersects(npc.getRect());
                    flag4 = (flag5 || (Main.SmartInteractShowingGenuine && Main.SmartInteractNPC == npc.whoAmI));
                    if (flag4)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int Shoot(Vector2 velocity)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            int proj = Projectile.NewProjectile(npc.position, velocity, modNPC.shoot, npc.damage, modNPC.knockback, modNPC.owner);
            ProjectileEdits modProjectile = Main.projectile[proj].GetGlobalProjectile<ProjectileEdits>();
            modProjectile.minionProjectile = true;
            modProjectile.minionOwner = npc.whoAmI;
            return proj;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (!target.hostile) return false;
            if (modNPC.owner < Main.maxPlayers && modNPC.owner == target.whoAmI) return false; 
            return base.CanHitPlayer(target, ref cooldownSlot);
        }

        public override bool? CanHitNPC(NPC target)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            NPCEdits modTarget = target.GetGlobalNPC<NPCEdits>();
            if (modTarget.isMinion)
            {
                if (modNPC.owner < Main.maxPlayers && modNPC.owner == modTarget.owner) return false;
                if (modNPC.owner < Main.maxPlayers && !Main.player[modNPC.owner].hostile) return false;
                if (modNPC.owner < Main.maxPlayers && !Main.player[modTarget.owner].hostile) return false;
            }
            if (target.friendly) return false;
            return base.CanHitNPC(target);
        }

        public override bool? CanBeHitByItem(Player player, Item item)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (Main.player[modNPC.owner] == player) return false;
            if (!player.hostile) return false;
            return base.CanBeHitByItem(player, item);
        }

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            ProjectileEdits modProjectile = projectile.GetGlobalProjectile<ProjectileEdits>();
            if (projectile.owner < Main.maxPlayers && projectile.owner == modNPC.owner) return false;
            if (modProjectile.minionProjectile && modProjectile.minionOwner == npc.whoAmI) return false;
            if (modProjectile.minionProjectile && !Main.player[projectile.owner].hostile) return false;
            return base.CanBeHitByProjectile(projectile);
        }
    }
}
