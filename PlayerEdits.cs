﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ClassOverhaul
{
    class PlayerEdits : ModPlayer
    {
        public float chemicalDamage = 1f;
        public bool defeatedWoF = false;
        public bool choseJob = false;
        public bool gellyfishArmor;
        public int job;
        public int armorJob;
        public bool immune;
        public bool managedRecipes;
        public override void ResetEffects()
        {
            base.ResetEffects();
            chemicalDamage = 1f;
            armorJob = 0;
            gellyfishArmor = false;
        }
        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"choseJob", choseJob },
                {"job", job },
                {"armorJob", armorJob },
                {"defeatedWoF", defeatedWoF},
                {"immune", immune }
            };
        }
        public override void Load(TagCompound tag)
        {
            base.Load(tag);
            choseJob = tag.GetBool("choseJob");
            job = tag.GetInt("job");
            defeatedWoF = tag.GetBool("defeatedWoF");
            immune = tag.GetBool("immune");
        }
        public override void PostUpdate()
        {
            base.PostUpdate();
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if (modPlayer.job == JobID.chemist)
            {
                if (modPlayer.managedRecipes == false) {
                    ClassOverhaul.EnableRecipeVanillaItem(mod, ItemID.ToxicFlask, 15, ItemID.Bottle, 15, ItemID.Deathweed, 1, ItemID.VialofVenom, 1, ItemID.Fireblossom, 1, ItemID.ExplosivePowder, 1, TileID.AlchemyTable);
                }
                modPlayer.managedRecipes = true;
            } else
            {
                if (modPlayer.job != JobID.chemist)
                {
                    ClassOverhaul.DisableRecipe(mod, ItemID.ToxicFlask, 15);
                    modPlayer.managedRecipes = false;
                } else
                {
                    modPlayer.managedRecipes = true;
                }
            }
        }
        public override void PostUpdateBuffs()
        {
            base.PostUpdateBuffs();
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if (modPlayer.immune == true)
            {
                Player player = Main.player[Main.myPlayer];
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
        }
        public bool CanEquip(Item item, Player player)
        {
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if (modItem.preHardmode == true)
            {
                return true;
            } else {
                if (modPlayer.choseJob == true)
                {
                    switch (modPlayer.job)
                    {
                        case JobID.knight:
                            if (modPlayer.armorJob == JobID.summoner)
                            {
                                if (modItem.knightItem ^ item.melee ^ item.summon) return true; else return false;
                            }
                            else
                            {
                                if (modItem.knightItem ^ item.melee) return true; else return false;
                            }
                        case JobID.rogue:
                            if (modPlayer.armorJob == JobID.summoner)
                            {
                                if (modItem.rogueItem ^ item.thrown ^ item.melee ^ item.summon) return true; else return false;
                            }
                            else
                            {
                                if (modItem.rogueItem ^ item.thrown ^ item.melee) return true; else return false;
                            }
                        case JobID.ranger:
                            if (modPlayer.armorJob == JobID.summoner)
                            {
                                if (modItem.rangedItem ^ item.ranged ^ item.summon) return true; else return false;
                            }
                            else
                            {
                                if (modItem.rangedItem ^ item.ranged) return true; else return false;
                            }
                        case JobID.mage:
                            if (modPlayer.armorJob == JobID.summoner)
                            {
                                if (modItem.magicItem ^ item.magic ^ item.summon) return true; else return false;
                            }
                            else
                            {
                                if (modItem.magicItem ^ item.magic) return true; else return false;
                            }
                        case JobID.summoner:
                            switch (modPlayer.armorJob)
                            {
                                case 0:
                                    if (modItem.summonerItem ^ item.summon) return true; else return false;
                                case JobID.knight:
                                    if (modItem.summonerItem ^ item.summon ^ modItem.knightItem ^ item.melee) return true; else return false;
                                case JobID.rogue:
                                    if (modItem.summonerItem ^ item.summon ^ modItem.rogueItem ^ item.thrown) return true; else return false;
                                case JobID.ranger:
                                    if (modItem.summonerItem ^ item.summon ^ modItem.rangedItem ^ item.ranged) return true; else return false;
                                case JobID.mage:
                                    if (modItem.summonerItem ^ item.summon ^ modItem.magicItem ^ item.magic) return true; else return false;
                                case JobID.chemist:
                                    if (modItem.summonerItem ^ item.summon ^ modItem.chemistItem ^ modItem.chemical) return true; else return false;
                            }
                            if (modItem.summonerItem ^ item.summon) return true; else return false;
                        case JobID.chemist:
                            if (modPlayer.armorJob == JobID.summoner)
                            {
                                if (modItem.chemistItem ^ item.thrown ^ modItem.chemical ^ item.summon) return true; else return false;
                            }
                            else
                            {
                                if (modItem.chemistItem ^ item.thrown ^ modItem.chemical) return true; else return false;
                            }
                    }
                    return modItem.preHardmode;
                }
                return modItem.preHardmode;
            }
        }
        public override bool CanBeHitByNPC(NPC npc, ref int cooldownSlot)
        {
            if (immune == true)
            {
                return false;
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
            base.OnHitByNPC(npc, damage, crit);
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
    }
}
