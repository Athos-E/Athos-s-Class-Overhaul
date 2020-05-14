using ClassOverhaul.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClassOverhaul
{
    public class NPCEdits : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
        public int magicDefense = 0;
        public int atkCooldown = 0;
        public int atkSpeed = 30;
        public int defaultAtkSpeed = 30;
        public bool isMinion;
        public bool firstUpdate;
        public bool stunned;
        public int owner = -1;
        public int minionNum;
        public int minionPos;
        public int shoot;
        public int stunTimer;
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
            if (npc.type == NPCID.Zombie)
            {
                npc.defense = 500;
                npc.lifeMax = 500000;
                npc.life = npc.lifeMax;
            }
        }

        public override bool PreAI(NPC npc)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (modNPC.stunTimer > 0 && modNPC.stunned == false) { stunTimer--; }
            if (modNPC.atkCooldown > 0) atkCooldown -= 1;
            if (modNPC.atkCooldown < 0) atkCooldown = 0;
            for (int col = 0; col < npc.immune.Length; col++) if (npc.immune[col] > 15) npc.immune[col] = 15;
            if (modNPC.stunned == true) return false;
            return base.PreAI(npc);
        }

        public override void PostAI(NPC npc)
        {
            base.PostAI(npc);
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            for (int col = 0; col < npc.immune.Length; col++) if (npc.immune[col] > 15) npc.immune[col] = 15;
        }

        public override bool PreNPCLoot(NPC npc)
        {
            //NPCLoader.blockLoot.Add(ItemID.ToxicFlask);
            if (Main.expertMode == false && (npc.type == NPCID.KingSlime
                || npc.type == NPCID.EyeofCthulhu || npc.type == NPCID.EaterofWorldsHead
                || npc.type == NPCID.BrainofCthulhu || npc.type == NPCID.QueenBee
                || npc.type == NPCID.SkeletronHead || npc.type == NPCID.WallofFlesh
                || npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism
                || npc.type == NPCID.TheDestroyer || npc.type == NPCID.SkeletronPrime
                || npc.type == NPCID.Plantera || npc.type == NPCID.Golem
                || npc.type == NPCID.DukeFishron || npc.type == NPCID.MoonLordCore
                || npc.type == NPCID.DD2Betsy
                )) {
                for(int id = 0; id < ItemID.Count; id++)
                {
                    NPCLoader.blockLoot.Add(id);
                }
            }
            return base.PreNPCLoot(npc);
        }

        public override void NPCLoot(NPC npc)
        {
            base.NPCLoot(npc);
            if(npc.type == NPCID.Hellhound && Main.rand.Next(2) == 0)
            {
                Item.NewItem(npc.position, mod.ItemType("EvilScales"), Main.rand.Next(2, 7));
            }
            if (npc.type == NPCID.HeadlessHorseman && Main.rand.Next(2) == 0)
            {
                Item.NewItem(npc.position, mod.ItemType("EvilScales"), Main.rand.Next(4, 9));
            }
            if (npc.type == NPCID.Pumpking)
            {
                Item.NewItem(npc.position, mod.ItemType("EvilScales"), Main.rand.Next(8,17));
            }
            if (Main.expertMode == false && npc.boss)
            {
                for (int p = 0; p < Main.player.Length; p++)
                {
                    if (Main.player[p].active && npc.playerInteraction[p])
                    {
                        switch (npc.type)
                        {
                            case NPCID.KingSlime:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag1"));
                                break;
                            case NPCID.EyeofCthulhu:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag2"));
                                break;
                            case NPCID.EaterofWorldsHead:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag3"));
                                break;
                            case NPCID.BrainofCthulhu:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag4"));
                                break;
                            case NPCID.QueenBee:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag5"));
                                break;
                            case NPCID.SkeletronHead:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag6"));
                                break;
                            case NPCID.WallofFlesh:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag7"));
                                break;
                            case NPCID.Spazmatism:
                                for (int id = 0; id <= Main.npc.Length; id++)
                                {
                                    if (Main.npc[id].type == NPCID.Retinazer && Main.npc[id].active)
                                    {
                                        break;
                                    }
                                    if (id == Main.npc.Length) Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag8"));
                                }
                                break;
                            case NPCID.Retinazer:
                                for (int id = 0; id <= Main.npc.Length; id++)
                                {
                                    if (Main.npc[id].type == NPCID.Spazmatism && Main.npc[id].active)
                                    {
                                        break;
                                    }
                                    if (id == Main.npc.Length) Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag8"));
                                }
                                break;
                            case NPCID.TheDestroyer:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag9"));
                                break;
                            case NPCID.SkeletronPrime:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag10"));
                                break;
                            case NPCID.Plantera:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag11"));
                                break;
                            case NPCID.Golem:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag12"));
                                break;
                            case NPCID.DukeFishron:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag13"));
                                break;
                            //case NPCID.CultistBoss:
                            case NPCID.MoonLordCore:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag15"));
                                break;
                            //case NPCID.DD2DarkMageT3:
                            //case NPCID.DD2OgreT3:
                            case NPCID.DD2Betsy:
                                Main.player[p].QuickSpawnItem(mod.ItemType("TreasureBag18"));
                                break;
                            //case NPCID.PirateShip:
                            //case NPCID.MourningWood:
                            //case NPCID.Pumpking:
                            //case NPCID.Everscream:
                            //case NPCID.SantaNK1:
                            //case NPCID.IceQueen:
                            //case NPCID.MartianSaucer:
                        }
                    }
                }
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
            modNPC.stunned = false;
        }

        public override bool CheckDead(NPC npc)
        {
            if (base.CheckDead(npc))
            {
                PlayerEdits modPlayer = Main.player[Main.myPlayer].GetModPlayer<PlayerEdits>();
                if (npc.type == NPCID.WallofFlesh && modPlayer.defeatedWoF == false)
                {
                    modPlayer.defeatedWoF = true;
                }
            }
            return base.CheckDead(npc);
        }

        public override void HitEffect(NPC npc, int hitDirection, double damage)
        {
            base.HitEffect(npc, hitDirection, damage);
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (npc.boss == false && modNPC.stunned == false && modNPC.stunTimer <= 0) { npc.AddBuff(mod.BuffType("Stun"), 30, true); }
        }

        public override bool? CanHitNPC(NPC npc, NPC target)
        {
            NPCEdits modTarget = target.GetGlobalNPC<NPCEdits>();
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (modNPC.atkCooldown > 0) return false;
            if (modNPC.stunned) return false;
            return base.CanHitNPC(npc, target);
        }

        public override bool CanHitPlayer(NPC npc, Player target, ref int cooldownSlot)
        {
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (modNPC.atkCooldown > 0) return false;
            if (modNPC.stunned) return false;
            return base.CanHitPlayer(npc, target, ref cooldownSlot);
        }

        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (item.magic || modItem.chemical)
            {
                damage += npc.defense / 2;
                if (item.magic) damage -= modNPC.magicDefense / 2;
                if (modItem.chemical) damage -= modNPC.magicDefense / 4 - npc.defense / 4;
            }
            base.ModifyHitByItem(npc, player, item, ref damage, ref knockback, ref crit);
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            ProjectileEdits modProjectile = projectile.GetGlobalProjectile<ProjectileEdits>();
            NPCEdits modNPC = npc.GetGlobalNPC<NPCEdits>();
            if (projectile.magic || modProjectile.chemical)
            {
                damage += npc.defense / 2;
                if (projectile.magic) damage -= modNPC.magicDefense / 2;
                if (modProjectile.chemical) damage -= modNPC.magicDefense / 4 - npc.defense / 4;
            }
            base.ModifyHitByProjectile(npc, projectile, ref damage, ref knockback, ref crit, ref hitDirection);
        }
    }
}
