using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using System.Linq;

namespace ClassOverhaul
{
    public class ItemEdits : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            base.SetDefaults(item);
            if (item.type == ItemID.BeesKnees)
            {
                item.ranged = false;
                item.summon = true;
                item.autoReuse = true;
                item.useAmmo = 0;
                item.damage = 31;
                item.mana = 5;
            }
            if (item.type == ItemID.BeeGun)
            {
                item.magic = false;
                item.summon = true;
            }
            if (item.type == ItemID.WaspGun)
            {
                item.magic = false;
                item.summon = true;
            }
            if (item.type == ItemID.SpectreStaff)
            {
                item.magic = false;
                item.summon = true;
                item.damage = 68;
            }
            if (item.type == ItemID.BatScepter)
            {
                item.magic = false;
                item.summon = true;
            }
            if (item.type == ItemID.BookofSkulls)
            {
                item.magic = false;
                item.summon = true;
            }
            if (item.type == ItemID.SpaceGun)
            {
                item.magic = false;
                item.ranged = true;
                item.autoReuse = true;
                item.mana = 6;
            }
            if (item.type == ItemID.LaserRifle)
            {
                item.magic = false;
                item.ranged = true;
                item.autoReuse = true;
                item.mana = 7;
            }
            if (item.type == ItemID.LeafBlower)
            {
                item.magic = false;
                item.ranged = true;
                item.autoReuse = true;
            }
            if (item.type == ItemID.HeatRay)
            {
                item.magic = false;
                item.ranged = true;
                item.autoReuse = true;
            }
            if (item.type == ItemID.LaserMachinegun)
            {
                item.magic = false;
                item.ranged = true;
                item.autoReuse = true;
            }
            if (item.type == ItemID.ChargedBlasterCannon)
            {
                item.magic = false;
                item.ranged = true;
                item.autoReuse = true;
                item.mana = 10;
            }
            if (item.type == ItemID.Razorpine)
            {
                item.magic = false;
                item.ranged = true;
                item.autoReuse = true;
            }
            if (item.magic == true)
            {
                item.damage += 10;
                item.crit -= 4;
            }
            if (item.type == ItemID.MeteorStaff)
            {
                item.damage = 75;
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.SpectreHood)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "25% decreased magic damage\n5% reduced mana usage";
                }

            }
            if (item.type == ItemID.BeesKnees)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "Shoots summoned bees like arrows";
                }

            }
            if (item.type == ItemID.MeteorHelmet)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "4% increased magic damage\n5% increased ranged damage";
                }
            }
            if (item.type == ItemID.MeteorSuit)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "4% increased magic damage\n5% increased ranged damage";
                }
            }
            if (item.type == ItemID.MeteorLeggings)
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "4% increased magic damage\n5% increased ranged damage";
                }
            }
            if (item.type == ItemID.AncientCobaltHelmet)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+40 maximum mana\n4% increased magic damage";
                }
            }
            if (item.type == ItemID.AncientCobaltBreastplate)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+20 maximum mana\n4% increased magic damage";
                }
            }
            if (item.type == ItemID.AncientCobaltLeggings)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+20 maximum mana\n4% increased magic damage";
                }
            }
            if (item.type == ItemID.JungleHat)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+40 maximum mana\n4% increased magic damage";
                }
            }
            if (item.type == ItemID.JungleShirt)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+20 maximum mana\n4% increased magic damage";
                }
            }
            if (item.type == ItemID.JunglePants)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+20 maximum mana\n4% increased magic damage";
                }
            }
            if (item.type == ItemID.CobaltHat)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+40 maximum mana\n15% increased magic damage";
                }
            }
            if (item.type == ItemID.PalladiumHeadgear)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+60 maximum mana\n20% increased magic damage";
                }
            }
            if (item.type == ItemID.MythrilHood)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+60 maximum mana\n21% increased magic damage";
                }
            }
            if (item.type == ItemID.OrichalcumHeadgear)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+80 maximum mana\n24% increased magic damage";
                }
            }
            if (item.type == ItemID.AdamantiteHeadgear)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+80 maximum mana\n30% increased magic damage";
                }
            }
            if (item.type == ItemID.TitaniumHeadgear)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+100 maximum mana\n27% increased magic damage";
                }
            }
            if (item.type == ItemID.AncientBattleArmorHat)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "15% increased minion damage\n21% increased magic damage";
                }
            }
            if (item.type == ItemID.HallowedHeadgear)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+100 maximum mana\n32% increased magic damage";
                }
            }
            if (item.type == ItemID.ChlorophyteHeadgear)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+80 maximum mana\n17% reduced mana usage\n35% increased magic damage";
                }
            }
            if (item.type == ItemID.SpectreMask)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+60 maximum mana\n13% reduced mana usage\n20% increased magic damage";
                }
            }
            if (item.type == ItemID.SpectreRobe)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "14% increased magic damage";
                }
            }
            if (item.type == ItemID.NebulaHelmet)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "+60 maximum mana\n15% reduced mana usage\n+20% increased magic damage";
                }
            }
            if (item.type == ItemID.NebulaBreastplate)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "18% increased magic damage";
                }
            }
            if (item.type == ItemID.ApprenticeAltPants)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip1" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "20% increased minion damage\n25% increased magic damage";
                }
            }
        }
        public override void UpdateEquip(Item item, Player player)
        {
            if (item.type == ItemID.SpectreHood)
            {
                player.magicDamage += 0.15f; // -25% mDamage
                player.manaCost -= 0.05f;
            }
            if (item.type == ItemID.MeteorHelmet)
            {
                player.magicDamage -= 0.03f;
                player.rangedDamage += 0.05f;
            }
            if (item.type == ItemID.MeteorSuit)
            {
                player.magicDamage -= 0.03f;
                player.rangedDamage += 0.05f;
            }
            if (item.type == ItemID.MeteorLeggings)
            {
                player.magicDamage -= 0.03f;
                player.rangedDamage += 0.05f;
            }
            if (item.type == ItemID.AncientCobaltHelmet)
            {
                player.magicCrit += -4;
                player.magicDamage += 0.04f; // 4% mDamage
            }
            if (item.type == ItemID.AncientCobaltBreastplate)
            {
                player.magicCrit += -4;
                player.magicDamage += 0.04f; // 4% mDamage
            }
            if (item.type == ItemID.AncientCobaltLeggings)
            {
                player.magicCrit += -4;
                player.magicDamage += 0.04f; // 4% mDamage
            }
            if (item.type == ItemID.JungleHat)
            {
                player.magicCrit += -4;
                player.magicDamage += 0.04f; // 4% mDamage
            }
            if (item.type == ItemID.JungleShirt)
            {
                player.magicCrit += -4;
                player.magicDamage += 0.04f; // 4% mDamage
            }
            if (item.type == ItemID.JunglePants)
            {
                player.magicCrit += -4;
                player.magicDamage += 0.04f; // 4% mDamage
            }
            if (item.type == ItemID.CobaltHat)
            {
                player.magicCrit -= 3;
                player.magicDamage += 0.15f; // 15% mDamage
            }
            if (item.type == ItemID.PalladiumHeadgear)
            {
                player.magicCrit -= 7;
                player.magicDamage += 0.13f; // 20% mDamage
            }
            if (item.type == ItemID.MythrilHood)
            {
                player.magicDamage += 0.06f; // 21% mDamage

            }
            if (item.type == ItemID.OrichalcumHeadgear)
            {
                player.magicCrit -= 18;
                player.magicDamage += 0.24f; // 24% mDamage
            }
            if (item.type == ItemID.AdamantiteHeadgear)
            {
                player.magicDamage += 0.19f; // 30% mDamage
                player.magicCrit -= 11;
            }
            if (item.type == ItemID.TitaniumHeadgear)
            {
                player.magicDamage += 0.12f; // 27% mDamage
                player.magicCrit -= 7;
            }
            if (item.type == ItemID.AncientBattleArmorHat)
            {
                player.magicDamage += 0.06f; // 21% mDamage
            }
            if (item.type == ItemID.HallowedHeadgear)
            {
                player.magicDamage += 0.20f; // 32% mDamage
                player.magicCrit -= 12;
            }
            if (item.type == ItemID.ChlorophyteHeadgear)
            {
                player.magicDamage += 0.19f; // 35% mDamage
            }
            if (item.type == ItemID.SpectreMask)
            {
                player.magicDamage += 0.15f;  // 20% mDamage (42% with full set)
                player.magicCrit -= 5;
            }
            if (item.type == ItemID.SpectreRobe)
            {
                player.magicCrit -= 7;
                player.magicDamage += 0.07f; // 14% mDamage
            }
            if (item.type == ItemID.NebulaHelmet)
            {
                player.magicDamage += 0.13f; // 20% mDamage (48% with full set)
                player.magicCrit -= 7;
            }
            if (item.type == ItemID.NebulaBreastplate)
            {
                player.magicDamage += 0.09f; // 18% mDamage
                player.magicCrit -= 9;
            }
            if (item.type == ItemID.ApprenticeAltPants)
            {
                player.magicCrit -= 25;
                player.magicDamage += 21; // 23% mDamage (46% with full set)
            }
        }
    }
}