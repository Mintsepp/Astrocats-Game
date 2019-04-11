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
	public partial class EnemySpinner
	{

        //Get player location, used for AI
        private float playerLocationX;
        private float playerLocationY;
        private EnemySpinner.VariableState enemyState;

        public float PlayerLocationX
        {
            set { playerLocationX = value; }
        }

        public float PlayerLocationY
        {
            set { playerLocationY = value; }
        }

        public EnemySpinner.VariableState EnemyState
        {
            set { this.CurrentState = value; }
        }

        double mLastSpawnTime;
        private bool IsTimeToSpawn
        {
            get
            {
                return FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(mLastSpawnTime) > 1.0/BulletsPerSecond;
            }
        }

        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
		private void CustomInitialize()
		{

		}

		private void CustomActivity()
		{
            MovementActivity();
            TurningActivity();
            ShootingActivity();
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
            //no movement yet
        }

        private void TurningActivity()
        {
            this.RotationZVelocity = System.Convert.ToSingle(TurningSpeed/100.0);
        }

        private void ShootingActivity()
        {
            if (IsTimeToSpawn)
            {
                SpawnBullet();
                mLastSpawnTime = FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;
            }
        }

        private void SpawnBullet()
        {
            Bullet bullet = BulletFactory.CreateNew();
            if (CurrentState.Equals(EnemySpinner.VariableState.DarkGrey))
            {
                bullet.CurrentState = Bullet.VariableState.Bullet5;
            } else if (CurrentState.Equals(EnemySpinner.VariableState.Metallic))
            {
                bullet.CurrentState = Bullet.VariableState.Bullet6;
            } else if (CurrentState.Equals(EnemySpinner.VariableState.Purple))
            {
                bullet.CurrentState = Bullet.VariableState.Bullet7;
            }
            bullet.Position = this.Position + this.RotationMatrix.Up * 25;
            bullet.RotationZ = this.RotationZ;
            bullet.Velocity = this.RotationMatrix.Up * bullet.MovementSpeed;
        }

        public void Explode()
        {
            //Spinner explodes, creating an explosion and getting destroyed
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
                asterice.Velocity += asterice.RotationMatrix.Up * (200 + distance*2);
                asterice.Acceleration = asterice.RotationMatrix.Up * -300;

            }
        }
	}
}
