using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace ClassOverhaul.Items.Weapons
{
    public class BookOfShootingStars : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Book of Shooting Stars");
            Tooltip.SetDefault("What if stars could be commanded?");
        }
        public override void SetDefaults()
        {
            item.magic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.damage = 35;
            item.mana = 5;
            item.crit = 0;
            item.rare = 2;
            item.width = 20;
            item.height = 28;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.shoot = ProjectileID.HallowStar;
            item.shootSpeed = 18f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Bookcases);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
