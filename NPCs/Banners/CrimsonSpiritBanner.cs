﻿using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Entrogic.NPCs.Banners
{
    public class CrimsonSpiritBanner : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.createTile = TileType<MonsterBanner>();
            item.placeStyle = 0;
        }
    }
}