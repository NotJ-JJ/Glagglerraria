using Glagglerraria.Content.Projectiles.GiggleBullet;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Items.Ammo.GiggleBulletAmmo
{
	public class GiggleBulletAmmo : ModItem
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
			Item.shoot = ModContent.ProjectileType<GiggleBullet>();

			Item.ammo = Item.type; // Important. The first item in an ammo class sets the AmmoID to its type
		}
	}
}
