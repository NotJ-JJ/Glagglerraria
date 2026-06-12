using Terraria;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Utils
{
    public class CustomPlayerVariable : ModPlayer
    {
        public int Gembladeparry = 15;
        public int GlooberHeal = 1200;

        public override void OnHitByNPC(NPC npc, Player.HurtInfo hurtInfo)
        {
            if (Gembladeparry > 0)
			{
				npc.SimpleStrikeNPC(hurtInfo.Damage*2,0,false,5f,DamageClass.Melee,false,0,false);
				Player.immuneTime = Gembladeparry+10;
				Player.statLife += hurtInfo.Damage;
			}
        }

        public override void ResetEffects()
        {
            Gembladeparry--;
            GlooberHeal--;
        }
    }
}