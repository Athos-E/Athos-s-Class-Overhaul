using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClassOverhaul.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class AdamantiteHood : ModItem
    {
        public override void SetDefaults()
        {
            ItemEdits globalItem = item.GetGlobalItem<ItemEdits>();
            globalItem.rogueItem = true;
            item.defense = 17;
            globalItem.magicDefense = 20;
            item.rare = 4;
            item.value = 30000;
            item.width = 18;
            item.height = 18;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.14f;
            player.thrownDamage += 0.23f;
            player.meleeSpeed += 0.20f;
            player.meleeCrit += 37;
            player.moveSpeed += 0.06f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.meleeSpeed += 0.40f;
            player.moveSpeed += 0.23f;
            player.thrownVelocity += 0.20f;
            player.setBonus = Language.GetTextValue("Mods.ClassOverhaul.ArmorSetBonus.AdamantiteRogue");
        }
    }
}
