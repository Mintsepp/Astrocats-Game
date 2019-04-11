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

namespace SpaceGame.Entities
{

   

    public partial class Asterice
	{
        private static Random random = new Random();

        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        private void CustomInitialize()
		{
            ChooseTypeRandomly();
            Sprite.CurrentChainName = "Glimmer";
        }

		private void CustomActivity()
		{
            MovementActivity();
        }

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void MovementActivity()
        {
            double velocity = Math.Sqrt(
                Math.Pow(System.Convert.ToDouble(this.XVelocity), 2) +
                Math.Pow(System.Convert.ToDouble(this.YVelocity), 2));

            double acceleration = Math.Sqrt(
                Math.Pow(System.Convert.ToDouble(this.XAcceleration), 2) +
                Math.Pow(System.Convert.ToDouble(this.YAcceleration), 2));

            if (velocity < 20 & acceleration > 0)
            {
                this.Acceleration = this.RotationMatrix.Up * 0;
            }
            if (acceleration == 0)
            {
                this.Velocity = this.RotationMatrix.Up * 10;
            }
        }

        private void ChooseTypeRandomly()
        {
            int i = random.Next(0, 100);

            if (i < 40)
            {
                this.CurrentState = Asterice.VariableState.Orange;
            } else if (i < 60)
            {
                this.CurrentState = Asterice.VariableState.Purple;
            } else if (i < 95)
            {
                this.CurrentState = Asterice.VariableState.Yellow;
            } else if (i < 100)
            {
                this.CurrentState = Asterice.VariableState.Blue;
            }
        }
	}
}
