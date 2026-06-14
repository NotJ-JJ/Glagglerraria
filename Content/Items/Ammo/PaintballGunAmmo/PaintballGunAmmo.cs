using Glagglerraria.Content.Projectiles.PaintballGunBullet;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Items.Ammo.PaintballGunAmmo
{
	public class PaintballGunAmmo : ModItem
	{
		public override void SetDefaults() {
			Item.width = 14;
			Item.height = 14;

			Item.damage = 4;
			Item.DamageType = DamageClass.Ranged;

			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.knockBack = 1f;
			Item.value = Item.buyPrice(copper:5);
			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ModContent.ProjectileType<PaintballGunBullet>();

			Item.ammo = Item.type;
		}
	}
}
