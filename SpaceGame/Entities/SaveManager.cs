using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Manages a save file for you.
    /// </summary>
    public abstract class SaveManager
    {
        protected string folderName, fileName;

        /// <summary>
        /// Access save game data.
        /// </summary>
        public SaveData Data { get; set; }

        /// <summary>
        /// Creates a new save game manager.
        /// </summary>
        /// <param name="folderName">Name of the folder containing the save.</param>
        /// <param name="fileName">Name of the save file.</param>
        public SaveManager(string folderName, string fileName)
        {
            this.folderName = folderName;
            this.fileName = fileName;
            this.Data = new SaveData();
        }

        /// <summary>
        /// Loads the data from disk to memory.
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// Saves the data in memory to disk.
        /// </summary>
        public abstract void Save();
    }
}


namespace SpaceGame.Entities
{
	public partial class SaveManager
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
