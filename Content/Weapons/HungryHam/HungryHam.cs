using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Weapons.HungryHam
{
	public class HungryHam : ModItem
	{
		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 10;
			Item.knockBack = 2;
			Item.crit = 6;
			Item.value = Item.buyPrice(silver:50);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
		}

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            player.Heal(damageDone);
        }
	}
}