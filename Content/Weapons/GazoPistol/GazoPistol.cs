using Glagglerraria.Content.Projectiles.GazoPistolBullet;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Weapons.GazoPistol
{
	public class GazoPistol	 : ModItem
	{
		public override void SetDefaults() {
			Item.width = 42;
			Item.height = 30;
			Item.autoReuse = true;
			Item.damage = 25;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 2f;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Yellow;
			Item.shootSpeed = 10;
			Item.useAnimation = 36;
			Item.useTime = 36;
			Item.UseSound = SoundID.Item11;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.buyPrice(gold: 1);
			Item.shoot = ModContent.ProjectileType<GazoPistolBullet>();
		}
	}
}
