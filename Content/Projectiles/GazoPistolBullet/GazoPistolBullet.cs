using Terraria;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Projectiles.GazoPistolBullet
{
	public class GazoPistolBullet : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.ignoreWater = true;
			Projectile.light = 1f;
			Projectile.timeLeft = 600;
		}
	}
}
