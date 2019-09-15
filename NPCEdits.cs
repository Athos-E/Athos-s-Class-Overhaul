using ClassOverhaul.UI;
using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace ClassOverhaul
{
    public class NPCEdits : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
        public int atkCooldown = 0;
        public int atkSpeed = 30;
        public int defaultAtkSpeed = 30;
        public bool isMinion;
        public int owner = -1;
        public int minionNum;
        public int minionPos;
        public int shoot;
        public float knockback;
        public float minionSlots;
        public float shootSpeed;
        public float idleAccel;
        public float spacingMult;
        public float viewDist;
        public float chaseDist;
        public float chaseAccel;
        public float inertia;
        public float shootCool;

        public override void SetDefaults(NPC npc)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            base.SetDefaults(npc);
            if (npc.type == NPCID.BlueJellyfish)
            {
                npc.catchItem = ItemID.BlueJellyfish;
            }
            if (npc.type == NPCID.PinkJellyfish)
            {
                npc.catchItem = ItemID.PinkJellyfish;
            }
            if (npc.type == NPCID.GreenJellyfish)
            {
                npc.catchItem = ItemID.GreenJellyfish;
            }
            if (modNPC.isMinion)
            {
                npc.friendly = true;
                npc.friendlyRegen = 100;
                npc.HitSound = SoundID.NPCHit1;
            }
        }
        public override void AI(NPC npc)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (modNPC.atkCooldown > 0) atkCooldown -= 1;
            if (modNPC.atkCooldown < 0) atkCooldown = 0;
            if (isMinion == true)
            {
                Check(npc);
                Player player = Main.player[modNPC.owner];
                if (player.talkNPC == npc.whoAmI && modNPC.isMinion == true)
                {
                    PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
                    modPlayer.usedMinionSlots -= modNPC.minionSlots;
                    Main.player[modNPC.owner].numMinions--;
                    Main.PlaySound(SoundID.NPCDeath1);
                    npc.active = false;
                }
            }
            else
            {
                base.AI(npc);
            }
        }

        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            base.OnHitPlayer(npc, target, damage, crit);
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            modNPC.atkCooldown = modNPC.atkSpeed;
        }

        public override void ResetEffects(NPC npc)
        {
            base.ResetEffects(npc);
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            modNPC.atkSpeed = modNPC.defaultAtkSpeed;
        }

        public override bool CheckDead(NPC npc)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (modNPC.isMinion == true) return false;
            if (base.CheckDead(npc))
            {
                if (npc.type == NPCID.WallofFlesh)
                {
                    PlayerEdits modPlayer = Main.player[Main.myPlayer].GetModPlayer<PlayerEdits>();
                    modPlayer.defeatedWoF = true;
                    modPlayer.immune = true;
                    JobSelection.visible = true;
                }
            }
            return base.CheckDead(npc);
        }

        public override bool CheckActive(NPC npc)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (modNPC.isMinion == true) return false;
            return base.CheckActive(npc);
        }

        public void Check(NPC npc)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            Player player = Main.player[modNPC.owner];
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if (player.dead)
            {
                npc.life = 0;
            }
            if (npc.life <= 0)
            {
                modPlayer.usedMinionSlots -= modNPC.minionSlots;
                Main.player[modNPC.owner].numMinions--;
                Main.PlaySound(SoundID.NPCDeath1);
                npc.active = false;
            }
        }

        public override bool? CanHitNPC(NPC npc, NPC target)
        {
            NPCEdits modTarget = target.GetGlobalNPC<NPCEdits>();
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (modNPC.isMinion == true && modTarget.isMinion == true && Main.player[modTarget.owner].hostile == true) return true;
            return base.CanHitNPC(npc, target);
        }
        public override bool? CanBeHitByProjectile(NPC npc, Projectile projectile)
        {
            NPCEdits modNPC = Main.npc[projectile.owner].GetGlobalNPC<NPCEdits>();
            if (projectile.npcProj == true && Main.npc[projectile.owner].friendly == true && modNPC.isMinion == true && Main.player[modNPC.owner].hostile == true && projectile.owner != npc.whoAmI) return true;
            if (projectile.npcProj == true && Main.npc[projectile.owner].friendly == true && modNPC.isMinion == false && projectile.owner != npc.whoAmI) return false;
            return base.CanBeHitByProjectile(npc, projectile);
        }

        public override bool? CanBeHitByItem(NPC npc, Player player, Item item)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            return base.CanBeHitByItem(npc, player, item);
        }

        public override bool CanHitPlayer(NPC npc, Player target, ref int cooldownSlot)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (modNPC.isMinion == true)
            {
                if (Main.player[modNPC.owner] == target) return false;
                if (target.hostile == true && target.immune == false) return true;
            } 
            return base.CanHitPlayer(npc, target, ref cooldownSlot);
        }

        public override bool? CanChat(NPC npc)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (modNPC.isMinion == true && modNPC.owner == Main.myPlayer) return true;
            return base.CanChat(npc);
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (modNPC.isMinion == true && Main.player[modNPC.owner].talkNPC == npc.whoAmI)
            {
                Main.drawingPlayerChat = false;
            }
            else
            {
                base.GetChat(npc, ref chat);
            }
        }
    }
}
