using Glagglerraria.Content.Projectiles.GoobabGunBullet;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Items.Ammo.GoobabGunAmmo
{
	public class GoobabGunAmmo : ModItem
	{
		public override void SetDefaults() {
			Item.width = 14;
			Item.height = 14;

			Item.damage = 9;
			Item.DamageType = DamageClass.Ranged;

			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.knockBack = 1f;
			Item.value = Item.buyPrice(copper:5);
			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ModContent.ProjectileType<GoobabGunBullet>();

			Item.ammo = Item.type;
		}
	}
}
