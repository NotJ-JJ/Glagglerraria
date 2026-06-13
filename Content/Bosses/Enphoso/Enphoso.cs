using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Glagglerraria.Content.Bosses.Enphoso
{
    [AutoloadBossHead]
    internal class Enphoso : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.boss = true;
            NPC.damage = 1000;
            NPC.lifeMax = 80000;
            NPC.life = 80000;
            NPC.defense = 30;
            NPC.width = 64;
            NPC.height = 64;
            NPC.scale = 2;
            NPC.noGravity = true;
            NPC.lavaImmune = true;
            Music = MusicID.Mushrooms;
            NPC.value = Item.buyPrice(gold:3,silver:50);
            NPC.knockBackResist = 0;
            NPC.HitSound = SoundID.NPCHit3;
            NPC.DeathSound = SoundID.NPCDeath40;
            NPC.noTileCollide = true;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        int moveTimer = 150;
        int laserTimer = 30;
        int move = 1;
        float angle = 0;

        public override void AI()
        {
            moveTimer--;
            laserTimer--;

            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active){
                NPC.TargetClosest(true);
            }

            Player target = Main.player[NPC.target];
            if (target.dead){ // DESPAWN
                NPC.velocity.Y = -14f;
                NPC.EncourageDespawn(5);
                return;
            }

            if (move == 1){ // FLOAT ABOVE ATTACK
                FloatAbovePlayer(target.Center, NPC, 15, 30, target.Center + new Vector2(0, -500), 270,1);

                if (laserTimer <= 0){
                    float lifeRatio = (float)NPC.life / (float)NPC.lifeMax;
                    laserTimer = (int) MathHelper.Lerp(23,10,1 - lifeRatio);
                    ShootProjectile(NPC.GetSource_FromAI(), target.Center, 20, ProjectileID.AncientDoomProjectile, false, 1, 0, 0, NPC.Center, 0, 50);
                }
            }else if (move == 2){ // FLOAT SIDE ATTACK
                Vector2 left = target.Center + new Vector2(-500, 0);
                Vector2 right = target.Center + new Vector2(500, 0);

                float leftDistance = (NPC.Center - right).Length();
                float rightDistance = (left - NPC.Center).Length();

                if (leftDistance < rightDistance){
                    angle = -60;
                    FloatAbovePlayer(target.Center, NPC, 35, 30, right, 270, 0);
                }else{
                    angle = 130;
                    FloatAbovePlayer(target.Center, NPC, 35, 30, left, 270, 0);
                }

                if (laserTimer <= 0){
                    float lifeRatio = (float)NPC.life / (float)NPC.lifeMax;
                    laserTimer = (int) MathHelper.Lerp(25,1,1 - lifeRatio);
                    ShootProjectile(NPC.GetSource_FromAI(), target.Center, 18, ProjectileID.AncientDoomProjectile, false, 1, 0, 0, NPC.Center, 3, (int) MathHelper.Lerp(65,30,1 - lifeRatio));
                }
            }else if (move == 3){ // SPIN AROUND ATTACK
                angle+=3;
                float lifeRatio = (float)NPC.life / (float)NPC.lifeMax;
                float movespeed = (int) MathHelper.Lerp(25,40,1 - lifeRatio);
                FloatAbovePlayer(target.Center, NPC, movespeed, 5, target.Center + new Vector2(1, 1).RotatedBy(MathHelper.ToRadians(angle))*400, 270, 0);

                if (laserTimer <= 0){
                    laserTimer = (int) MathHelper.Lerp(16,6,1 - lifeRatio);
                    ShootProjectile(NPC.GetSource_FromAI(), target.Center, 23, ProjectileID.AncientDoomProjectile, false, 1, 0, 0, NPC.Center, 2, 40);
                }
            }

            if (moveTimer <= 0){ // CHANGE ATTACKS
                if (move == 1){
                    moveTimer = 250;
                    move++;
                }else if (move == 2){
                    moveTimer = 600;
                    move++;
                }else if (move == 3){
                    moveTimer = 200;
                    angle = 0;
                    move=1;
                }
                
                float lifeRatio = (float)NPC.life / (float)NPC.lifeMax;
                if (lifeRatio < 0.5f){ // Move faster below half hp
                    moveTimer = (moveTimer/3)+50;
                }
            }
        }

        public static void FloatAbovePlayer(Vector2 lookAtPosition, NPC NPC, float speed, float inertia, Vector2 destination, float radians, float fault)
        {
            if (NPC.WithinRange(destination, fault)){
                NPC.velocity *= 0.85f;
                return;
            }

            Vector2 toPlayer = lookAtPosition - NPC.Center;
            Vector2 toAbovePlayer = destination - NPC.Center;
            Vector2 toAbovePlayerNormalized = toAbovePlayer.SafeNormalize(Vector2.UnitY);

            Vector2 moveTo = toAbovePlayerNormalized * speed;
            NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;
            if (lookAtPosition != Vector2.Zero){
                NPC.rotation = toPlayer.ToRotation() + MathHelper.ToRadians(radians);
            }

        }

        public static void ShootProjectile(IEntitySource source, Vector2 targetPosition, float speed, int type, bool hasTileCollide, int count, float startAngle, float angleDecrement, Vector2 startPosition, float radius, int damage)
        {
            Vector2 distance = targetPosition - startPosition;
            Vector2 distanceNormalized = distance.SafeNormalize(Vector2.UnitX);
            float angle = startAngle;
            for (int i = 0; i < count; i++){
                int projectile = Projectile.NewProjectile(source, startPosition, (distanceNormalized.RotatedBy(MathHelper.ToRadians(angle)) * speed).RotatedByRandom(MathHelper.ToRadians(radius)), type, damage, 1);

                Main.projectile[projectile].tileCollide = hasTileCollide;
                Main.projectile[projectile].friendly = false;
                Main.projectile[projectile].hostile = true;
                angle -= angleDecrement;
            }
        }
    }
}