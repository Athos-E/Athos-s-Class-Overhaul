using Terraria;
using Terraria.ModLoader;

namespace ClassOverhaul.Buffs.Debuffs
{
    public class RangedManaSickness : ModBuff
    {
        float percent = 0f;
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mana Sickness (Ranged)");
            Description.SetDefault("Ranged damage reduced by " + 0f + "%");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
        }

        public float rangedReduction(Player player, ref int buffIndex)
            => (player.buffTime[buffIndex] > 600 ? 600 : player.buffTime[buffIndex]) / 24 * 0.01f;

        public override void Update(Player player, ref int buffIndex)
        {
            percent = rangedReduction(player, ref buffIndex);
            player.rangedDamageMult *= 1f - rangedReduction(player, ref buffIndex);
        }

        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            tip = "Ranged damage reduced by " + (int)(percent * 100) + "%";
        }
    }
}
