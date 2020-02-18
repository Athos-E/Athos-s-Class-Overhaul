using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using ClassOverhaul.UI;
using Terraria.DataStructures;

namespace ClassOverhaul
{
    public class PlayerEdits : ModPlayer
    {
        public float chemicalDamage = 1f;
        public float usedMinionSlots = 0f;
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
            player.armorPenetration = 0;
            armorJob = 0;
            rogueBonus = false;
            gellyfishArmor = false;
            stunned = false;
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
            if (job == JobID.rogue) player.dash = 1;
        }
        public override void PostUpdate()
        {
            base.PostUpdate();
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if (player.whoAmI == Main.myPlayer)
            {
                if (modPlayer.defeatedWoF && !modPlayer.choseJob)
                {
                    modPlayer.immune = true;
                    JobSelection.visible = true;
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
        public bool CanEquip(Item item, Player player)
        {
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if (modItem.blocked == true) return false;
            if (modItem.isBasic == true) return true;
            if (modPlayer.choseJob == true)
            {
                switch (modPlayer.job)
                {
                    case JobID.knight:
                        if (modPlayer.armorJob == JobID.summoner)
                        {
                            if (modItem.knightItem ^ item.melee ^ item.summon) return true;
                        }
                        else
                        {
                            if (modItem.knightItem ^ item.melee) return true;
                        }
                        break;
                    case JobID.rogue:
                        if (modPlayer.armorJob == JobID.summoner)
                        {
                            if (modItem.rogueItem ^ item.thrown ^ item.melee ^ item.summon) return true;
                        }
                        else
                        {
                            if (modItem.rogueItem ^ item.thrown ^ item.melee) return true;
                        }
                        break;
                    case JobID.ranger:
                        if (modPlayer.armorJob == JobID.summoner)
                        {
                            if (modItem.rangerItem ^ item.ranged ^ item.summon) return true;
                        }
                        else
                        {
                            if (modItem.rangerItem ^ item.ranged) return true;
                        }
                        break;
                    case JobID.mage:
                        if (modPlayer.armorJob == JobID.summoner)
                        {
                            if (modItem.mageItem ^ item.magic ^ item.summon) return true;
                        }
                        else
                        {
                            if (modItem.mageItem ^ item.magic) return true;
                        }
                        break;
                    case JobID.summoner:
                        switch (modPlayer.armorJob)
                        {
                            case 0:
                                if (modItem.summonerItem ^ item.summon) return true;
                                break;
                            case JobID.knight:
                                if (modItem.summonerItem ^ item.summon ^ item.melee) return true;
                                break;
                            case JobID.rogue:
                                if (modItem.summonerItem ^ item.summon ^ item.thrown) return true;
                                break;
                            case JobID.ranger:
                                if (modItem.summonerItem ^ item.summon ^ item.ranged) return true;
                                break;
                            case JobID.mage:
                                if (modItem.summonerItem ^ item.summon ^ item.magic) return true;
                                break;
                            case JobID.chemist:
                                if (modItem.summonerItem ^ item.summon ^ modItem.chemical) return true;
                                break;
                        }
                        if (modItem.summonerItem ^ item.summon) return true;
                        break;
                    case JobID.chemist:
                        if (modPlayer.armorJob == JobID.summoner)
                        {
                            if (modItem.chemistItem ^ item.thrown ^ modItem.chemical ^ item.summon) return true;
                        }
                        else
                        {
                            if (modItem.chemistItem ^ item.thrown ^ modItem.chemical) return true;
                        }
                        break;
                }
            }
            return modItem.preHardmode;
        }
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            base.Hurt(pvp, quiet, damage, hitDirection, crit);
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if (modPlayer.stunned == false && modPlayer.stunTimer <= 0) player.AddBuff(mod.BuffType("Stun"), 30, true);
            if (modPlayer.knockbackTimer <= 0)
            {
                modPlayer.knockbackTimer = 90;
            }
        }
        public override bool CanBeHitByNPC(NPC npc, ref int cooldownSlot)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (immune == true) return false;
            if (modNPC.atkCooldown > 0) return false;
            else if (modNPC.atkCooldown == 0)
            {
                if (npc.friendly == true) return false;
                else return true;
            }
            return base.CanBeHitByNPC(npc, ref cooldownSlot);
        }
        public override bool CanBeHitByProjectile(Projectile proj)
        {
            if (immune == true)
            {
                return false;
            }
            return base.CanBeHitByProjectile(proj);
        }
        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (gellyfishArmor)
            {
                player.ApplyDamageToNPC(npc, (int)((1 + (player.statDefense / 2)) * player.minionDamage), 5f, npc.direction * -1, false);
            }
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
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            base.OnHitByNPC(npc, damage, crit);
            if (player.longInvince == true)
            {
                player.immune = true;
                player.immuneTime = 45;
            }
            else
            {
                player.immune = true;
                player.immuneTime = 10;
            }
        }
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            base.OnHitByProjectile(proj, damage, crit);
            if (player.longInvince == true)
            {
                player.immune = true;
                player.immuneTime = 45;
            }
            else
            {
                player.immune = true;
                player.immuneTime = 10;
            }
        }
        public override void OnHitPvp(Item item, Player target, int damage, bool crit)
        {
            base.OnHitPvp(item, target, damage, crit);
            if (target.longInvince == true)
            {
                target.immune = true;
                target.immuneTime = 45;
            }
            else
            {
                target.immune = true;
                target.immuneTime = 10;
            }
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            base.ModifyHitNPCWithProj(proj, target, ref damage, ref knockback, ref crit, ref hitDirection);
            target.immune[Main.myPlayer] = 5;
        }
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            base.ModifyHitNPC(item, target, ref damage, ref knockback, ref crit);
            target.immune[Main.myPlayer] = 5;
        }

        public override bool? CanHitNPC(Item item, NPC target)
        {
            NPCEdits modNPC = target.GetGlobalNPC<NPCEdits>();
            if (modNPC.isMinion)
            {
                if (modNPC.owner == Main.myPlayer) return false;
                if (Main.player[modNPC.owner].hostile == false) return false;
            }
            return base.CanHitNPC(item, target);
        }

        public override bool? CanHitNPCWithProj(Projectile proj, NPC target)
        {
            NPCEdits modNPC = target.GetGlobalNPC<NPCEdits>();
            if (modNPC.isMinion)
            {
                if (modNPC.owner == Main.myPlayer) return false;
                if (Main.player[modNPC.owner].hostile == false) return false;
            }
            return base.CanHitNPCWithProj(proj, target);
        }
    }
}
