using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class GellyfishHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Gellyfish Hat");
            Tooltip.SetDefault("5% increased minion damage.");
        }
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            item.width = 18;
            item.height = 18;
            item.value = 3000;
            item.rare = 1;
            item.defense = 5;
            globalItem.magicDefense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vine);
            recipe.AddIngredient(ItemID.PinkJellyfish);
            recipe.AddIngredient(ItemID.PinkGel, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FishingSeaweed);
            recipe.AddIngredient(ItemID.PinkJellyfish);
            recipe.AddIngredient(ItemID.PinkGel, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("GellyfishShirt") && legs.type == mod.ItemType("GellyfishLeggings");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.GetModPlayer<PlayerEdits>().gellyfishArmor = true;
            player.setBonus = "Deals " + ((int)((1 + (player.statDefense / 2)) * player.minionDamage)).ToString() + " minion damage upon getting hit, the damage is also upgraded by defense.";
        }
    }
}