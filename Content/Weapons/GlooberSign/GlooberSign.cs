using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Glagglerraria.Content.Utils;

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

        public override bool? UseItem(Player player)
        {
			CustomPlayerVariable modplayer = player.GetModPlayer<CustomPlayerVariable>();
            if (modplayer.GlooberHeal <= 0)
            {
                player.Heal(50);
				modplayer.GlooberHeal = 1200;
            }
			return base.UseItem(player);
        }
	}
}