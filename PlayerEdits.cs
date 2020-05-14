using ClassOverhaul.Jobs;
using ClassOverhaul.ModSupport;
using ClassOverhaul.UI;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ClassOverhaul
{
    public class PlayerEdits : ModPlayer
    {
        public float chemicalDamage = 1f;
        public float chemicalDamageMult = 1f;
        public float usedMinionSlots = 0f;
        public int magicDefense;
        public int itemCool;
        public int job;
        public int armorJob;
        public int stunTimer;
        public int knockbackTimer;
        public bool defeatedWoF;
        public bool immune;
        public bool choseJob;
        public bool stunned;
        public bool rogueBonus;
        public bool gellyfishArmor;
        public bool nightSet;
        public bool enInvis;

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
            nightSet = false;
            enInvis = false;
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
            if(job == JobID.rogue || armorJob == JobID.rogue)
                player.dash = 1;
            if(player.longInvince && player.immuneTime > 30)
                player.immuneTime = 30;
            if(!player.longInvince && player.immuneTime > 15)
                player.immuneTime = 15;
        }

        public override void PostUpdate()
        {
            base.PostUpdate();
            if(player.whoAmI == Main.myPlayer)
            {
                if(defeatedWoF && !choseJob)
                {
                    immune = true;
                    JobSelectionUI.visible = true;
                }
            }
        }

        public override void PreUpdateBuffs()
        {
            base.PreUpdateBuffs();
            int index;
            if(player.HasBuff(BuffID.PotionSickness))
            {
                index = player.FindBuffIndex(BuffID.PotionSickness);
                if(player.pStone && player.buffTime[index] > 900)
                    player.buffTime[index] /= 2;
                else if(player.buffTime[index] > 1800)
                    player.buffTime[index] /= 1800;
            }
            if(player.HasBuff(BuffID.ManaSickness))
            {
                index = player.FindBuffIndex(BuffID.ManaSickness);
                if(player.HasBuff(mod.BuffType("RangedManaSickness")))
                {
                    int index2 = player.FindBuffIndex(mod.BuffType("RangedManaSickness"));
                    player.buffTime[index2] = player.buffTime[index];
                }
                else
                {
                    player.AddBuff(mod.BuffType("RangedManaSickness"), player.buffTime[index]);
                }
            }
        }

        public override void PostUpdateBuffs()
        {
            base.PostUpdateBuffs();
            if(immune == true)
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
            if(stunned == true)
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
            if(stunTimer > 0 && stunned == false)
                stunTimer--;
            if(knockbackTimer > 0)
            { knockbackTimer--; player.noKnockback = true; }
            PlayerMethods.PostUpdateBuffs(player);
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if(immune)
                return false;
            if(player.aggro < -250 && enInvis && damageSource.SourceProjectileType == 0)
                return false;
            if(damageSource.SourceNPCIndex < Main.maxNPCs)
            {
                NPCEdits modNPC = Main.npc[damageSource.SourceNPCIndex].GetGlobalNPC<NPCEdits>();
                if(modNPC.atkCooldown > 0)
                    return false;
            }
            if(crit)
                damage /= 2;
            if(damageSource.SourceProjectileType > 0)
            {
                Projectile projectile = Main.projectile[damageSource.SourceProjectileIndex];
                ProjectileEdits modProjectile = projectile.GetGlobalProjectile<ProjectileEdits>();
                if(projectile.magic || modProjectile.chemical)
                {
                    if(Main.expertMode)
                    {
                        damage += player.statDefense * 3 / 4;
                        if(projectile.owner < 255)
                            if(Main.player[projectile.owner].armorPenetration > 0)
                                damage -= Main.player[projectile.owner].armorPenetration;
                        if(projectile.magic)
                            damage -= magicDefense * 3 / 4;
                        if(modProjectile.chemical)
                            damage -= magicDefense * 3 / 8 - player.statDefense * 3 / 8;
                    }
                    else
                    {
                        damage += player.statDefense / 2;
                        if(projectile.magic)
                            damage -= magicDefense / 2;
                        if(modProjectile.chemical)
                            damage -= magicDefense / 4 - player.statDefense / 4;
                    }
                }
            }
            if(pvp && damageSource.SourceItemType > 0 && Main.player[damageSource.SourcePlayerIndex] != null)
            {
                Player sourcePlayer = Main.player[damageSource.SourcePlayerIndex];
                Item item = sourcePlayer.HeldItem;
                if(damageSource.SourceItemType == item.type)
                {
                    ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
                    if(item.magic || modItem.chemical)
                    {
                        if(sourcePlayer.armorPenetration > 0)
                            damage -= player.armorPenetration;
                        if(Main.expertMode)
                        {
                            damage += player.statDefense * 3 / 4;
                            if(item.magic)
                                damage -= magicDefense * 3 / 4;
                            if(modItem.chemical)
                                damage -= magicDefense * 3 / 8 - player.statDefense * 3 / 8;
                        }
                        else
                        {
                            damage += player.statDefense / 2;
                            if(item.magic)
                                damage -= magicDefense / 2;
                            if(modItem.chemical)
                                damage -= magicDefense / 4 - player.statDefense / 4;
                        }
                    }
                }
            }
            if(crit)
                damage *= 2;
            if(gellyfishArmor)
            {
                if(damageSource.SourceNPCIndex < Main.maxNPCs)
                {
                    NPC npc = Main.npc[damageSource.SourceNPCIndex];
                    player.ApplyDamageToNPC(npc, (int)((1 + (player.statDefense / 2)) * player.minionDamage), 5f, npc.direction * -1, false);
                }
                else if(damageSource.SourcePlayerIndex < Main.maxPlayers)
                {
                    Player sourcePlayer = Main.player[damageSource.SourcePlayerIndex];
                    PlayerDeathReason reason = new PlayerDeathReason();
                    reason.SourcePlayerIndex = player.whoAmI;
                    reason.SourceCustomReason = Language.GetTextValue("Mods.ClassOverhaul.CommonName.Gellyfish");
                    sourcePlayer.Hurt(reason, (int)((1 + (player.statDefense / 2)) * player.minionDamage), player.direction * -1, true, false, false);
                }
            }
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if(player.HasBuff(mod.BuffType("EnhancedInvisibility")) && quiet == false)
            {
                int index = player.FindBuffIndex(mod.BuffType("EnhancedInvibility"));
                player.DelBuff(index);
            }
            if(stunned == false && stunTimer <= 0)
                player.AddBuff(mod.BuffType("Stun"), 30, true);
            if(knockbackTimer <= 0)
                knockbackTimer = 90;
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if(proj.thrown == true)
            {
                if(player.meleeEnchant > 0)
                {
                    if(player.meleeEnchant == 1)
                    {
                        target.AddBuff(70, 60 * Main.rand.Next(5, 10), false);
                    }
                    if(player.meleeEnchant == 2)
                    {
                        target.AddBuff(39, 60 * Main.rand.Next(3, 7), false);
                    }
                    if(player.meleeEnchant == 3)
                    {
                        target.AddBuff(24, 60 * Main.rand.Next(3, 7), false);
                    }
                    if(player.meleeEnchant == 5)
                    {
                        target.AddBuff(69, 60 * Main.rand.Next(10, 20), false);
                    }
                    if(player.meleeEnchant == 6)
                    {
                        target.AddBuff(31, 60 * Main.rand.Next(1, 4), false);
                    }
                    if(player.meleeEnchant == 8)
                    {
                        target.AddBuff(20, 60 * Main.rand.Next(5, 10), false);
                    }
                    if(player.meleeEnchant == 4)
                    {
                        target.AddBuff(72, 120, false);
                    }
                }
                if(player.frostBurn)
                {
                    target.AddBuff(44, 60 * Main.rand.Next(5, 15), false);
                }
                if(player.magmaStone)
                {
                    if(Main.rand.Next(4) == 0)
                    {
                        target.AddBuff(24, 360, false);
                    }
                    else if(Main.rand.Next(2) == 0)
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
            if(proj.thrown == true)
            {
                if(player.meleeEnchant > 0)
                {
                    if(player.meleeEnchant == 1)
                    {
                        target.AddBuff(70, 60 * Main.rand.Next(5, 10), false);
                    }
                    if(player.meleeEnchant == 2)
                    {
                        target.AddBuff(39, 60 * Main.rand.Next(3, 7), false);
                    }
                    if(player.meleeEnchant == 3)
                    {
                        target.AddBuff(24, 60 * Main.rand.Next(3, 7), false);
                    }
                    if(player.meleeEnchant == 5)
                    {
                        target.AddBuff(69, 60 * Main.rand.Next(10, 20), false);
                    }
                    if(player.meleeEnchant == 6)
                    {
                        target.AddBuff(31, 60 * Main.rand.Next(1, 4), false);
                    }
                    if(player.meleeEnchant == 8)
                    {
                        target.AddBuff(20, 60 * Main.rand.Next(5, 10), false);
                    }
                    if(player.meleeEnchant == 4)
                    {
                        target.AddBuff(72, 120, false);
                    }
                }
                if(player.frostBurn)
                {
                    target.AddBuff(44, 60 * Main.rand.Next(5, 15), false);
                }
                if(player.magmaStone)
                {
                    if(Main.rand.Next(4) == 0)
                    {
                        target.AddBuff(24, 360, false);
                    }
                    else if(Main.rand.Next(2) == 0)
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
    }
}
