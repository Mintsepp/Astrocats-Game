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
	public partial class Map1
	{

        private int currentPlanet;

        void CustomInitialize()
		{
            currentPlanet = 1;
            GetSaveData();
            MarkVisitedPathsGreen();
        }

		void CustomActivity(bool firstTimeCalled)
		{
            PutGreenArrowAtCurrentPlanet();

		}

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void GetSaveData()
        {

        }

        private void MarkVisitedPathsGreen()
        {
            if (Game1.currentSave.Data.m1p1_2)
            {
                StripeBetweenPlanets1_2_red.Visible = false;
            }
            else if (Game1.currentSave.Data.m1p1_3)
            {
                StripeBetweenPlanets1_3_red.Visible = false;
            }
            else if (Game1.currentSave.Data.m1p3_4)
            {
                StripeBetweenPlanets3_4_red.Visible = false;
            }
            else if (Game1.currentSave.Data.m1p3_5)
            {
                StripeBetweenPlanets3_5_red.Visible = false;
            }
            else if (Game1.currentSave.Data.m1p5_6)
            {
                StripeBetweenPlanets5_6_red.Visible = false;
            }
            else if (Game1.currentSave.Data.m1p2_6)
            {
                StripeBetweenPlanets2_6_red.Visible = false;
            }
        }

        private void PutGreenArrowAtCurrentPlanet()
        {
            if (currentPlanet == 1)
            {
                PlayerIsHereArrow.X = 638 + 75;
                PlayerIsHereArrow.Y = 655 - 10;
            }
            else if (currentPlanet == 2)
            {
                PlayerIsHereArrow.X = 1197 + 75;
                PlayerIsHereArrow.Y = 615 - 10;
            }
            else if (currentPlanet == 3)
            {
                PlayerIsHereArrow.X = 692 + 75;
                PlayerIsHereArrow.Y = 355 - 0;
            }
            else if (currentPlanet == 4)
            {
                PlayerIsHereArrow.X = 354 + 75;
                PlayerIsHereArrow.Y = 141 - 10;
            }
            else if (currentPlanet == 5)
            {
                PlayerIsHereArrow.X = 950 + 75;
                PlayerIsHereArrow.Y = 74 - 10;
            }
            else if (currentPlanet == 6)
            {
                PlayerIsHereArrow.X = 1298 + 75;
                PlayerIsHereArrow.Y = 272 - 10;
            }

        }

	}
}
