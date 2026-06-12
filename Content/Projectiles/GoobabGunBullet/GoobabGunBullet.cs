using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Projectiles.GoobabGunBullet
{
	public class GoobabGunBullet : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
			Projectile.hostile = true;
			Projectile.ignoreWater = true;
			Projectile.light = 1f;
			Projectile.timeLeft = 600;
		}

		Player target2;
        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
			if (target!=Main.player[Projectile.owner])
			{
				modifiers.ArmorPenetration+=999;
			modifiers.DisableSound();
			modifiers.SourceDamage*=0.2f;
			target2 = target;
			modifiers.ModifyHurtInfo+=hitplayer;
			}
        }

		private void hitplayer(ref Player.HurtInfo info)
		{
			target2.HealEffect(info.Damage);
			if ((target2.statLife+=info.Damage)>=target2.statLifeMax2)
			{
				target2.statLife=target2.statLifeMax2;
			}
			else
			{
				target2.statLife+=info.Damage;
			}
			info.Damage = 0;
			info.Cancelled = true;
		}

		NPC target3;
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
			if (target.townNPC)
			{
				modifiers.DefenseEffectiveness *= 0f;
				modifiers.HideCombatText();
				target3 = target;
				modifiers.ModifyHitInfo+=hitnpc;
			}
        }

		private void hitnpc(ref NPC.HitInfo info)
		{
			target3.HealEffect(info.Damage);
			if ((target3.life+=info.Damage*2)>=target3.lifeMax)
			{
				target3.life = target3.lifeMax;
			}
			else
			{
				target3.life += info.Damage*2;
			}
			target3.active = true;
			info.Damage = 0;
		}
	}
}
