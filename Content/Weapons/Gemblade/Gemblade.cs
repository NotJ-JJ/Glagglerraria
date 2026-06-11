using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
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
            CustomPlayerVariable2 modPlayer = player.GetModPlayer<CustomPlayerVariable2>();

			if (modPlayer.parrytime <= -20)
			{
				if (player.altFunctionUse == 2)
            {
				Item.damage = 0;
				modPlayer.parrytime = 15;
				Item.useStyle = ItemUseStyleID.Guitar;
            }
            else
            {
				Item.damage = 35;
				Item.useStyle = ItemUseStyleID.Swing;
            }
			}
			return base.UseItem(player);
        }

		public class CustomPlayerVariable2 : ModPlayer
        {
            public override void OnHitByNPC(NPC npc, Player.HurtInfo hurtInfo)
            {
                if (parrytime > 0)
				{
					npc.SimpleStrikeNPC(hurtInfo.Damage*2,0,false,5f,DamageClass.Melee,false,0,false);
					Player.immuneTime = parrytime+10;
					Player.statLife += hurtInfo.Damage;
				}
            }

			public int parrytime = 15;
            public override void ResetEffects()
            {
                parrytime--;
            }
        }
	}
}