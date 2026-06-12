using Glagglerraria.Content.Items.Ammo.GoobabGunAmmo;
using Glagglerraria.Content.Projectiles.GoobabGunBullet;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Weapons.GoobabGun
{
	public class GoobabGun : ModItem
	{
		public override void SetDefaults() {
			Item.width = 42;
			Item.height = 30;

			Item.autoReuse = true;
			Item.damage = 30;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 4f;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Yellow;
			Item.shootSpeed = 10f;
			Item.useAnimation = 26;
			Item.useTime = 26;
			Item.UseSound = SoundID.Item11;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.buyPrice(gold: 1);

			Item.shoot = ModContent.ProjectileType<GoobabGunBullet>();
			Item.useAmmo = ModContent.ItemType<GoobabGunAmmo>();
		}
	}
}
