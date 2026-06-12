using Glagglerraria.Content.Minions.GuitarGlooble;
using Glagglerraria.Content.Utils;
using Microsoft.Xna.Framework;
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

		public override bool AltFunctionUse(Player player) => true;
		public override bool? UseItem(Player player)
        {
			CustomPlayerVariable modPlayer = player.GetModPlayer<CustomPlayerVariable>();
			if (player.altFunctionUse == 2)
            {
				if (modPlayer.GuitarGloobleSummon < 0)
				{
					modPlayer.GuitarGloobleSummon=6000;
					Projectile.NewProjectile(player.GetSource_FromThis(),Item.Center,Vector2.Zero,ModContent.ProjectileType<GuitarGlooble>(),0,0,Main.myPlayer);
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