using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Weapons.RubberHammer
{
	public class RubberHammer : ModItem
	{
		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 38;
			Item.knockBack = 15;
			Item.crit = 12;
			Item.useTurn = true;
			Item.value = Item.buyPrice(silver:50);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			Projectile.NewProjectile(player.GetSource_FromThis(), target.position, Vector2.Zero, ProjectileID.Volcano, hit.Damage, hit.Knockback, player.whoAmI);
			Vector2 direction = (target.Center - player.Center).SafeNormalize(Vector2.UnitX);
			player.velocity	= new Vector2(14f, 20f) * -direction;
		}
	}
}