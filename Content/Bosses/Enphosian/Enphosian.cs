using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Glagglerraria.Content.Bosses.Enphosian
{
    [AutoloadBossHead]
    internal class Enphosian : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.boss = true;
            NPC.damage = 25;
            NPC.lifeMax = 2000;
            NPC.life = 2000;
            NPC.defense = 3;
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

        int moveTimer = 400;
        int laserTimer = 50;
        int move = 1;
        int movedir = 1;
        float angle = 0;
        public override void AI()
        {
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest(true);
            }

            Player target = Main.player[NPC.target];

            if (target.dead) // DESPAWN
            {
                NPC.velocity.Y = -14f;
                NPC.EncourageDespawn(5);
                return;
            }

            moveTimer--;
            laserTimer--;
            if (move == 1) // FLOAT ABOVE ATTACK
            {
                FloatAbovePlayer(target.Center, NPC, 15, 30, target.Center + new Vector2(0, -350), 270,1);

                if (laserTimer <= 0)
                {
                    float lifeRatio = (float)NPC.life / (float)NPC.lifeMax;
                    laserTimer = (int) MathHelper.Lerp(50,35,1 - lifeRatio);
                    ShootProjectile(NPC.GetSource_FromAI(), target.Center, 7, ProjectileID.CultistBossFireBallClone, false, 1, 0, 0, NPC.Center, 10, 15);
                }
            }
            else if (move == 2) // FLOAT SIDE ATTACK
            {
                Vector2 left = target.Center + new Vector2(-500, 0);
                Vector2 right = target.Center + new Vector2(500, 0);

                float leftDistance = (NPC.Center - right).Length();
                float rightDistance = (left - NPC.Center).Length();

                if (leftDistance < rightDistance)
                {
                    movedir = 1;
                    angle = -60;
                    FloatAbovePlayer(target.Center, NPC, 15, 30, right, 270, 0);
                }
                else
                {
                    movedir = 2;
                    angle = 130;
                    FloatAbovePlayer(target.Center, NPC, 15, 30, left, 270, 0);
                }

                if (laserTimer <= 0)
                {
                    float lifeRatio = (float)NPC.life / (float)NPC.lifeMax;
                    laserTimer = (int) MathHelper.Lerp(30,3,1 - lifeRatio);
                    ShootProjectile(NPC.GetSource_FromAI(), target.Center, 10, ProjectileID.AncientDoomProjectile, false, 1, 0, 0, NPC.Center, 5, (int) MathHelper.Lerp(25,10,1 - lifeRatio));
                }
            }
            else if (move == 3) // ROTATE AROUND ATTACK
            {
                angle+=2; // 0.75 seconds to rotate 90 degrees
                if (movedir == 1)
                {
                    FloatAbovePlayer(target.Center, NPC, 13, 10, target.Center + new Vector2(1, 1).RotatedBy(MathHelper.ToRadians(angle))*380, 270, 0);
                }
                else
                {
                    FloatAbovePlayer(target.Center, NPC, 13, 10, target.Center + new Vector2(1, 1).RotatedBy(MathHelper.ToRadians(angle))*350, 270, 0);
                }

                if (laserTimer <= 0)
                {
                    float lifeRatio = (float)NPC.life / (float)NPC.lifeMax;
                    laserTimer = (int) MathHelper.Lerp(25,10,1 - lifeRatio);
                    ShootProjectile(NPC.GetSource_FromAI(), target.Center, 10, ProjectileID.AncientDoomProjectile, false, 1, 0, 0, NPC.Center, 5, (int) MathHelper.Lerp(25,10,1 - lifeRatio));
                }
            }

            if (moveTimer == 0) // CHANGE ATTACKS
            {
                float lifeRatio = (float)NPC.life / (float)NPC.lifeMax;
                
                if (move == 1)
                {
                    laserTimer = (int) MathHelper.Lerp(30,3,1 - lifeRatio);
                    moveTimer = 300;

                    move = 2;
                }
                else if (move == 2) //SPNN
                {
                    moveTimer = 200;
                    laserTimer = (int) MathHelper.Lerp(25,10,1 - lifeRatio);
                    
                    move = 3;
                }
                else if (move == 3)
                {
                    angle = 0;
                    moveTimer = 400;
                    laserTimer = (int) MathHelper.Lerp(50,35,1 - lifeRatio);

                    move = 1;
                }
                
                if (lifeRatio < 0.5f) // Move faster below half hp
                {
                    moveTimer = (moveTimer/2)+50;
                }
            }
        }

        public static void FloatAbovePlayer(Vector2 lookAtPosition, NPC NPC, float speed, float inertia, Vector2 destination, float radians, float fault)
        {
            if (NPC.WithinRange(destination, fault))
            {
                NPC.velocity *= 0.85f;
                return;
            }

            Vector2 toPlayer = lookAtPosition - NPC.Center;
            Vector2 toAbovePlayer = destination - NPC.Center;
            Vector2 toAbovePlayerNormalized = toAbovePlayer.SafeNormalize(Vector2.UnitY);

            Vector2 moveTo = toAbovePlayerNormalized * speed;
            NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;
            if (lookAtPosition != Vector2.Zero)
            {
                NPC.rotation = toPlayer.ToRotation() + MathHelper.ToRadians(radians);
            }

        }

        public static void ShootProjectile(IEntitySource source, Vector2 targetPosition, float speed, int type, bool hasTileCollide, int count, float startAngle, float angleDecrement, Vector2 startPosition, float radius, int damage)
        {
            Vector2 distance = targetPosition - startPosition;
            Vector2 distanceNormalized = distance.SafeNormalize(Vector2.UnitX);
            float angle = startAngle;
            for (int i = 0; i < count; i++)
            {
                int projectile = Projectile.NewProjectile(source, startPosition, (distanceNormalized.RotatedBy(MathHelper.ToRadians(angle)) * speed).RotatedByRandom(MathHelper.ToRadians(radius)), type, damage, 1);

                Main.projectile[projectile].tileCollide = hasTileCollide;
                Main.projectile[projectile].friendly = false;
                Main.projectile[projectile].hostile = true;
                angle -= angleDecrement;
            }
        }
    }
}