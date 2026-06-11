using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Weapons.GlaaberClub
{
	public class GlaaberClub : ModItem
	{
		public override void SetDefaults() {
			Item.width = 50;
			Item.height = 50;
			Item.scale = 1.25f;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.autoReuse = true;

			Item.DamageType = DamageClass.Melee;
			Item.damage = 80;
			Item.knockBack = 8;
			Item.crit = 6;

			Item.value = Item.buyPrice(silver:50);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
		}

        public override void HoldItem(Player player)
        {
			player.statDefense += 8;
            player.moveSpeed *= 0.9f;
        }
	}
}