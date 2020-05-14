using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.Items.Materials
{
    public class EvilScales : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.material = true;
            item.value = Item.sellPrice(silver: 50);
            item.height = 22;
            item.width = 18;
        }
    }
}
