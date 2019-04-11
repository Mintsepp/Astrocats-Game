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
using FlatRedBall.Localization;



namespace SpaceGame.Screens
{
	public partial class PlayMenu
	{

        public static int selectedSave;

		void CustomInitialize()
		{
            GetSaveData();
		}

		void CustomActivity(bool firstTimeCalled)
		{


		}

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void GetSaveData()
        {
            //Saved data for slot 1
            this.SelectSaveButton1.AstericeNumberText = Game1.save1.Data.astericeNumber.ToString();
            this.SelectSaveButton1.PlanetsNumberText = Game1.save1.Data.planetNumber.ToString();
            this.SelectSaveButton1.UpgradesNumberText = Game1.save1.Data.upgradeNumber.ToString();
            
            //Saved data for slot 2
            this.SelectSaveButton2.AstericeNumberText = Game1.save2.Data.astericeNumber.ToString();
            this.SelectSaveButton2.PlanetsNumberText = Game1.save2.Data.planetNumber.ToString();
            this.SelectSaveButton2.UpgradesNumberText = Game1.save2.Data.upgradeNumber.ToString();

            //Saved data for slot 3
            this.SelectSaveButton3.AstericeNumberText = Game1.save3.Data.astericeNumber.ToString();
            this.SelectSaveButton3.PlanetsNumberText = Game1.save3.Data.planetNumber.ToString();
            this.SelectSaveButton3.UpgradesNumberText = Game1.save3.Data.upgradeNumber.ToString();
        }

	}
}
