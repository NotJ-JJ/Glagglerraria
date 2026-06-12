using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Glagglerraria.Content.Utils;
using Microsoft.Xna.Framework;

namespace Glagglerraria.Content.Weapons.GlooberSign
{
	public class GlooberSign : ModItem
	{
		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 6;
			Item.knockBack = 4;
			Item.crit = 6;
			Item.value = Item.buyPrice(silver:50);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
		}

		public override bool AltFunctionUse(Player player) => true;
        public override bool? UseItem(Player player)
        {
			CustomPlayerVariable modplayer = player.GetModPlayer<CustomPlayerVariable>();
			if (player.altFunctionUse == 2)
            {	
				if (modplayer.GlooberHeal <= 0)
				{
					player.Heal(80);
					modplayer.GlooberHeal=1200;
				}
				Item.noMelee=true;
				Item.useStyle=ItemUseStyleID.HoldUp;
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