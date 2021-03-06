﻿using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace ClassOverhaul.Items.Weapons
{
    public class StaffOfFireball : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.mana = 7;
            item.UseSound = SoundID.Item73;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.damage = 95;
            item.useAnimation = 28;
            item.autoReuse = true;
            item.crit = 0;
            item.useTime = 30;
            item.width = 26;
            item.height = 23;
            item.shoot = mod.ProjectileType("Fireball");
            item.shootSpeed = 15f;
            item.knockBack = 8f;
            item.value = 70000;
            item.magic = true;
            item.noMelee = true;
            item.rare = ItemRarityID.Cyan;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FlowerofFire, 1);
            recipe.AddIngredient(ItemID.InfernoFork, 1);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
