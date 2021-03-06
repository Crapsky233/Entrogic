﻿using System;

using Entrogic.Projectiles.衰落魔像;

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Entrogic.Items.AntaGolem
{
    public class RockSpear : ModItem
    {
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 22;
            item.useTime = 22;
            item.shootSpeed = 4.6f;
            item.knockBack = 5.8f;
            item.width = 56;
            item.height = 56;
            item.damage = 55;
            item.UseSound = SoundID.Item1;
            item.shoot = ProjectileType<RockSpearProj>();
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(0, 3, 50);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.melee = true;
        }
        public override void HoldItem(Player player)
        {
            item.autoReuse = true;
            base.HoldItem(player);
        }
    }
}