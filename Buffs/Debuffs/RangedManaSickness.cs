using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClassOverhaul.Buffs.Debuffs
{
    public class RangedManaSickness : ModBuff
    {
        float percent = 0f;
        public override void SetDefaults()
        {
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
            tip = string.Format(Language.GetTextValue("Mods.ClassOverhaul.BuffDescription.RangedManaSickness"), (int)(percent * 100));
        }
    }
}
