using ClassOverhaul.Jobs;
using ClassOverhaul.ModSupport;
using ClassOverhaul.Prefixes;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ClassOverhaul
{
    public class ItemEdits : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
        public bool knightItem = false;
        public bool rogueItem = false;
        public bool rangerItem = false;
        public bool mageItem = false;
        public bool summonerItem = false;
        public bool chemistItem = false;
        public bool preHardmode = false;
        public bool chemical = false;
        public bool extraTooltip = false;
        public bool isBasic = false;
        public bool hasSummon = false;
        public bool blocked = false;
        public int magicDefense;
        public int summonNPC;
        public int summonSlots;
        public int cooldown;

        public ItemEdits() { }

        public static bool IsModItem(Item item) { return item.type >= ItemID.Count; }

        public static bool IsCOItem(Item item) { return IsModItem(item) && item.type == ClassOverhaul.instance.ItemType(item.modItem.Name); }

        public override void SetDefaults(Item item)
        {
            base.SetDefaults(item);
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            if(item.accessory == true) modItem.isBasic = true;
            if(item.axe > 0 || item.pick > 0 || item.hammer > 0) modItem.isBasic = true;
            if(item.melee == false && item.thrown == false && item.ranged == false && item.magic == false && item.summon == false && modItem.chemical == false && item.defense == 0) modItem.isBasic = true;
            if(modItem.chemical == true)
            {
                item.thrown = false;
                item.melee = false;
                item.magic = false;
                item.ranged = false;
                item.summon = false;
                item.crit = 0;
            }
            if(item.rare < 4 || item.type == ItemID.SlimeStaff || item.type == ItemID.FlaskofPoison
                || item.type == ItemID.FlaskofParty || item.type == ItemID.FlaskofFire
                || item.type == ItemID.GoldenBugNet || item.type == ItemID.EoCShield)
            { modItem.preHardmode = true; }
            if(item.type == ItemID.CobaltBreastplate || item.type == ItemID.CobaltLeggings
            || item.type == ItemID.PalladiumBreastplate || item.type == ItemID.PalladiumLeggings
            || item.type == ItemID.MythrilChainmail || item.type == ItemID.MythrilGreaves
            || item.type == ItemID.OrichalcumBreastplate || item.type == ItemID.OrichalcumLeggings
            || item.type == ItemID.AdamantiteBreastplate || item.type == ItemID.AdamantiteLeggings
            || item.type == ItemID.TitaniumBreastplate || item.type == ItemID.TitaniumLeggings
            || item.type == ItemID.HallowedPlateMail || item.type == ItemID.HallowedGreaves
            || item.type == ItemID.ChlorophytePlateMail || item.type == ItemID.ChlorophyteGreaves
            )
            {
                modItem.isBasic = true;
            }
            if(item.type == ItemID.CobaltHelmet || item.type == ItemID.PalladiumMask // Knight sets
                || item.type == ItemID.MythrilHelmet || item.type == ItemID.OrichalcumMask
                || item.type == ItemID.AdamantiteHelmet || item.type == ItemID.TitaniumMask
                || item.type == ItemID.FrostHelmet || item.type == ItemID.FrostBreastplate
                || item.type == ItemID.FrostLeggings || item.type == ItemID.HallowedMask
                || item.type == ItemID.ChlorophyteMask || item.type == ItemID.TurtleHelmet
                || item.type == ItemID.TurtleScaleMail || item.type == ItemID.TurtleLeggings
                || item.type == ItemID.BeetleHelmet || item.type == ItemID.BeetleLeggings
                || item.type == ItemID.BeetleShell
                || item.type == ItemID.SolarFlareHelmet || item.type == ItemID.SolarFlareBreastplate
                || item.type == ItemID.SolarFlareLeggings
                || item.type == ItemID.SquireGreatHelm || item.type == ItemID.SquirePlating
                || item.type == ItemID.SquireGreaves
                || item.type == ItemID.SquireAltHead || item.type == ItemID.SquireAltPants
                || item.type == ItemID.SquireAltShirt
                )
            {
                modItem.knightItem = true;
            }
            if(item.type == ItemID.AnkhShield || item.type == ItemID.PaladinsShield)
            {
                modItem.isBasic = false;
                modItem.knightItem = true;
                item.defense += 4;
            }
            if(item.type == ItemID.PaladinsShield) { item.defense += 2; }
            if(item.type == ItemID.CobaltShield) { item.defense += 3; }
            if(item.type == ItemID.ObsidianShield) { item.defense += 4; }
            if(item.type == ItemID.CobaltMask || item.type == ItemID.PalladiumHelmet // Ranger sets
                || item.type == ItemID.MythrilHat || item.type == ItemID.OrichalcumHelmet
                || item.type == ItemID.AdamantiteMask || item.type == ItemID.TitaniumHelmet
                || item.type == ItemID.FrostHelmet || item.type == ItemID.FrostBreastplate
                || item.type == ItemID.FrostLeggings || item.type == ItemID.HallowedHelmet
                || item.type == ItemID.ChlorophyteHelmet || item.type == ItemID.ShroomiteBreastplate
                || item.type == ItemID.ShroomiteHeadgear || item.type == ItemID.ShroomiteHelmet
                || item.type == ItemID.ShroomiteMask || item.type == ItemID.ShroomiteLeggings
                || item.type == ItemID.VortexBreastplate || item.type == ItemID.VortexHelmet
                || item.type == ItemID.VortexLeggings || item.type == ItemID.HuntressWig
                || item.type == ItemID.HuntressJerkin || item.type == ItemID.HuntressPants
                || item.type == ItemID.HuntressAltHead || item.type == ItemID.HuntressAltPants
                || item.type == ItemID.HuntressAltShirt
                )
            {
                modItem.rangerItem = true;
            }
            if(item.type == ItemID.SpaceGun || item.type == ItemID.LaserRifle || item.type == ItemID.LeafBlower
            || item.type == ItemID.HeatRay || item.type == ItemID.LaserMachinegun
            || item.type == ItemID.ChargedBlasterCannon || item.type == ItemID.Razorpine
            )
            {
                item.magic = false;
                item.ranged = true;
                item.autoReuse = true;
            }
            if(item.type == ItemID.CobaltHat || item.type == ItemID.PalladiumHeadgear // Mage sets
                || item.type == ItemID.MythrilHood || item.type == ItemID.OrichalcumHeadgear
                || item.type == ItemID.AdamantiteHeadgear || item.type == ItemID.TitaniumHeadgear
                || item.type == ItemID.AncientBattleArmorHat || item.type == ItemID.AncientBattleArmorShirt
                || item.type == ItemID.AncientBattleArmorPants || item.type == ItemID.HallowedHeadgear
                || item.type == ItemID.ChlorophyteHeadgear || item.type == ItemID.SpectreHood
                || item.type == ItemID.SpectreMask || item.type == ItemID.SpectreRobe
                || item.type == ItemID.SpectrePants || item.type == ItemID.NebulaBreastplate
                || item.type == ItemID.NebulaHelmet || item.type == ItemID.NebulaLeggings
                || item.type == ItemID.ApprenticeHat || item.type == ItemID.ApprenticeRobe
                || item.type == ItemID.ApprenticeTrousers || item.type == ItemID.ApprenticeAltHead
                || item.type == ItemID.ApprenticeAltPants || item.type == ItemID.ApprenticeAltShirt
                )
            {
                modItem.mageItem = true;
            }
            if(item.type == ItemID.SpiderMask || item.type == ItemID.SpiderBreastplate // Summoner sets
            || item.type == ItemID.SpiderGreaves || item.type == ItemID.AncientBattleArmorHat
            || item.type == ItemID.AncientArmorPants || item.type == ItemID.AncientArmorShirt
            || item.type == ItemID.TikiMask || item.type == ItemID.TikiPants
            || item.type == ItemID.TikiShirt || item.type == ItemID.SpookyHelmet
            || item.type == ItemID.SpookyBreastplate || item.type == ItemID.SpookyLeggings
            || item.type == ItemID.StardustBreastplate || item.type == ItemID.StardustHelmet
            || item.type == ItemID.StardustLeggings || item.type == ItemID.ApprenticeHat
            || item.type == ItemID.ApprenticeRobe || item.type == ItemID.ApprenticeTrousers
            || item.type == ItemID.SquireGreatHelm || item.type == ItemID.SquirePlating
            || item.type == ItemID.SquireGreaves || item.type == ItemID.HuntressWig
            || item.type == ItemID.HuntressJerkin || item.type == ItemID.HuntressPants
            || item.type == ItemID.MonkBrows || item.type == ItemID.MonkShirt
            || item.type == ItemID.MonkPants || item.type == ItemID.ApprenticeAltHead
            || item.type == ItemID.ApprenticeAltPants || item.type == ItemID.ApprenticeAltShirt
            || item.type == ItemID.HuntressAltHead || item.type == ItemID.HuntressAltPants
            || item.type == ItemID.HuntressAltShirt || item.type == ItemID.MonkAltHead
            || item.type == ItemID.MonkAltPants || item.type == ItemID.MonkAltShirt
            || item.type == ItemID.SquireAltHead || item.type == ItemID.SquireAltPants
            || item.type == ItemID.SquireAltShirt
            )
            {
                modItem.summonerItem = true;
            }
            if(item.type == ItemID.BeesKnees || item.type == ItemID.BeeGun
            || item.type == ItemID.WaspGun || item.type == ItemID.SpectreStaff
            || item.type == ItemID.BatScepter || item.type == ItemID.BookofSkulls
            || item.type == ItemID.HellwingBow || item.type == ItemID.PiranhaGun
            || item.type == ItemID.ScourgeoftheCorruptor
            )
            {
                item.ranged = false;
                item.melee = false;
                item.magic = false;
                item.summon = true;
            }
            if(item.type == ItemID.BeetleScaleMail || item.type == ItemID.BeetleHelmet //Rogue sets
                || item.type == ItemID.BeetleLeggings || item.type == ItemID.FrostHelmet
                || item.type == ItemID.FrostBreastplate || item.type == ItemID.FrostLeggings
                || item.type == ItemID.MonkBrows || item.type == ItemID.MonkShirt
                || item.type == ItemID.MonkPants || item.type == ItemID.MonkAltHead
                || item.type == ItemID.MonkAltPants || item.type == ItemID.MonkAltShirt
                )
            {
                modItem.rogueItem = true;
            }
            if(item.type == ItemID.WoodenBoomerang || item.type == ItemID.EnchantedBoomerang
                || item.type == ItemID.IceBoomerang || item.type == ItemID.FruitcakeChakram
                || item.type == ItemID.ThornChakram || item.type == ItemID.Flamarang
                || item.type == ItemID.FlyingKnife || item.type == ItemID.LightDisc
                || item.type == ItemID.Bananarang || item.type == ItemID.PossessedHatchet
                || item.type == ItemID.ShadowFlameKnife || item.type == ItemID.VampireKnives
                || item.type == ItemID.DayBreak || item.type == ItemID.Anchor
                || item.type == ItemID.ChainGuillotines || item.type == ItemID.KOCannon
                || item.type == ItemID.GolemFist || item.type == ItemID.ChainKnife
                || item.type == ItemID.WoodYoyo || item.type == ItemID.Rally || item.type == ItemID.CorruptYoyo
                || item.type == ItemID.CrimsonYoyo || item.type == ItemID.JungleYoyo
                || item.type == ItemID.Code1 || item.type == ItemID.Valor
                || item.type == ItemID.Cascade || item.type == ItemID.FormatC
                || item.type == ItemID.Gradient || item.type == ItemID.Chik
                || item.type == ItemID.HelFire || item.type == ItemID.Amarok
                || item.type == ItemID.Code2 || item.type == ItemID.Yelets
                || item.type == ItemID.RedsYoyo || item.type == ItemID.ValkyrieYoyo
                || item.type == ItemID.Kraken || item.type == ItemID.TheEyeOfCthulhu
                || item.type == ItemID.Terrarian
                )
            {
                item.melee = false;
                item.magic = false;
                item.thrown = true;
            }
            /*
            if (item.type == ItemID.ToxicFlask)
            {
                item.magic = false;
                modItem.chemical = true;
                item.consumable = true;
                item.crit = 0;
                item.mana = 0;
                item.value = 5000;
                item.maxStack = 999;
            }
            */
            if(IsCOItem(item) || IsModItem(item) == false) JobHooks.ApplyClassAssigns(item);
            ItemMethods.SetDefaults(item);
            if(item.type == ItemID.LightDisc || item.type == ItemID.Bananarang
                || item.type == ItemID.PossessedHatchet || item.type == ItemID.ShadowFlameKnife
                || item.type == ItemID.VampireKnives || item.type == ItemID.Anchor
                || item.type == ItemID.ChainGuillotines || item.type == ItemID.KOCannon
                || item.type == ItemID.GolemFist
                )
            {
                item.damage += 20;
            }
            if(item.type == ItemID.FormatC || item.type == ItemID.DayBreak
                || item.type == ItemID.Gradient || item.type == ItemID.Chik
                || item.type == ItemID.HelFire || item.type == ItemID.Amarok
                || item.type == ItemID.Code2 || item.type == ItemID.Yelets
                || item.type == ItemID.RedsYoyo || item.type == ItemID.ValkyrieYoyo
                || item.type == ItemID.Kraken || item.type == ItemID.TheEyeOfCthulhu
                || item.type == ItemID.Terrarian
                )
            {
                item.damage -= 15;
            }
            if(item.type == ItemID.CobaltHelmet || item.type == ItemID.PalladiumMask
                || item.type == ItemID.MythrilHelmet || item.type == ItemID.OrichalcumMask
                || item.type == ItemID.AdamantiteHelmet || item.type == ItemID.TitaniumMask
                || item.type == ItemID.HallowedMask || item.type == ItemID.ChlorophyteMask
                || item.type == ItemID.BeetleShell || item.type == ItemID.SolarFlareBreastplate
                || item.type == ItemID.SquirePlating || item.type == ItemID.SquireAltShirt
                || item.type == ItemID.TurtleScaleMail
                )
            {
                item.defense += 10 + (item.rare * 2);
            }
            if(item.type == ItemID.FrostBreastplate) item.defense += 6;
            if(item.defense > 0 && IsCOItem(item) == false)
            {
                if(modItem.mageItem || modItem.summonerItem)
                    modItem.magicDefense = item.defense * 3;
                if(modItem.knightItem)
                    modItem.magicDefense = item.defense - item.defense / 10;
                if(modItem.rangerItem || modItem.chemistItem)
                    modItem.magicDefense = item.defense + item.defense / 4;
                if(modItem.rogueItem)
                    modItem.magicDefense = item.defense + item.defense / 6;
                if(modItem.summonerItem && (modItem.knightItem || modItem.rangerItem
                    || modItem.rogueItem || modItem.chemistItem))
                    modItem.magicDefense = item.defense + item.defense / 2;
                if(!(modItem.mageItem && modItem.summonerItem && modItem.knightItem
                    && modItem.rogueItem && modItem.rangerItem && modItem.chemistItem))
                    modItem.magicDefense = item.defense;
            }
            if(item.magic == true && IsCOItem(item) == false)
            { item.damage += (10 + (item.mana / 2) + item.rare); if(item.crit > 4) item.damage += item.crit - 4; }
            if(item.magic == true && IsCOItem(item) == false) item.crit = 0;
            if(item.thrown == true && IsCOItem(item) == false)
            { if(item.crit >= 4) item.crit -= 4; else item.crit = 0; }
            if(item.type == ItemID.BeesKnees)
            {
                item.autoReuse = true;
                item.useAmmo = 0;
                item.damage += 5;
                item.mana = 6;
            }
            if(item.type == ItemID.HellwingBow)
            {
                item.autoReuse = true;
                item.useAmmo = 0;
                item.damage += 5;
                item.mana = 4;
            }
            if(item.type == ItemID.PiranhaGun)
            {
                item.useAmmo = 0;
                item.mana = 8;
            }
            if(item.type == ItemID.SpectreStaff)
            {
                item.damage = 68;
            }
            if(item.type == ItemID.SpaceGun)
            {
                item.mana = 6;
            }
            if(item.type == ItemID.LaserRifle)
            {
                item.mana = 7;
            }
            if(item.type == ItemID.ChargedBlasterCannon)
            {
                item.mana = 10;
            }
            if(item.type == ItemID.MeteorStaff)
            {
                item.damage = 75;
            }
            if(item.type == ItemID.ScourgeoftheCorruptor)
            {
                item.mana = 12;
            }
            if(item.type == ItemID.AnkhCharm)
            {
                item.accessory = false;
            }
            if(item.type == ItemID.BookofSkulls)
            {
                item.mana = 12;
            }
            //if (item.type == ItemID.ImpStaff)
            //{
            //    modItem.hasSummon = true;
            //    item.shoot = 0;
            //    modItem.summonNPC = mod.NPCType("Imp");
            //}
        }
        public override void UpdateEquip(Item item, Player player)
        {
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            if(JobHooks.CanEquip(item, player) == false)
            {
                int num5 = (item.vanity && !item.accessory) ? 10 : 0;
                item.favorited = false;
                if(item.headSlot != -1)
                {
                    player.GetItem(Main.myPlayer, player.armor[num5].Clone());
                    player.armor[num5].ResetStats(0);
                    Main.PlaySound(7, -1, -1, 1, 1f, 0f);
                    Recipe.FindRecipes();
                }
                else if(item.bodySlot != -1)
                {
                    player.GetItem(Main.myPlayer, player.armor[num5 + 1].Clone());
                    player.armor[num5 + 1].ResetStats(0);
                    Main.PlaySound(7, -1, -1, 1, 1f, 0f);
                    Recipe.FindRecipes();
                }
                else if(item.legSlot != -1)
                {
                    player.GetItem(Main.myPlayer, player.armor[num5 + 2].Clone());
                    player.armor[num5 + 2].ResetStats(0);
                    Main.PlaySound(7, -1, -1, 1, 1f, 0f);
                    Recipe.FindRecipes();
                }
            }
            if(modItem.magicDefense != 0) modPlayer.magicDefense += modItem.magicDefense;
            if(item.prefix == mod.PrefixType("Magic")) modPlayer.magicDefense += 1;
            if(item.prefix == mod.PrefixType("Blessed")) modPlayer.magicDefense += 2;
            if(item.prefix == mod.PrefixType("Runic")) modPlayer.magicDefense += 3;
            if(item.prefix == mod.PrefixType("Witchs")) modPlayer.magicDefense += 4;
            if(item.type == ItemID.SpectreHood)
            {
                player.magicDamage += 0.15f; // -25% mDamage
                player.manaCost -= 0.05f;
            }
            if(item.type == ItemID.MeteorHelmet)
            {
                player.magicDamage -= 0.03f;
                player.rangedDamage += 0.05f;
            }
            if(item.type == ItemID.MeteorSuit)
            {
                player.magicDamage -= 0.03f;
                player.rangedDamage += 0.05f;
            }
            if(item.type == ItemID.MeteorLeggings)
            {
                player.magicDamage -= 0.03f;
                player.rangedDamage += 0.05f;
            }
            if(item.type == ItemID.AncientCobaltHelmet)
            {
                player.magicCrit += -4;
                player.magicDamage += 0.04f; // 4% mDamage
            }
            if(item.type == ItemID.AncientCobaltBreastplate)
            {
                player.magicCrit += -4;
                player.magicDamage += 0.04f; // 4% mDamage
            }
            if(item.type == ItemID.AncientCobaltLeggings)
            {
                player.magicCrit += -4;
                player.magicDamage += 0.04f; // 4% mDamage
            }
            if(item.type == ItemID.JungleHat)
            {
                player.magicCrit += -4;
                player.magicDamage += 0.04f; // 4% mDamage
            }
            if(item.type == ItemID.JungleShirt)
            {
                player.magicCrit += -4;
                player.magicDamage += 0.04f; // 4% mDamage
            }
            if(item.type == ItemID.JunglePants)
            {
                player.magicCrit += -4;
                player.magicDamage += 0.04f; // 4% mDamage
            }
            if(item.type == ItemID.CobaltHat)
            {
                player.magicCrit -= 3;
                player.magicDamage += 0.15f; // 15% mDamage
            }
            if(item.type == ItemID.PalladiumHeadgear)
            {
                player.magicCrit -= 7;
                player.magicDamage += 0.13f; // 20% mDamage
            }
            if(item.type == ItemID.MythrilHood)
            {
                player.magicDamage += 0.06f; // 21% mDamage
            }
            if(item.type == ItemID.OrichalcumHeadgear)
            {
                player.magicCrit -= 18;
                player.magicDamage += 0.24f; // 24% mDamage
            }
            if(item.type == ItemID.AdamantiteHeadgear)
            {
                player.magicDamage += 0.19f; // 30% mDamage
                player.magicCrit -= 11;
            }
            if(item.type == ItemID.TitaniumHeadgear)
            {
                player.magicDamage += 0.12f; // 27% mDamage
                player.magicCrit -= 7;
            }
            if(item.type == ItemID.AncientBattleArmorHat)
            {
                player.magicDamage += 0.06f; // 21% mDamage
            }
            if(item.type == ItemID.HallowedHeadgear)
            {
                player.magicDamage += 0.20f; // 32% mDamage
                player.magicCrit -= 12;
            }
            if(item.type == ItemID.ChlorophyteHeadgear)
            {
                player.magicDamage += 0.19f; // 35% mDamage
            }
            if(item.type == ItemID.SpectreMask)
            {
                player.magicDamage += 0.15f;  // 20% mDamage (42% with full set)
                player.magicCrit -= 5;
            }
            if(item.type == ItemID.SpectreRobe)
            {
                player.magicCrit -= 7;
                player.magicDamage += 0.07f; // 14% mDamage
            }
            if(item.type == ItemID.NebulaHelmet)
            {
                player.magicDamage += 0.13f; // 20% mDamage (48% with full set)
                player.magicCrit -= 7;
            }
            if(item.type == ItemID.NebulaBreastplate)
            {
                player.magicDamage += 0.09f; // 18% mDamage
                player.magicCrit -= 9;
            }
            if(item.type == ItemID.ApprenticeAltPants)
            {
                player.magicCrit -= 25;
                player.magicDamage += 21; // 23% mDamage (46% with full set)
            }
            if(item.type == ItemID.BeetleScaleMail)
            {
                player.meleeDamage += 0.02f;
                player.meleeSpeed += 0.20f;
                player.meleeCrit += 43;
                player.thrownDamage += 0.25f;
            }
            if(item.type == ItemID.MonkBrows)
            {
                player.meleeSpeed += 0.15f;
            }
            if(item.type == ItemID.MonkShirt)
            {
                player.thrownDamage += 0.25f;
                player.meleeCrit += 15;
            }
            if(item.type == ItemID.MonkPants)
            {
                player.meleeCrit += 10;
                player.moveSpeed += 0.05f;
            }
            if(item.type == ItemID.MonkAltHead)
            {
                player.thrownDamage += 0.20f;
            }
            if(item.type == ItemID.MonkAltShirt)
            {
                player.meleeSpeed += 0.10f;
            }
            if(item.type == ItemID.MonkAltPants)
            {
                player.meleeCrit += 20;
                player.moveSpeed += 0.15f;
            }
            if(item.type == ItemID.CobaltHelmet)
            {
                player.meleeSpeed -= 0.06f; // 6% on helmet
                player.moveSpeed -= 0.03f; // 4% on helmet
            }
            if(item.type == ItemID.PalladiumMask)
            {
                player.meleeDamage -= 0.03f; // 5% on mask
                player.meleeSpeed -= 0.06f; // 6% on mask
            }
            if(item.type == ItemID.MythrilHelmet)
            {
                player.meleeCrit -= 2; // 3% on helmet
                player.meleeDamage -= 0.03f; // 7% on helmet
            }
            if(item.type == ItemID.OrichalcumMask)
            {
                player.meleeDamage -= 0.02f; // 5% on mask
                player.meleeSpeed -= 0.04f; // 4% on mask
                player.moveSpeed -= 0.04f; // 4% on mask
            }
            if(item.type == ItemID.AdamantiteHelmet)
            {
                player.meleeCrit -= 3; // 4% on helmet
                player.meleeDamage -= 0.04f; // 10% on helmet
            }
            if(item.type == ItemID.TitaniumMask)
            {
                player.meleeDamage -= 0.02f; // 6% on mask
                player.meleeCrit -= 2; // 6% on mask
            }
            if(item.type == ItemID.SquireGreaves)
            {
                player.meleeCrit -= 10; // 10% on greaves
                player.moveSpeed -= 0.08f; // 12% on greaves
            }
            if(item.type == ItemID.HallowedMask)
            {
                player.meleeDamage -= 0.02f; // 8% on mask
                player.meleeCrit -= 4; // 6% on mask
                player.meleeSpeed -= 0.03f; // 7% on mask
            }
            if(item.type == ItemID.ChlorophyteMask)
            {
                player.meleeDamage -= 0.04f; // 12% on mask
                player.meleeCrit -= 2; // 4% on mask
            }
            if(item.type == ItemID.TurtleHelmet)
            {
                player.meleeDamage -= 0.02f; // 4% on helmet
            }
            if(item.type == ItemID.TurtleScaleMail)
            {
                player.meleeDamage -= 0.03f; // 5% on mail
                player.meleeCrit -= 3; // 5% on mail 
            }
            if(item.type == ItemID.TurtleLeggings)
            {
                player.meleeCrit -= 2; // 2% on leggings
            }
            if(item.type == ItemID.BeetleShell)
            {
                player.meleeDamage -= 0.02f; // 3% on shell
                player.meleeCrit -= 3; // 2% on shell
            }
            if(item.type == ItemID.SquireAltPants)
            {
                player.meleeCrit -= 8; // 12% on pants
                player.moveSpeed -= 0.15f; // 15% on pants
            }
            if(item.type == ItemID.SolarFlareHelmet)
            {
                player.meleeCrit -= 7; // 10% on helmet
            }
            if(item.type == ItemID.SolarFlareBreastplate)
            {
                player.meleeDamage -= 0.1f; // 12% on breastplate
            }
            if(item.type == ItemID.SolarFlareLeggings)
            {
                player.moveSpeed -= 0.06f; // 9% on leggings
                player.meleeSpeed -= 0.05f; // 10% on leggings
            }
        }
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            base.UpdateAccessory(item, player, hideVisual);
            if(item.type == ItemID.CobaltShield)
            {
                player.noKnockback = false;
            }
            if(item.type == ItemID.ObsidianShield || item.type == ItemID.EoCShield || item.type == ItemID.AnkhShield
                || item.type == ItemID.PaladinsShield)
            {
                player.noKnockback = true;
            }
        }
        public override bool? PrefixChance(Item item, int pre, UnifiedRandom rand)
        {
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            if(modItem.chemical == true)
            {
                if(pre == -1 || pre == -3) return false;
            }
            if(item.accessory == false && item.defense > 0
                && !(item.melee && item.ranged && item.magic && item.summon && item.thrown && modItem.chemical))
            {
                if(pre == -1 || pre == -2 || pre == -3) return true;

            }
            return base.PrefixChance(item, pre, rand);
        }
        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            if(modItem.chemical == true) return 0;
            if(item.accessory == false && item.defense > 0
                && !(item.melee && item.ranged && item.magic && item.summon && item.thrown && modItem.chemical))
            {
                int[] result = new int[PrefixList.AccessoryPrefixes.Count];
                for(int i = 0; i < PrefixList.AccessoryPrefixes.Count; i++)
                {
                    result[i] = PrefixList.AccessoryPrefixes[i];
                }
                return rand.Next(result);
            }
            if(item.ranged && item.mana > 0)
            {
                int[] result = new int[PrefixList.ManaGunPrefixes.Count];
                for(int i = 0; i < result.Length; i++)
                {
                    result[i] = PrefixList.ManaGunPrefixes[i];
                }
                return rand.Next(result);
            }
            if(item.magic)
            {
                int[] result = new int[PrefixList.MagicPrefixes.Count];
                for(int i = 0; i < result.Length; i++)
                {
                    result[i] = PrefixList.MagicPrefixes[i];
                }
                return rand.Next(result);
            }
            return base.ChoosePrefix(item, rand);
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            if(modItem.chemical == true)
            {
                var tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
                if(tt != null)
                {
                    string[] split = tt.text.Split(' ');
                    tt.text = split.First() + " chemical damage";
                }
            }
            if(modItem.magicDefense > 0)
            {

                TooltipLine socialDesc = tooltips.FirstOrDefault(x => x.Name == "SocialDesc" && x.mod == "Terraria");
                if (socialDesc == null)
                {
                    TooltipLine defense = tooltips.FirstOrDefault(x => x.Name == "Defense" && x.mod == "Terraria");
                    TooltipLine damage = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
                    TooltipLine favDesc = tooltips.FirstOrDefault(x => x.Name == "FavoriteDesc" && x.mod == "Terraria");
                    TooltipLine line = new TooltipLine(mod, "Magic Defense", modItem.magicDefense + " magic defense");
                    if(defense != null)
                        tooltips.Insert(tooltips.FindIndex(x => x.Name == "Defense" && x.mod == "Terraria") + 1, line);
                    else if(damage != null)
                        tooltips.Insert(tooltips.FindIndex(x => x.Name == "Damage" && x.mod == "Terraria") + 1, line);
                    else if(favDesc != null)
                        tooltips.Insert(tooltips.FindIndex(x => x.Name == "FavoriteDesc" && x.mod == "Terraria") + 1, line);
                    else
                        tooltips.Insert(tooltips.FindIndex(x => x.Name == "ItemName" && x.mod == "Terraria") + 1, line);
                }
            }
            if(item.prefix == mod.PrefixType("Blessed") || item.prefix == mod.PrefixType("Runic")
                || item.prefix == mod.PrefixType("Witchs") || item.prefix == mod.PrefixType("Magic"))
            {
                TooltipLine line = new TooltipLine(mod, "PrefixAccMagicDefense", "");
                line.isModifier = true;
                tooltips.Add(line);
                line = tooltips.FirstOrDefault(x => x.Name == "PrefixAccMagicDefense" && x.mod == mod.Name);
                if(item.prefix == mod.PrefixType("Magic")) line.text = "+1 magic defense";
                if(item.prefix == mod.PrefixType("Blessed")) line.text = "+2 magic defense";
                if(item.prefix == mod.PrefixType("Runic")) line.text = "+3 magic defense";
                if(item.prefix == mod.PrefixType("Witchs")) line.text = "+4 magic defense";
            }
            else tooltips.RemoveAll(x => x.Name == "PrefixAccMagicDefense" && x.mod == mod.Name);
            PlayerEdits modPlayer = Main.player[Main.myPlayer].GetModPlayer<PlayerEdits>();
            if(item.melee == true && (modPlayer.job == JobID.rogue || modPlayer.armorJob == JobID.rogue) && item.type != ItemID.SolarEruption)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
                if (line != null)
                {
                    TooltipLine armorPen = new TooltipLine(mod, "Armor Penetration", (item.rare * 2).ToString() + " armor penetration");
                    tooltips.Insert(tooltips.FindIndex(x => x.Name == "Damage" && x.mod == "Terraria") + 1, armorPen);
                }
            }
            if(item.type == ItemID.SpectreHood)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "25% decreased magic damage\n5% reduced mana usage";
                }

            }
            if(item.type == ItemID.BeesKnees)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "Shoots summoned bees like arrows";
                }

            }
            if(item.type == ItemID.HellwingBow)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "Shoots summoned Hell Bats like arrows";
                }

            }
            if(item.type == ItemID.MeteorHelmet)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "4% increased magic damage\n5% increased ranged damage";
                }
            }
            if(item.type == ItemID.MeteorSuit)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "4% increased magic damage\n5% increased ranged damage";
                }
            }
            if(item.type == ItemID.MeteorLeggings)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "4% increased magic damage\n5% increased ranged damage";
                }
            }
            if(item.type == ItemID.AncientCobaltHelmet)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+40 maximum mana\n4% increased magic damage";
                }
            }
            if(item.type == ItemID.AncientCobaltBreastplate)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+20 maximum mana\n4% increased magic damage";
                }
            }
            if(item.type == ItemID.AncientCobaltLeggings)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+20 maximum mana\n4% increased magic damage";
                }
            }
            if(item.type == ItemID.JungleHat)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+40 maximum mana\n4% increased magic damage";
                }
            }
            if(item.type == ItemID.JungleShirt)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+20 maximum mana\n4% increased magic damage";
                }
            }
            if(item.type == ItemID.JunglePants)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+20 maximum mana\n4% increased magic damage";
                }
            }
            if(item.type == ItemID.CobaltHat)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+40 maximum mana\n15% increased magic damage";
                }
            }
            if(item.type == ItemID.PalladiumHeadgear)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+60 maximum mana\n20% increased magic damage";
                }
            }
            if(item.type == ItemID.MythrilHood)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+60 maximum mana\n21% increased magic damage";
                }
            }
            if(item.type == ItemID.OrichalcumHeadgear)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+80 maximum mana\n24% increased magic damage";
                }
            }
            if(item.type == ItemID.AdamantiteHeadgear)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+80 maximum mana\n30% increased magic damage";
                }
            }
            if(item.type == ItemID.TitaniumHeadgear)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+100 maximum mana\n27% increased magic damage";
                }
            }
            if(item.type == ItemID.AncientBattleArmorHat)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "15% increased minion damage\n21% increased magic damage";
                }
            }
            if(item.type == ItemID.HallowedHeadgear)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+100 maximum mana\n32% increased magic damage";
                }
            }
            if(item.type == ItemID.ChlorophyteHeadgear)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+80 maximum mana\n17% reduced mana usage\n35% increased magic damage";
                }
            }
            if(item.type == ItemID.SpectreMask)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+60 maximum mana\n13% reduced mana usage\n20% increased magic damage";
                }
            }
            if(item.type == ItemID.SpectreRobe)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "14% increased magic damage";
                }
            }
            if(item.type == ItemID.NebulaHelmet)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "+60 maximum mana\n15% reduced mana usage\n20% increased magic damage";
                }
            }
            if(item.type == ItemID.NebulaBreastplate)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "18% increased magic damage";
                }
            }
            if(item.type == ItemID.ApprenticeAltPants)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "20% increased minion damage\n25% increased magic damage";
                }
            }
            if(item.type == ItemID.BeetleScaleMail)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "10% increased melee damage\n25% increased thrown damage\n43% increased melee critical strike chance\n26% increased melee speed";
                }
            }
            if(item.type == ItemID.MonkBrows)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "Increases your max number of sentries\n35% increased melee speed";
                }
            }
            if(item.type == ItemID.MonkShirt)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "20% increased minion damage\n20% increased melee damage\n25% increased thrown damage\n15% increased melee critical strike chance";
                }
            }
            if(item.type == ItemID.MonkPants)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "10% increased minion damage\n20% increased melee critical strike chance\n25% increased move speed";
                }
            }
            if(item.type == ItemID.MonkAltHead)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "Increases your max number of sentries\n20% increased melee, thrown & minion damage";
                }
            }
            if(item.type == ItemID.MonkAltShirt)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "20% increased minion damage\n30% increased melee speed";
                }
            }
            if(item.type == ItemID.MonkAltPants)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "20% increased minion damage\n40% increased melee critical strike chance\n35% increased move speed";
                }
            }
            if(item.type == ItemID.AnkhCharm)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
            }
            if(item.type == ItemID.CobaltShield)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.mod == "Terraria");
            }
            if(item.type == ItemID.CobaltHelmet)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "6% increased melee speed\n4% increased move speed";
                }
            }
            if(item.type == ItemID.PalladiumMask)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "5% increased melee damage\n6% increased melee speed";
                }
            }
            if(item.type == ItemID.MythrilHelmet)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "7% increased melee damage\n3% increased melee critical strike chance";
                }
            }
            if(item.type == ItemID.OrichalcumMask)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "5% increased melee damage\n4% increased melee and movement speed";
                }
            }
            if(item.type == ItemID.AdamantiteHelmet)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "10% increased melee damage\n4% increased melee critical strike chance";
                }
            }
            if(item.type == ItemID.TitaniumMask)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "6% increased melee damage and critical strike chance";
                }
            }
            if(item.type == ItemID.SquireGreaves)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "15% increased minion damage\n10% increased melee critical strike chance\n12% increased move speed";
                }
            }
            if(item.type == ItemID.HallowedMask)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "8% increased melee damage\n7% increased melee speed\n6% increased melee critical strike chance";
                }
            }
            if(item.type == ItemID.ChlorophyteMask)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "12% increased melee damage\n4% increased melee critical strike chance";
                }
            }
            if(item.type == ItemID.TurtleHelmet)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "4% increased melee damage\nEnemies are more likely to target you";
                }
            }
            if(item.type == ItemID.TurtleScaleMail)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "5% increased melee damage and critical strike chance\nEnemies are more likely to target you";
                }
            }
            if(item.type == ItemID.TurtleLeggings)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "2% increased melee critical strike chance\nEnemies are more likely to target you";
                }
            }
            if(item.type == ItemID.BeetleShell)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "3% increased damage damage\n2% increased melee critical strike chance\nEnemies are more likely to target you";
                }
            }
            if(item.type == ItemID.SquireAltPants)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "20% increased minion damage\n12% increased melee critical strike chance\n15% increased move speed";
                }
            }
            if(item.type == ItemID.SolarFlareHelmet)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "10% increased melee critical strike chance\nEnemies are more likely to target you";
                }
            }
            if(item.type == ItemID.SolarFlareBreastplate)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "12% increased melee damage\nEnemies are more likely to target you";
                }
            }
            if(item.type == ItemID.SolarFlareLeggings)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "10% increased melee speed\n9% increased move speed\nEnemies are more likely to target you";
                }
            }
        }
        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if(head.type == ItemID.ApprenticeHat && body.type == ItemID.ApprenticeRobe && legs.type == ItemID.ApprenticeTrousers)
            { return "Apprentice"; }
            if(head.type == ItemID.ApprenticeAltHead && legs.type == ItemID.ApprenticeAltPants && body.type == ItemID.ApprenticeAltShirt)
            { return "DarkArtist"; }
            if(head.type == ItemID.HuntressWig && legs.type == ItemID.HuntressPants && body.type == ItemID.HuntressJerkin)
            { return "Huntress"; }
            if(head.type == ItemID.HuntressAltHead && legs.type == ItemID.HuntressAltPants && body.type == ItemID.HuntressAltShirt)
            { return "RedRiding"; }
            if(head.type == ItemID.SquireGreatHelm && legs.type == ItemID.SquireGreaves && body.type == ItemID.SquirePlating)
            { return "Squire"; }
            if(head.type == ItemID.SquireAltHead && legs.type == ItemID.SquireAltPants && body.type == ItemID.SquireAltShirt)
            { return "ValhallaKnight"; }
            if(head.type == ItemID.MonkBrows && legs.type == ItemID.MonkPants && body.type == ItemID.MonkShirt)
            { return "Monk"; }
            if(head.type == ItemID.MonkAltHead && legs.type == ItemID.MonkAltPants && body.type == ItemID.MonkAltShirt)
            { return "ShinobiInfiltrator"; }
            if(head.type == ItemID.BeetleHelmet && body.type == ItemID.BeetleScaleMail && legs.type == ItemID.BeetleLeggings)
            { return "BeetleScaleArmor"; }
            if(head.type == ItemID.AdamantiteHelmet && body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings)
            { return "AdamantiteKnight"; }
            if(head.type == ItemID.MythrilHelmet && body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves)
            { return "MythrilKnight"; }
            if(head.type == ItemID.CobaltHelmet && body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings)
            { return "CobaltKnight"; }
            if(head.type == ItemID.HallowedMask && body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves)
            { return "HallowedKnight"; }
            if(head.type == ItemID.FrostHelmet && body.type == ItemID.FrostBreastplate && legs.type == ItemID.FrostLeggings)
            { return "FrostArmor"; }
            if(head.type == ItemID.AncientBattleArmorHat && body.type == ItemID.AncientBattleArmorShirt && legs.type == ItemID.AncientBattleArmorPants)
            { return "ForbiddenArmor"; }
            return base.IsArmorSet(head, body, legs);
        }
        public override void UpdateArmorSet(Player player, string set)
        {
            base.UpdateArmorSet(player, set);
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if((set == "Apprentice" || set == "DarkArtist") && (modPlayer.job == JobID.mage || modPlayer.job == JobID.summoner))
            {
                if(modPlayer.job == JobID.summoner) modPlayer.armorJob = JobID.mage; else modPlayer.armorJob = JobID.summoner;
                player.setBonus += "\nAllows using items of other class";
            }
            if((set == "Huntress" || set == "RedRiding") && (modPlayer.job == JobID.ranger || modPlayer.job == JobID.summoner))
            {
                if(modPlayer.job == JobID.summoner) modPlayer.armorJob = JobID.ranger; else modPlayer.armorJob = JobID.summoner;
                player.setBonus += "\nAllows using items of other class";
            }
            if((set == "Squire" || set == "ValhallaKnight") && (modPlayer.job == JobID.knight || modPlayer.job == JobID.summoner))
            {
                if(modPlayer.job == JobID.summoner) modPlayer.armorJob = JobID.knight; else modPlayer.armorJob = JobID.summoner;
                player.setBonus += "\nAllows using items of other class";
            }
            if((set == "Monk" || set == "ShinobiInfiltrator") && (modPlayer.job == JobID.rogue || modPlayer.job == JobID.summoner))
            {
                player.thrownVelocity += 0.30f;
                if(modPlayer.job == JobID.summoner) modPlayer.armorJob = JobID.rogue; else modPlayer.armorJob = JobID.summoner;
                player.setBonus += "\nAllows using items of other class\n30% increased thrown velocity";
            }
            if(set == "BeetleScaleArmor")
            {
                player.thrownVelocity += 0.25f;
                player.setBonus = "25% increased thrown velocity\n" + player.setBonus;
            }
            if(set == "AdamantiteKnight")
            {
                player.meleeSpeed -= 0.09f; // 9% on set
                player.moveSpeed -= 0.09f; // 9% on set
                player.setBonus = "9% increased melee and movement speed";
            }
            if(set == "MythrilKnight")
            {
                player.meleeCrit -= 2; // 3% on set
                player.setBonus = "3% increased melee critical strike chance";
            }
            if(set == "CobaltKnight")
            {
                player.meleeSpeed -= 0.07f; // 8% on set
                player.setBonus = "8% increased melee speed";
            }
            if(set == "HallowedKnight")
            {
                player.meleeSpeed -= 0.8f; // 11% on set
                player.moveSpeed -= 0.10f; // 9% on set
                player.setBonus = "11% increased melee speed\n9% increased move speed";
            }
            if(set == "FrostArmor" && (modPlayer.job == JobID.knight || modPlayer.job == JobID.ranger))
            {
                if(modPlayer.job == JobID.knight) modPlayer.armorJob = JobID.ranger; else modPlayer.armorJob = JobID.knight;
                player.setBonus += "\nAllows using items of other class";
            }
            if(set == "ForbiddenArmor" && (modPlayer.job == JobID.mage || modPlayer.job == JobID.summoner))
            {
                if(modPlayer.job == JobID.mage) modPlayer.armorJob = JobID.summoner; else modPlayer.armorJob = JobID.mage;
                player.setBonus += "\nAllows using items of other class";
            }
        }
        public override bool CanUseItem(Item item, Player player)
        {
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if(JobHooks.CanEquip(item, player)) return base.CanUseItem(item, player);
            return false;
        }

        public override bool CanEquipAccessory(Item item, Player player, int slot)
        {
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if(JobHooks.CanEquip(item, player)) return base.CanEquipAccessory(item, player, slot);
            return false;
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref float add, ref float mult, ref float flat)
        {
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if(modItem.chemical == true)
            {
                add += ((player.thrownDamage - 1f) / 2 + (modPlayer.chemicalDamage - 1f));
                mult = modPlayer.chemicalDamageMult * player.allDamageMult;
            }
        }

        public override float UseTimeMultiplier(Item item, Player player)
        {
            if(item.thrown == true)
            {
                float multiplier = 1f - (player.meleeSpeed - 1f);
                if(multiplier < 0.01f) multiplier = 0.01f;
                return multiplier;
            }
            return base.UseTimeMultiplier(item, player);
        }

        public override void UpdateInventory(Item item, Player player)
        {
            base.UpdateInventory(item, player);
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            if(item.melee == true)
            {
                if(modPlayer.job == JobID.rogue)
                {
                    if(item.type != ItemID.PaladinsHammer && item.type != ItemID.SolarEruption) item.shoot = 0;
                    item.autoReuse = true;
                }
                else
                {
                    Item originalitem = item.DeepClone();
                    item.shoot = originalitem.shoot;
                    item.autoReuse = originalitem.autoReuse;
                }
            }
        }

        public override void HoldItem(Item item, Player player)
        {
            base.HoldItem(item, player);
            PlayerEdits modPlayer = player.GetModPlayer<PlayerEdits>();
            ItemEdits modItem = item.GetGlobalItem<ItemEdits>();
            if(item.melee == true)
            {
                if(modPlayer.job == JobID.rogue || modPlayer.armorJob == JobID.rogue)
                {
                    if(modPlayer.rogueBonus == false)
                    {
                        player.armorPenetration += item.rare * 2;
                        modPlayer.rogueBonus = true;
                    }
                }
            }
            if(item.type == ItemID.PiranhaGun)
            {
                if(player.statMana < item.mana)
                {
                    modItem.blocked = true;
                }
                else
                {
                    modItem.blocked = false;
                }
                if(modItem.blocked == true)
                {
                    player.controlUseItem = false;
                }
                if(player.controlUseItem == true && modItem.blocked == false && player.itemAnimation > 0)
                {
                    if(modPlayer.itemCool == 0) player.statMana -= item.mana;
                    if(modPlayer.itemCool == 0) modPlayer.itemCool = item.useTime;
                    modPlayer.itemCool--;
                }
            }
            if(modItem.blocked == true)
            {
                player.controlUseItem = false;
                player.channel = false;
            }
            if(player.itemTime == item.useTime && player.controlUseItem && modItem.hasSummon)
            {
                if(!(modPlayer.usedMinionSlots + modItem.summonSlots > player.maxMinions))
                {
                    int id = NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, modItem.summonNPC);
                    NPC minion = Main.npc[id];
                    NPCEdits modMinion = minion.GetGlobalNPC<NPCEdits>();
                    modMinion.owner = Main.myPlayer;
                    modPlayer.usedMinionSlots += modMinion.minionSlots;
                    modMinion.minionSlots = modItem.summonSlots;
                    player.numMinions++;
                    modMinion.minionPos = player.numMinions;
                    minion.damage = item.damage;
                }
            }
        }
    }
}