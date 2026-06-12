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
			if (player.altFunctionUse == 2)
            {	
				if (modPlayer.Gembladeparry <= -20)
				{
					modPlayer.Gembladeparry = 15;
				}
				Item.noMelee=true;
				Item.useStyle = ItemUseStyleID.Guitar;
				return true;
            }		
			Item.noMelee=false;
			Item.useStyle=ItemUseStyleID.Swing;
			return true;
        }

		public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (player.altFunctionUse == 2)
			{
				modifiers.HideCombatText();
				CustomPlayerVariable modplayer = player.GetModPlayer<CustomPlayerVariable>();
				modplayer.target = target;
				modifiers.ModifyHitInfo+=modplayer.hitnpc;
			}
        }
	}
}