﻿using System;
using Terraria;
using Terraria.Localization;
using Terraria.ID;
using System.Text;
using Terraria.ModLoader;

namespace Entrogic.Buffs.Weapons
{
    public class NPCChilled : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("NPC Chilled");
            Description.SetDefault("Not for player");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<EntrogicNPC>().chilled = true;
        }
    }
}
