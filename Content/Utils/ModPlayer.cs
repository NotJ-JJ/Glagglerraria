using Terraria;
using Terraria.ModLoader;

namespace Glagglerraria.Content.Utils
{
    public class CustomPlayerVariable : ModPlayer
    {
        public int Gembladeparry = 0;
        public int GlooberHeal = 0;
        public int GuitarGloobleSummon = 0;
        public NPC target;

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
            GuitarGloobleSummon--;
            Gembladeparry--;
            GlooberHeal--;
        }

        public void hitnpc(ref NPC.HitInfo info)
		{
			target.active = true;
            info.Knockback = 0;
			info.Damage = 0;
            target.life++;
            if (target.life>target.lifeMax)target.life=target.lifeMax;
		}
    }
}