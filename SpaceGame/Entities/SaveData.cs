using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;

namespace MonoGameSaveManager
{
    /// <summary>
    /// Container for your save game data.
    /// Put the variables you need here, as long as it's serializable.
    /// </summary>
    [Serializable]
    public class SaveData
    {
        public int astericeNumber;
        public int planetNumber;
        public int upgradeNumber;
        public bool upgradeLaser;

        //Map1 visited paths
        public bool m1p1_2;
        public bool m1p1_3;
        public bool m1p3_4;
        public bool m1p3_5;
        public bool m1p5_6;
        public bool m1p2_6;
    }
}

namespace SpaceGame.Entities
{
	public partial class SaveData
	{
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


		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}
