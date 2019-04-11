using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using SpaceGame.Factories;

namespace SpaceGame.Entities
{
	public partial class EnemyJumper
	{
        float topY;
        float botY;
        Random random;
        private bool leftBullet;
        double mLastSpawnTime;
        private bool IsTimeToSpawn
        {
            get
            {
                return FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(mLastSpawnTime) > 1.0 / BulletsPerSecond;
            }
        }

        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        private void CustomInitialize()
		{
            this.RotationZ = System.Convert.ToSingle(0.5 * Math.PI);
            leftBullet = true;
            this.random = new Random();
            this.YVelocity = -200;
            this.XVelocity = 50;
            GetNewTopY();
            GetNewBotY();
        }

		private void CustomActivity()
		{
            ShootingActivity();
            MovementActivity();
            HealthActivity();
		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void HealthActivity()
        {
            if (this.HealthPoints <= 0)
            {
                this.Explode();
            }
        }

        private void MovementActivity()
        {


            if (this.Y >= topY)
            {
                this.YVelocity = -200;
                GetNewBotY();
            } else if (this.Y <= botY)
            {
                this.YVelocity = 200;
                GetNewTopY();
            }
        }

        private void GetNewTopY()
        {
            topY = random.Next(System.Convert.ToInt32(this.Y + 100), 450);
        }

        private void GetNewBotY()
        {
            botY = random.Next(-450, System.Convert.ToInt32(this.Y - 100));
        }


        private void ShootingActivity()
        {
            if (IsTimeToSpawn)
            {
                if (this.CurrentState.Equals(EnemyJumper.VariableState.DarkGrey))
                {
                    SpawnBulletType1();
                }
                else if (this.CurrentState.Equals(EnemyJumper.VariableState.Metallic))
                {
                    SpawnBulletType2();
                }
                else if (this.CurrentState.Equals(EnemyJumper.VariableState.Purple))
                {
                    SpawnBulletType3();
                }

                mLastSpawnTime = FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;
            }
        }

        private void SpawnBulletType1()
        {
            int i = 1;
            if (leftBullet) {i = -1; ; leftBullet = false; }
            else { leftBullet = true; }

            Bullet bullet = BulletFactory.CreateNew();
            bullet.CurrentState = Bullet.VariableState.Bullet5;
            bullet.Position += this.Position + this.RotationMatrix.Up * 25;
            bullet.Position += this.RotationMatrix.Right * 7*i;
            bullet.RotationZ = this.RotationZ;
            bullet.Velocity = this.RotationMatrix.Up * bullet.MovementSpeed;

        }

        private void SpawnBulletType2()
        {
            int i = 1;
            if (leftBullet) { i = -1; ; leftBullet = false; }
            else { leftBullet = true; }

            Bullet bullet = BulletFactory.CreateNew();
            bullet.CurrentState = Bullet.VariableState.Bullet6;
            bullet.Position += this.Position + this.RotationMatrix.Up * 25;
            bullet.Position += this.RotationMatrix.Right * 7*i;
            bullet.RotationZ = this.RotationZ;
            bullet.Velocity = this.RotationMatrix.Up * bullet.MovementSpeed;

        }

        private void SpawnBulletType3()
        {
            int i = 1;
            if (leftBullet) {i = -1; leftBullet = false; }
            else { leftBullet = true; }

            Bullet bullet = BulletFactory.CreateNew();
            bullet.CurrentState = Bullet.VariableState.Bullet7;
            bullet.Position += this.Position + this.RotationMatrix.Up * 25;
            bullet.Position += this.RotationMatrix.Right * 5*i;
            bullet.RotationZ = this.RotationZ;
            bullet.Velocity = this.RotationMatrix.Up * bullet.MovementSpeed;

        }

        public void Explode()
        {
            //Jumper explodes, creating an explosion and getting destroyed
            Explosion explosion = ExplosionFactory.CreateNew();
            explosion.Position = this.Position;

            DropAsterices();

            this.Destroy();
        }

        private void DropAsterices()
        {
            Random r = new Random();
            int n = r.Next(1, 3);

            for (int i = 0; i < n; i++)
            {
                int angle = r.Next(0, 7);
                int distance = r.Next(5, 10);

                Asterice asterice = AstericeFactory.CreateNew();
                asterice.RotationZ = System.Convert.ToSingle(angle * 0.78539816339);
                asterice.Position = this.Position + asterice.RotationMatrix.Up * distance;
                asterice.Velocity += asterice.RotationMatrix.Up * (200 + distance * 2);
                asterice.Acceleration = asterice.RotationMatrix.Up * -300;

            }
        }
    }
}
