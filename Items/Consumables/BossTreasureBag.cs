using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul.Items.Consumables
{
    public class BossTreasureBag : ModItem
    {
        private readonly int bagBossNPC;
        public BossTreasureBag() { }
        public BossTreasureBag(int npcType) { bagBossNPC = npcType; }
        public override int BossBagNPC => bagBossNPC;
        public override bool CloneNewInstances => true;
        public override string Texture => this.SetTexture();

        public string SetTexture()
        {
            if (BossBagNPC > 0)
            {
                string path = "Terraria/Item_";
                switch (BossBagNPC)
                {
                    case NPCID.KingSlime:
                        return path + ItemID.KingSlimeBossBag;
                    case NPCID.EyeofCthulhu:
                        return path + ItemID.EyeOfCthulhuBossBag;
                    case NPCID.EaterofWorldsHead:
                        return path + ItemID.EaterOfWorldsBossBag;
                    case NPCID.BrainofCthulhu:
                        return path + ItemID.BrainOfCthulhuBossBag;
                    case NPCID.QueenBee:
                        return path + ItemID.QueenBeeBossBag;
                    case NPCID.SkeletronHead:
                        return path + ItemID.SkeletronBossBag;
                    case NPCID.WallofFlesh:
                        return path + ItemID.WallOfFleshBossBag;
                    case NPCID.Spazmatism:
                    case NPCID.Retinazer:
                        return path + ItemID.TwinsBossBag;
                    case NPCID.TheDestroyer:
                        return path + ItemID.DestroyerBossBag;
                    case NPCID.SkeletronPrime:
                        return path + ItemID.SkeletronPrimeBossBag;
                    case NPCID.Plantera:
                        return path + ItemID.PlanteraBossBag;
                    case NPCID.Golem:
                        return path + ItemID.GolemBossBag;
                    case NPCID.DukeFishron:
                        return path + ItemID.FishronBossBag;
                    //case NPCID.CultistBoss:
                    case NPCID.MoonLordCore:
                        return path + ItemID.MoonLordBossBag;
                    //case NPCID.DD2DarkMageT3:
                    //case NPCID.DD2OgreT3:
                    case NPCID.DD2Betsy:
                        return path + ItemID.BossBagBetsy;
                    //case NPCID.PirateShip:
                    //case NPCID.MourningWood:
                    //case NPCID.Pumpking:
                    //case NPCID.Everscream:
                    //case NPCID.SantaNK1:
                    //case NPCID.IceQueen:
                    //case NPCID.MartianSaucer:
                }
            }
            return null;
        }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                mod.AddItem("TreasureBag1", new BossTreasureBag(NPCID.KingSlime)); // King Slime
                mod.AddItem("TreasureBag2", new BossTreasureBag(NPCID.EyeofCthulhu)); // Eye of Cthulhu
                mod.AddItem("TreasureBag3", new BossTreasureBag(NPCID.EaterofWorldsHead)); // Eater of Worlds
                mod.AddItem("TreasureBag4", new BossTreasureBag(NPCID.BrainofCthulhu)); // Brain of Cthulhu
                mod.AddItem("TreasureBag5", new BossTreasureBag(NPCID.QueenBee)); // Queen Bee
                mod.AddItem("TreasureBag6", new BossTreasureBag(NPCID.SkeletronHead)); // Skeletron
                mod.AddItem("TreasureBag7", new BossTreasureBag(NPCID.WallofFlesh)); // Wall of Flesh
                mod.AddItem("TreasureBag8", new BossTreasureBag(NPCID.Retinazer)); // The Twins
                mod.AddItem("TreasureBag9", new BossTreasureBag(NPCID.TheDestroyer)); // The Destroyer
                mod.AddItem("TreasureBag10", new BossTreasureBag(NPCID.SkeletronPrime)); // Skeletron Prime
                mod.AddItem("TreasureBag11", new BossTreasureBag(NPCID.Plantera)); // Plantera
                mod.AddItem("TreasureBag12", new BossTreasureBag(NPCID.Golem)); // Golem
                mod.AddItem("TreasureBag13", new BossTreasureBag(NPCID.DukeFishron)); // Duke Fishron
                //mod.AddItem("TreasureBag14", new BossTreasureBag(NPCID.CultistBoss)); // Lunatic Cultist
                mod.AddItem("TreasureBag15", new BossTreasureBag(NPCID.MoonLordCore)); // Moon Lord
                //mod.AddItem("TreasureBag16", new BossTreasureBag(NPCID.DD2DarkMageT3)); // Dark Mage
                //mod.AddItem("TreasureBag17", new BossTreasureBag(NPCID.DD2OgreT3)); // Ogre
                mod.AddItem("TreasureBag18", new BossTreasureBag(NPCID.DD2Betsy)); // Betsy
                //mod.AddItem("TreasureBag19", new BossTreasureBag(NPCID.PirateShip)); // Flying Dutchman
                //mod.AddItem("TreasureBag20", new BossTreasureBag(NPCID.MourningWood)); // Mourning Wood
                //mod.AddItem("TreasureBag21", new BossTreasureBag(NPCID.Pumpking)); // Pumpking
                //mod.AddItem("TreasureBag22", new BossTreasureBag(NPCID.Everscream)); // Everscream
                //mod.AddItem("TreasureBag23", new BossTreasureBag(NPCID.SantaNK1)); // Santa-NK1
                //mod.AddItem("TreasureBag24", new BossTreasureBag(NPCID.IceQueen)); // Ice Queen
                //mod.AddItem("TreasureBag25", new BossTreasureBag(NPCID.MartianSaucer)); // Martian Saucer
            }
            return false;
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = ItemRarityID.White;
            switch (BossBagNPC)
            {
                case NPCID.KingSlime:
                case NPCID.EyeofCthulhu:
                    item.rare = ItemRarityID.Blue;
                    break;
                case NPCID.EaterofWorldsHead:
                case NPCID.BrainofCthulhu:
                case NPCID.QueenBee:
                    item.rare = ItemRarityID.Green;
                    break;
                case NPCID.SkeletronHead:
                    item.rare = ItemRarityID.Orange;
                    break;
                case NPCID.WallofFlesh:
                    item.rare = ItemRarityID.LightRed;
                    break;
                case NPCID.Spazmatism:
                case NPCID.Retinazer:
                case NPCID.TheDestroyer:
                case NPCID.SkeletronPrime:
                    item.rare = ItemRarityID.Pink;
                    break;
                case NPCID.Plantera:
                case NPCID.Golem:
                case NPCID.DukeFishron:
                    item.rare = ItemRarityID.Lime;
                    break;
                //case NPCID.CultistBoss:
                case NPCID.MoonLordCore:
                    item.rare = ItemRarityID.Red;
                    break;
                //case NPCID.DD2DarkMageT3:
                //case NPCID.DD2OgreT3:
                case NPCID.DD2Betsy:
                    item.rare = ItemRarityID.Yellow;
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

        public override bool CanRightClick() => true;

        public override void OpenBossBag(Player player)
        {
            if (Main.hardMode)
                player.TryGettingDevArmor();
            int random;
            switch (BossBagNPC)
            {
                case NPCID.KingSlime:
                    player.QuickSpawnItem(ItemID.Solidifier);
                    player.QuickSpawnItem(ItemID.LesserHealingPotion, Main.rand.Next(5, 16));
                    if (Main.rand.Next(4) == 0) player.QuickSpawnItem(ItemID.SlimySaddle);
                    random = Main.rand.Next(3);
                    if (random == 0) player.QuickSpawnItem(ItemID.NinjaHood);
                    if (random == 1) player.QuickSpawnItem(ItemID.NinjaPants);
                    if (random == 2) player.QuickSpawnItem(ItemID.NinjaShirt);
                    if (Main.rand.Next(3) > 0) player.QuickSpawnItem(ItemID.SlimeGun); else player.QuickSpawnItem(ItemID.SlimeHook);
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.KingSlimeTrophy);
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.KingSlimeMask);
                    break;
                case NPCID.EyeofCthulhu:
                    if (WorldGen.crimson)
                    {
                        player.QuickSpawnItem(ItemID.CrimtaneOre, Main.rand.Next(30, 88));
                        player.QuickSpawnItem(ItemID.CrimsonSeeds, Main.rand.Next(1, 4));
                    }
                    else
                    {
                        player.QuickSpawnItem(ItemID.DemoniteOre, Main.rand.Next(30, 88));
                        player.QuickSpawnItem(ItemID.UnholyArrow, Main.rand.Next(20, 50));
                        player.QuickSpawnItem(ItemID.CorruptSeeds, Main.rand.Next(1, 4));
                    }
                    player.QuickSpawnItem(ItemID.LesserHealingPotion, Main.rand.Next(5, 16));
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.EyeMask);
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.EyeofCthulhuTrophy);
                    if (Main.rand.NextFloat() <= .025f) player.QuickSpawnItem(ItemID.Binoculars);
                    break;
                case NPCID.EaterofWorldsHead:
                    player.QuickSpawnItem(ItemID.ShadowScale, Main.rand.Next(50, 101));
                    player.QuickSpawnItem(ItemID.DemoniteOre, Main.rand.Next(100, 201));
                    player.QuickSpawnItem(ItemID.LesserHealingPotion, Main.rand.Next(5, 16));
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.EaterMask);
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.EaterofWorldsTrophy);
                    if (Main.rand.Next(20) == 0) player.QuickSpawnItem(ItemID.EatersBone);
                    break;
                case NPCID.BrainofCthulhu:
                    player.QuickSpawnItem(ItemID.CrimtaneOre, Main.rand.Next(40, 91));
                    player.QuickSpawnItem(ItemID.LesserHealingPotion, Main.rand.Next(5, 16));
                    player.QuickSpawnItem(ItemID.TissueSample, Main.rand.Next(30, 51));
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.BrainMask);
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.BrainofCthulhuTrophy);
                    if (Main.rand.Next(20) == 0) player.QuickSpawnItem(ItemID.BoneRattle);
                    break;
                case NPCID.QueenBee:
                    player.QuickSpawnItem(ItemID.BottledHoney, Main.rand.Next(5, 16));
                    player.QuickSpawnItem(ItemID.BeeWax, Main.rand.Next(6, 27));
                    if (Main.rand.Next(3) == 0) player.QuickSpawnItem(ItemID.HoneyComb);
                    if (Main.rand.Next(4) < 3) player.QuickSpawnItem(ItemID.Beenade, Main.rand.Next(10, 30));
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.QueenBeeTrophy);
                    if (Main.rand.Next(20) == 0) player.QuickSpawnItem(ItemID.HoneyedGoggles);
                    if (Main.rand.NextFloat() <= .067f) player.QuickSpawnItem(ItemID.Nectar);
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.BeeMask);
                    random = Main.rand.Next(3);
                    switch (random)
                    {
                        case 0:
                            player.QuickSpawnItem(ItemID.BeeGun);
                            break;
                        case 1:
                            player.QuickSpawnItem(ItemID.BeeKeeper);
                            break;
                        case 2:
                            player.QuickSpawnItem(ItemID.BeesKnees);
                            break;
                    }
                    random = Main.rand.Next(9);
                    switch (random)
                    {
                        case 0:
                            player.QuickSpawnItem(ItemID.BeeHat);
                            break;
                        case 1:
                            player.QuickSpawnItem(ItemID.BeeShirt);
                            break;
                        case 2:
                            player.QuickSpawnItem(ItemID.BeePants);
                            break;
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                            player.QuickSpawnItem(ItemID.HiveWand);
                            break;
                    }
                    break;
                case NPCID.SkeletronHead:
                    player.QuickSpawnItem(ItemID.LesserHealingPotion, Main.rand.Next(5, 16));
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.SkeletronTrophy);
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.SkeletronMask);
                    if (Main.rand.NextFloat() <= .1224f) player.QuickSpawnItem(ItemID.SkeletronHand);
                    if (Main.rand.NextFloat() <= .15f) player.QuickSpawnItem(ItemID.BookofSkulls);
                    break;
                case NPCID.WallofFlesh:
                    player.QuickSpawnItem(ItemID.Pwnhammer);
                    player.QuickSpawnItem(ItemID.HealingPotion, Main.rand.Next(5, 16));
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.WallofFleshTrophy);
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.FleshMask);
                    random = Main.rand.Next(8);
                    switch (random)
                    {
                        case 0:
                            player.QuickSpawnItem(ItemID.WarriorEmblem);
                            break;
                        case 1:
                            player.QuickSpawnItem(ItemID.RangerEmblem);
                            break;
                        case 2:
                            player.QuickSpawnItem(ItemID.SorcererEmblem);
                            break;
                        case 3:
                            player.QuickSpawnItem(ItemID.SummonerEmblem);
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            random = Main.rand.Next(3);
                            switch (random)
                            {
                                case 0:
                                    player.QuickSpawnItem(ItemID.BreakerBlade);
                                    break;
                                case 1:
                                    player.QuickSpawnItem(ItemID.ClockworkAssaultRifle);
                                    break;
                                case 2:
                                    player.QuickSpawnItem(ItemID.LaserRifle);
                                    break;
                            }
                            break;
                    }
                    break;
                case NPCID.Retinazer:
                    player.QuickSpawnItem(ItemID.SoulofSight, Main.rand.Next(20, 41));
                    player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 16));
                    player.QuickSpawnItem(ItemID.HallowedBar, Main.rand.Next(15, 31));
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.RetinazerTrophy);
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.SpazmatismTrophy);
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.TwinMask);
                    break;
                case NPCID.TheDestroyer:
                    player.QuickSpawnItem(ItemID.SoulofMight, Main.rand.Next(20, 41));
                    player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 16));
                    player.QuickSpawnItem(ItemID.HallowedBar, Main.rand.Next(15, 31));
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.DestroyerTrophy);
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.DestroyerMask);
                    break;
                case NPCID.SkeletronPrime:
                    player.QuickSpawnItem(ItemID.SoulofFright, Main.rand.Next(20, 41));
                    player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 16));
                    player.QuickSpawnItem(ItemID.HallowedBar, Main.rand.Next(15, 31));
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.SkeletronPrimeTrophy);
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.SkeletronPrimeMask);
                    break;
                case NPCID.Plantera:
                    player.QuickSpawnItem(ItemID.TempleKey);
                    player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 16));
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.ThornHook);
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.PlanteraTrophy);
                    if (Main.rand.Next(4) == 0) player.QuickSpawnItem(ItemID.PygmyStaff);
                    if (Main.rand.Next(20) == 0) player.QuickSpawnItem(ItemID.Seedling);
                    if (Main.rand.Next(50) == 0) player.QuickSpawnItem(ItemID.TheAxe);
                    random = Main.rand.Next(7);
                    switch (random)
                    {
                        case 0:
                            player.QuickSpawnItem(ItemID.GrenadeLauncher);
                            player.QuickSpawnItem(ItemID.RocketI, Main.rand.Next(50, 150));
                            break;
                        case 1:
                            player.QuickSpawnItem(ItemID.VenusMagnum);
                            break;
                        case 2:
                            player.QuickSpawnItem(ItemID.NettleBurst);
                            break;
                        case 3:
                            player.QuickSpawnItem(ItemID.LeafBlower);
                            break;
                        case 4:
                            player.QuickSpawnItem(ItemID.FlowerPow);
                            break;
                        case 5:
                            player.QuickSpawnItem(ItemID.WaspGun);
                            break;
                        case 6:
                            player.QuickSpawnItem(ItemID.Seedler);
                            break;
                    }
                    break;
                case NPCID.Golem:
                    player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 16));
                    player.QuickSpawnItem(ItemID.BeetleHusk, Main.rand.Next(4, 9));
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.GolemTrophy);
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.GolemMask);
                    random = Main.rand.Next(8);
                    switch (random)
                    {
                        case 0:
                            player.QuickSpawnItem(ItemID.Stynger);
                            player.QuickSpawnItem(ItemID.StyngerBolt, Main.rand.Next(60, 100));
                            break;
                        case 1:
                            player.QuickSpawnItem(ItemID.PossessedHatchet);
                            break;
                        case 2:
                            player.QuickSpawnItem(ItemID.SunStone);
                            break;
                        case 3:
                            player.QuickSpawnItem(ItemID.EyeoftheGolem);
                            break;
                        case 4:
                            player.QuickSpawnItem(ItemID.Picksaw);
                            break;
                        case 5:
                            player.QuickSpawnItem(ItemID.HeatRay);
                            break;
                        case 6:
                            player.QuickSpawnItem(ItemID.StaffofEarth);
                            break;
                        case 7:
                            player.QuickSpawnItem(ItemID.GolemFist);
                            break;
                    }
                    break;
                case NPCID.DukeFishron:
                    player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 16));
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.DukeFishronTrophy);
                    if (Main.rand.NextFloat() <= .0666f) player.QuickSpawnItem(ItemID.FishronWings);
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.DukeFishronMask);
                    random = Main.rand.Next(5);
                    switch (random)
                    {
                        case 0:
                            player.QuickSpawnItem(ItemID.BubbleGun);
                            break;
                        case 1:
                            player.QuickSpawnItem(ItemID.Flairon);
                            break;
                        case 2:
                            player.QuickSpawnItem(ItemID.RazorbladeTyphoon);
                            break;
                        case 3:
                            player.QuickSpawnItem(ItemID.TempestStaff);
                            break;
                        case 4:
                            player.QuickSpawnItem(ItemID.Tsunami);
                            break;
                    }
                    break;
                //case NPCID.CultistBoss:
                case NPCID.MoonLordCore:
                    player.QuickSpawnItem(ItemID.PortalGun);
                    player.QuickSpawnItem(ItemID.LunarOre, Main.rand.Next(70, 101));
                    player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 16));
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.MoonLordTrophy);
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.BossMaskMoonlord);
                    random = Main.rand.Next(9);
                    switch (random)
                    {
                        case 0:
                            player.QuickSpawnItem(ItemID.Meowmere);
                            break;
                        case 1:
                            player.QuickSpawnItem(ItemID.Terrarian);
                            break;
                        case 2:
                            player.QuickSpawnItem(ItemID.StarWrath);
                            break;
                        case 3:
                            player.QuickSpawnItem(ItemID.SDMG);
                            break;
                        case 4:
                            player.QuickSpawnItem(ItemID.FireworksLauncher);
                            break;
                        case 5:
                            player.QuickSpawnItem(ItemID.LastPrism);
                            break;
                        case 6:
                            player.QuickSpawnItem(ItemID.LunarFlareBook);
                            break;
                        case 7:
                            player.QuickSpawnItem(ItemID.RainbowCrystalStaff);
                            break;
                        case 8:
                            player.QuickSpawnItem(ItemID.MoonlordTurretStaff);
                            break;
                    }
                    break;
                //case NPCID.DD2DarkMageT3:
                //case NPCID.DD2OgreT3:
                case NPCID.DD2Betsy:
                    if (Main.rand.Next(4) == 0) player.QuickSpawnItem(ItemID.BetsyWings);
                    if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.BossTrophyBetsy);
                    if (Main.rand.NextFloat() <= .1429f) player.QuickSpawnItem(ItemID.BossMaskBetsy);
                    random = Main.rand.Next(4);
                    switch (random)
                    {
                        case 0:
                            player.QuickSpawnItem(ItemID.DD2BetsyBow);
                            break;
                        case 1:
                            player.QuickSpawnItem(ItemID.MonkStaffT3);
                            break;
                        case 2:
                            player.QuickSpawnItem(ItemID.ApprenticeStaffT3);
                            break;
                        case 3:
                            player.QuickSpawnItem(ItemID.DD2SquireBetsySword);
                            break;
                    }
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
