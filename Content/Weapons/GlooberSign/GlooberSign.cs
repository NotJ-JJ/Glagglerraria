using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Glagglerraria.Content.Weapons.GlooberSign
{
	public class GlooberSign : ModItem
	{

		public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
        }
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
			CustomPlayerVariable ModPlayer = player.GetModPlayer<CustomPlayerVariable>();
            if (ModPlayer.Cooldown <= 0)
            {
                player.Heal(50);
				ModPlayer.Cooldown = 1200;
            }
			return base.UseItem(player);
        }

		public class CustomPlayerVariable : ModPlayer
    	{
			public int Cooldown = 1200;
            public override void ResetEffects()
            {
				Cooldown--;
            }
    	}
	}
}