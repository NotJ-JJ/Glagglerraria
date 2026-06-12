using Glagglerraria.Content.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Weapons.Gemblade
{
	public class Gemblade : ModItem
	{
		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 35;
			Item.knockBack = 8;
			Item.crit = 16;
			Item.value = Item.buyPrice(silver:50);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
		}

		public override bool AltFunctionUse(Player player) => true;
		public override bool? UseItem(Player player)
        {
            CustomPlayerVariable modPlayer = player.GetModPlayer<CustomPlayerVariable>();
			if (modPlayer.Gembladeparry <= -20)
			{
				if (player.altFunctionUse == 2)
            {
				modPlayer.Gembladeparry = 15;
				Item.useStyle = ItemUseStyleID.Guitar;
				Item.noMelee = true;
            }
            else
            {
				Item.noMelee = false;
				Item.useStyle = ItemUseStyleID.Swing;
            }
			}
			return base.UseItem(player);
        }
	}
}