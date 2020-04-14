﻿using System;
using Terraria;
using Terraria.Localization;
using Terraria.ID;
using System.Text;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Entrogic.NPCs.Boss.凝胶Java盾.Projectiles
{
    /// <summary>
    /// 凝胶蜂刺 的摘要说明
    /// 创建人机器名：DESKTOP-QDVG7GB
    /// 创建时间：2019/8/6 21:48:35
    /// </summary>
    public class 凝胶蜂刺 : ModProjectile
    {
        int cloneProj = 38;
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = Main.projFrames[cloneProj];
        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(cloneProj);
            aiType = cloneProj;
            projectile.alpha = 30;
            projectile.tileCollide = false;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.NextBool(2))
                target.AddBuff(BuffType<Buffs.Enemies.溶解>(), Main.rand.Next(240, 361));
        }
    }
}
