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
	public partial class EnemyKamikaze
	{

        //Get player location, used for AI
        private float playerLocationX;
        private float playerLocationY;
        private EnemyKamikaze.VariableState enemyState;

        public float PlayerLocationX
        {
            set { playerLocationX = value; }
        }

        public float PlayerLocationY
        {
            set { playerLocationY = value; }
        }

        public EnemyKamikaze.VariableState EnemyState
        {
            set { this.CurrentState = value; }
        }

        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
		private void CustomInitialize()
		{
            this.RotationZ += FlatRedBallServices.Random.Next(0, 3);
        }

		private void CustomActivity()
		{
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
            //Check where player ship is and the distance to it
            double distanceToPlayer = Math.Sqrt(
                Math.Pow(System.Convert.ToDouble(this.X - playerLocationX),2) +
                Math.Pow(System.Convert.ToDouble(this.Y - playerLocationY),2));

            //If player ship is close enough to kamikaze then become hostile
            if (distanceToPlayer < Range)
            {
                //Start moving towards player ship
                this.XVelocity = Convert.ToSingle((playerLocationX - this.X) / distanceToPlayer) * MovementSpeed;
                this.YVelocity = Convert.ToSingle((playerLocationY - this.Y) / distanceToPlayer) * MovementSpeed;
                TurningActivity();
                ThrustersOn(true);
            } else
            {
                //Become dormant when player is far away
                this.XVelocity = 0;
                this.YVelocity = 0;
                ThrustersOn(false);
            }
        }

        private void ThrustersOn(bool b)
        {
            if (this.CurrentState.Equals(EnemyKamikaze.VariableState.DarkGrey))
            {
                this.ThrusterSprite1.Visible = b;
                this.ThrusterSprite2.Visible = b;
            } else if (this.CurrentState.Equals(EnemyKamikaze.VariableState.Metallic))
            {
                this.ThrusterSprite1.Visible = b;
            } else if (this.CurrentState.Equals(EnemyKamikaze.VariableState.Purple))
            {
                this.ThrusterSprite1.Visible = b;
            }
        }

        private void TurningActivity()
        {
            if (playerLocationY > this.Y)
            {
                this.RotationZ = System.Convert.ToSingle
                    (-Math.Atan(System.Convert.ToDouble
                    ((this.X - playerLocationX)) /
                    (this.Y - playerLocationY)));
            }
            else
            {
                this.RotationZ = System.Convert.ToSingle
                    (Math.PI - Math.Atan(System.Convert.ToDouble
                    ((this.X - playerLocationX)) /
                    (this.Y - playerLocationY)));
            }
        }

        public void Explode()
        {
            //Kamikaze explodes, creating an explosion and getting destroyed
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
