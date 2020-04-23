using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using ClassOverhaul.UI;
using ClassOverhaul.Jobs;
using ClassOverhaul.ModSupport;
using Terraria.DataStructures;

namespace ClassOverhaul
{
    public class PlayerEdits : ModPlayer
    {
        public float chemicalDamage = 1f;
        public float chemicalDamageMult = 1f;
        public float usedMinionSlots = 0f;
        public int magicDefense = 0;
        public bool defeatedWoF = false;
        public bool choseJob = false;
        public bool gellyfishArmor;
        public int itemCool;
        public int job;
        public int armorJob;
        public int stunTimer;
        public int knockbackTimer;
        public bool immune;
        public bool rogueBonus;
        public bool stunned;

        public override void ResetEffects()
        {
            base.ResetEffects();
            chemicalDamage = 1f;
            chemicalDamageMult = 1f;
            player.armorPenetration = 0;
            magicDefense = 0;
            armorJob = 0;
            rogueBonus = false;
            gellyfishArmor = false;
            stunned = false;
            PlayerMethods.ResetEffects(player);
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"choseJob", choseJob },
                {"job", job },
                {"armorJob", armorJob },
                {"defeatedWoF", defeatedWoF},
                {"immune", immune},
                {"rogueBonus", rogueBonus }
            };
        }

        public override void Load(TagCompound tag)
        {
            base.Load(tag);
            choseJob = tag.GetBool("choseJob");
            job = tag.GetInt("job");
            armorJob = tag.GetInt("armorJob");
            defeatedWoF = tag.GetBool("defeatedWoF");
            rogueBonus = tag.GetBool("rogueBonus");
        }

        public override void PreUpdate()
        {
            base.PreUpdate();
            if (job == JobID.rogue || armorJob == JobID.rogue) player.dash = 1;
            if (player.longInvince && player.immuneTime > 30) player.immuneTime = 30;
            if (!player.longInvince && player.immuneTime > 15) player.immuneTime = 15;
        }

        public override void PostUpdate()
        {
            base.PostUpdate();
            PlayerMethods.PostUpdate(player);
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if (player.whoAmI == Main.myPlayer)
            {
                if (modPlayer.defeatedWoF && !modPlayer.choseJob)
                {
                    modPlayer.immune = true;
                    JobSelectionUI.visible = true;
                }
            }
        }

        public override void PreUpdateBuffs()
        {
            base.PreUpdateBuffs();
            int index;
            if (player.HasBuff(BuffID.PotionSickness))
            {
               index = player.FindBuffIndex(BuffID.PotionSickness);
               if (player.pStone && player.buffTime[index] > 900) player.buffTime[index] /= 2;
                else if(player.buffTime[index] > 1800) player.buffTime[index] /= 1800;
            }
            if (player.HasBuff(BuffID.ManaSickness))
            {
                index = player.FindBuffIndex(BuffID.ManaSickness);
                if (player.HasBuff(mod.BuffType("RangedManaSickness")))
                {
                    int index2 = player.FindBuffIndex(mod.BuffType("RangedManaSickness"));
                    player.buffTime[index2] = player.buffTime[index];
                } else {
                    player.AddBuff(mod.BuffType("RangedManaSickness"), player.buffTime[index]);
                }
            }
        }

        public override void PostUpdateBuffs()
        {
            base.PostUpdateBuffs();
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if (modPlayer.immune == true)
            {
                player.controlJump = false;
                player.controlDown = false;
                player.controlLeft = false;
                player.controlRight = false;
                player.controlUp = false;
                player.controlUseItem = false;
                player.controlUseTile = false;
                player.controlThrow = false;
                player.gravDir = 0f;
            }
            if (modPlayer.stunned == true)
            {
                player.controlJump = false;
                player.controlDown = false;
                player.controlLeft = false;
                player.controlRight = false;
                player.controlUp = false;
                player.controlUseItem = false;
                player.controlUseTile = false;
                player.controlThrow = false;
            }
            if (modPlayer.stunTimer > 0 && modPlayer.stunned == false) modPlayer.stunTimer--;
            if (modPlayer.knockbackTimer > 0) { modPlayer.knockbackTimer--; player.noKnockback = true; }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (proj.thrown == true)
            {
                if (player.meleeEnchant > 0)
                {
                    if (player.meleeEnchant == 1)
                    {
                        target.AddBuff(70, 60 * Main.rand.Next(5, 10), false);
                    }
                    if (player.meleeEnchant == 2)
                    {
                        target.AddBuff(39, 60 * Main.rand.Next(3, 7), false);
                    }
                    if (player.meleeEnchant == 3)
                    {
                        target.AddBuff(24, 60 * Main.rand.Next(3, 7), false);
                    }
                    if (player.meleeEnchant == 5)
                    {
                        target.AddBuff(69, 60 * Main.rand.Next(10, 20), false);
                    }
                    if (player.meleeEnchant == 6)
                    {
                        target.AddBuff(31, 60 * Main.rand.Next(1, 4), false);
                    }
                    if (player.meleeEnchant == 8)
                    {
                        target.AddBuff(20, 60 * Main.rand.Next(5, 10), false);
                    }
                    if (player.meleeEnchant == 4)
                    {
                        target.AddBuff(72, 120, false);
                    }
                }
                if (player.frostBurn)
                {
                    target.AddBuff(44, 60 * Main.rand.Next(5, 15), false);
                }
                if (player.magmaStone)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        target.AddBuff(24, 360, false);
                    }
                    else if (Main.rand.Next(2) == 0)
                    {
                        target.AddBuff(24, 240, false);
                    }
                    else
                    {
                        target.AddBuff(24, 120, false);
                    }
                }
            }
            base.OnHitNPCWithProj(proj, target, damage, knockback, crit);
        }

        public override void OnHitPvpWithProj(Projectile proj, Player target, int damage, bool crit)
        {
            if (proj.thrown == true)
            {
                if (player.meleeEnchant > 0)
                {
                    if (player.meleeEnchant == 1)
                    {
                        target.AddBuff(70, 60 * Main.rand.Next(5, 10), false);
                    }
                    if (player.meleeEnchant == 2)
                    {
                        target.AddBuff(39, 60 * Main.rand.Next(3, 7), false);
                    }
                    if (player.meleeEnchant == 3)
                    {
                        target.AddBuff(24, 60 * Main.rand.Next(3, 7), false);
                    }
                    if (player.meleeEnchant == 5)
                    {
                        target.AddBuff(69, 60 * Main.rand.Next(10, 20), false);
                    }
                    if (player.meleeEnchant == 6)
                    {
                        target.AddBuff(31, 60 * Main.rand.Next(1, 4), false);
                    }
                    if (player.meleeEnchant == 8)
                    {
                        target.AddBuff(20, 60 * Main.rand.Next(5, 10), false);
                    }
                    if (player.meleeEnchant == 4)
                    {
                        target.AddBuff(72, 120, false);
                    }
                }
                if (player.frostBurn)
                {
                    target.AddBuff(44, 60 * Main.rand.Next(5, 15), false);
                }
                if (player.magmaStone)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        target.AddBuff(24, 360, false);
                    }
                    else if (Main.rand.Next(2) == 0)
                    {
                        target.AddBuff(24, 240, false);
                    }
                    else
                    {
                        target.AddBuff(24, 120, false);
                    }
                }
            }
            base.OnHitPvpWithProj(proj, target, damage, crit);
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            base.Hurt(pvp, quiet, damage, hitDirection, crit);
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if (modPlayer.stunned == false && modPlayer.stunTimer <= 0) player.AddBuff(mod.BuffType("Stun"), 30, true);
            if (modPlayer.knockbackTimer <= 0) modPlayer.knockbackTimer = 90;
        }

        public override bool CanHitPvp(Item item, Player target)
        {
            PlayerEdits modTarget = target.GetModPlayer<PlayerEdits>();
            if (modTarget.immune) return false;
            return base.CanHitPvp(item, target);
        }

        public override bool CanBeHitByNPC(NPC npc, ref int cooldownSlot)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (immune) return false;
            if (modNPC.atkCooldown > 0) return false; 
            return base.CanBeHitByNPC(npc, ref cooldownSlot);
        }

        public override bool CanBeHitByProjectile(Projectile proj)
        {
            if (immune) return false;
            return base.CanBeHitByProjectile(proj);
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (gellyfishArmor)
            {
                player.ApplyDamageToNPC(npc, (int)((1 + (player.statDefense / 2)) * player.minionDamage), 5f, npc.direction * -1, false);
            }
            base.OnHitByNPC(npc, damage, crit);
        }

        public override void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit)
        {
            base.ModifyHitPvp(item, target, ref damage, ref crit);
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            PlayerEdits modTarget = target.GetModPlayer<PlayerEdits>();
            if (item.magic || modItem.chemical)
            {
                if (Main.expertMode)
                {
                    damage += target.statDefense * 3 / 4;
                    if (item.magic) damage -= modTarget.magicDefense * 3 / 4;
                    if (modItem.chemical) damage -= modTarget.magicDefense * 3 / 8 - target.statDefense * 3 / 8;
                }
                else
                {
                    damage += target.statDefense / 2;
                    if (item.magic) damage -= modTarget.magicDefense / 2;
                    if (modItem.chemical) damage -= modTarget.magicDefense / 4 - target.statDefense / 4;
                }
            }
        }

        public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit)
        {
            ProjectileEdits modProjectile = proj.GetGlobalProjectile<ProjectileEdits>();
            PlayerEdits modTarget = player.GetModPlayer<PlayerEdits>();
            if (proj.magic || modProjectile.chemical)
            {
                if (Main.expertMode)
                {
                    damage += player.statDefense * 3 / 4;
                    if (proj.magic) damage -= modTarget.magicDefense * 3 / 4;
                    if (modProjectile.chemical) damage -= modTarget.magicDefense * 3 / 8 - player.statDefense * 3 / 8;
                }
                else
                {
                    damage += player.statDefense / 2;
                    if (proj.magic) damage -= modTarget.magicDefense / 2;
                    if (modProjectile.chemical) damage -= modTarget.magicDefense / 4 - player.statDefense / 4;
                }
            }
            base.ModifyHitByProjectile(proj, ref damage, ref crit);
        }
    }
}
