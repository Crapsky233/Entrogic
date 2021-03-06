﻿using Entrogic.NPCs.CardFightable.Particles;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

using Terraria;
using Terraria.ModLoader;

namespace Entrogic.NPCs.CardFightable.CardBullet
{
    public class MushroomBullet : CardFightBullet
    {
        public MushroomBullet()
        {
            _texture = ModContent.GetTexture("Entrogic/NPCs/CardFightable/CardBullet/MushroomBullet");
            LifeSpan = 6f;
            IsFriendly = false;
            Damage = 100;
            Size = new Vector2(_texture.Width, _texture.Height);
        }
        public override void Update(GameTime gameTime, Player attackPlayer, NPC attackNPC)
        {
            base.Update(gameTime, attackPlayer, attackNPC);
        }
    }
}
