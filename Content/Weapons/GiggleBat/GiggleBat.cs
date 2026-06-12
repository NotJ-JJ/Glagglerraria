using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Weapons.GiggleBat
{
	public class GiggleBat : ModItem
	{
		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 15;
			Item.knockBack = 5;
			Item.crit = 12;
			Item.value = Item.buyPrice(silver:50);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			player.AddBuff(BuffID.Sunflower, 300);
		}
	}
}