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
	public partial class CharacterMenu
	{

        public static int playerShip1;
        public static int playerShip2;
        public static int playerShip3;
        public static int playerShip4;

        private bool playerHasSelected1;
        private bool playerHasSelected2;
        private bool playerHasSelected3;
        private bool playerHasSelected4;

        void CustomInitialize()
		{
            GetSaveData();
            SetShipsToNotSelected();
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
            int i = PlayMenu.selectedSave;

            if (i == 1)
            {
                Game1.currentSave = Game1.save1;
            } else if (i == 2)
            {
                Game1.currentSave = Game1.save1;
            } else if (i == 3)
            {
                Game1.currentSave = Game1.save1;
            }
        }

        private void GetShipUpgrades()
        {

        }

        private void SetShipsToNotSelected()
        {
            playerShip1 = 0;
            playerShip2 = 0;
            playerShip3 = 0;
            playerShip4 = 0;

            playerHasSelected1 = false;
            playerHasSelected2 = false;
            playerHasSelected3 = false;
            playerHasSelected4 = false;
        }
	}
}
