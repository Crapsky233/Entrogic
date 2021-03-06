using Entrogic.Projectiles.Ammos;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Entrogic.Items.Miscellaneous.Ammo
{
	public class 量产型照明弹 : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("可以用于小范围照明\n" +
                "“简陋的工艺，过硬的品质”");
		}

		public override void SetDefaults()
		{
			item.damage = 4;
			item.ranged = true;
			item.width = 12;
			item.height = 18;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 1f;
            item.value = Item.sellPrice(copper: 20);
            item.rare = ItemRarityID.Green;
			item.shoot = ProjectileType<照明弹头>();
			item.shootSpeed = 8f;
			item.ammo = AmmoID.Bullet;
			}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Torch, 5);
			recipe.AddIngredient(ItemID.MusketBall, 125);
            recipe.AddIngredient(ItemID.Glass, 5);
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 125);
			recipe.AddRecipe();
		}
	}
}
