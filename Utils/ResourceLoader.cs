﻿using Entrogic.Items.Weapons.Card.Elements;
using Entrogic.Items.Weapons.Card.Organisms;
using Entrogic.NPCs.Boss.AntaGolem;
using Entrogic.NPCs.Boss.PollutElement;
using Entrogic.NPCs.CardMerchantSystem;
using Entrogic.Shaders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Entrogic
{
	public static class ResourceLoader
	{
		public static int OldGlowMasksLength;

		public static void LoadAllTextures()
		{
			try
			{
				Entrogic.ModTexturesTable.Clear();
				LoadTextures();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
        private static void LoadTexture(string name)
        {
            Entrogic.ModTexturesTable.Add(name.Substring(7), Entrogic.Instance.GetTexture(name));

            //string directPath = $"{Entrogic.ModFolder}TextureLoad{Path.DirectorySeparatorChar}";
            //Directory.CreateDirectory(directPath);
            //string path = $"{directPath}{name.Substring(7)}.xnb";
            //File.Create(path);
        }
		private static void LoadTextures()
		{
			IDictionary<string, Texture2D> textures = (IDictionary<string, Texture2D>)typeof(Mod).GetField("textures",
				System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(Entrogic.Instance);

			var names = textures.Keys.Where((name) =>
			{
				return name.StartsWith("Images/");
			});
			foreach (var name in names)
				LoadTexture(name);
		}
		public static void LoadAllCardMissions()
		{
			try
			{
				Entrogic.CardQuests.Clear();
				LoadMissions();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private static void LoadMissions()
		{
			// 下面这行参数从左到右分别是：任务文本, 相关Boolean, 感谢词
			Quest quest = new ZeroQuest();
			Entrogic.CardQuests.Add(quest);
			quest = new NoviceCard();
			Entrogic.CardQuests.Add(quest);
		}
		public static void LoadAllShaders()
		{
			try
			{
				PixelShader = null;
				MagicMissile = null;
				LoadShaders();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		public static Effect PixelShader;
		public static EMiscShaderData MagicMissile;
		private static void LoadShaders()
		{
			Filters.Scene["Entrogic:RainyDaysScreen"] = new Filter(new PollutionElementalScreenShaderData("FilterMiniTower").UseColor(0.2f, 0.2f, 0.4f).UseOpacity(0.3f), EffectPriority.VeryHigh);
			SkyManager.Instance["Entrogic:RainyDaysScreen"] = new RainyDaysScreen();
			Filters.Scene["Entrogic:GrayScreen"] = new Filter(new AthanasyScreenShaderData("FilterMiniTower").UseColor(0.2f, 0.2f, 0.2f).UseOpacity(0.7f), EffectPriority.High);
			SkyManager.Instance["Entrogic:GrayScreen"] = new GrayScreen();
			Filters.Scene["Entrogic:MagicStormScreen"] = new Filter(new ScreenShaderData("FilterBloodMoon").UseColor(-0.4f, -0.2f, 1.6f).UseOpacity(0.6f), EffectPriority.Medium);
			SkyManager.Instance["Entrogic:MagicStormScreen"] = new MagicStormScreen();
			GameShaders.Misc["ExampleMod:DeathAnimation"] = new MiscShaderData(new Ref<Effect>(Entrogic.Instance.GetEffect("Effects/ExampleEffectDeath")), "DeathAnimation").UseImage("Images/Misc/Perlin");
			GameShaders.Misc["Entrogic:WhiteBlur"] = new MiscShaderData(new Ref<Effect>(Entrogic.Instance.GetEffect("Effects/WhiteBlur")), "WhiteBlur");
			//GameShaders.Misc["Entrogic:PixelShader"] = new MiscShaderData(new Ref<Effect>(GetEffect("Effects/PixelShader")), "PixelShader");
			// First, you load in your shader file.
			// You'll have to do this regardless of what kind of shader it is,
			// and you'll have to do it for every shader file.
			// This example assumes you have screen shaders.
			Ref<Effect> screenRef = new Ref<Effect>(Entrogic.Instance.GetEffect("Effects/IceScreen"));
			Filters.Scene["Entrogic:IceScreen"] = new Filter(new ScreenShaderData(screenRef, "IceScreen"), EffectPriority.High);
			Filters.Scene["Entrogic:IceScreen"].Load();
			Ref<Effect> screenRef2 = new Ref<Effect>(Entrogic.Instance.GetEffect("Effects/ReallyDark"));
			Filters.Scene["Entrogic:ReallyDark"] = new Filter(new ScreenShaderData(screenRef2, "ReallyDark"), EffectPriority.VeryHigh);
			Filters.Scene["Entrogic:ReallyDark"].Load();
			Ref<Effect> screenRef3 = new Ref<Effect>(Entrogic.Instance.GetEffect("Effects/GooddShader"));
			Filters.Scene["Entrogic:GooddShader"] = new Filter(new ScreenShaderData(screenRef3, "GooddShader"), EffectPriority.VeryHigh);
			Filters.Scene["Entrogic:GooddShader"].Load();
			Filters.Scene["Entrogic:Blur"] = new Filter(new ScreenShaderData(new Ref<Effect>(Entrogic.Instance.GetEffect("Effects/Blur")), "Blur"), EffectPriority.VeryHigh);
			Filters.Scene["Entrogic:Blur"].Load();


			PixelShader = Entrogic.Instance.GetEffect("Effects/PixelShader");
			MagicMissile = new EMiscShaderData(new Ref<Effect>(PixelShader), "MagicMissile").UseProjectionMatrix(true);
			MagicMissile.UseImage0(Entrogic.ModTexturesTable["MagicMissile2"]);
			MagicMissile.UseImage1(Entrogic.ModTexturesTable["MagicMissile0"]);
			MagicMissile.UseImage2(Entrogic.ModTexturesTable["MagicMissile1"]);
		}
	}
}
