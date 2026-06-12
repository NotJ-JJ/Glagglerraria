using Glagglerraria.Content.Items.Ammo.GigglePistolAmmo;
using Glagglerraria.Content.Projectiles.GigglePistolBullet;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Weapons.GigglePistol
{
	public class GigglePistol : ModItem
	{
		public override void SetDefaults() {
			Item.width = 42;
			Item.height = 30;
			Item.autoReuse = true;
			Item.damage = 16;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 4f;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Yellow;
			Item.shootSpeed = 15;
			Item.useAnimation = 26;
			Item.useTime = 26;
			Item.UseSound = SoundID.Item11;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.buyPrice(gold: 1);
			Item.shoot = ModContent.ProjectileType<GigglePistolBullet>();
			Item.useAmmo = ModContent.ItemType<GigglePistolAmmo>();
		}
	}
}
