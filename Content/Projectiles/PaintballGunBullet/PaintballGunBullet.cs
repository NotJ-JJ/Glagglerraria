using Terraria;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Projectiles.PaintballGunBullet
{
	public class PaintballGunBullet : ModProjectile
	{

		public ref float DelayTimer => ref Projectile.ai[1];

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
