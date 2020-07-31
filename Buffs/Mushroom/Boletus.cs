using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Entrogic.Buffs.Mushroom
{
    public class Boletus : MushroomBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeDamage += 0.35f;
        }
    }
}
