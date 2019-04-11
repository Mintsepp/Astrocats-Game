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
using System.Threading.Tasks;

namespace SpaceGame.Entities
{
	public partial class Explosion
	{

        double mSpawnTime;
        private bool IsTimeToDisappear
        {
            get
            {
                return FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(mSpawnTime) > 1.1;
            }
        }

        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
		private void CustomInitialize()
		{
            //Play explosion sound when initialized
            mSpawnTime = FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;
        }

		private void CustomActivity()
		{

		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        public bool IsItTimeToDisappear()
        {
            return IsTimeToDisappear;
        }


        public async Task DestroyExplosion()
        {
            //Destroy explosion after duration has passed
            await Task.Delay(Duration);
            this.Destroy();
        }
	}
}