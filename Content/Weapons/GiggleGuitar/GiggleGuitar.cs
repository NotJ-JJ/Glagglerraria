using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Weapons.GiggleGuitar
{
	public class GiggleGuitar : ModItem
	{
		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 18;
			Item.knockBack = 5;
			Item.crit = 12;
			Item.value = Item.buyPrice(silver:50);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Confused,120);
		}

		//add the glooble im too lazy rn
	}
}