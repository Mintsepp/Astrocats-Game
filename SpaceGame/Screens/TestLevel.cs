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
using SpaceGame.Factories;
using SpaceGame.Entities;



namespace SpaceGame.Screens
{
	public partial class TestLevel
	{

		void CustomInitialize()
		{
            
            //Text for debug
            FlatRedBall.Graphics.Text text = FlatRedBall.Graphics.TextManager.AddText(
                System.Convert.ToString(FlatRedBallServices.GraphicsOptions.ResolutionWidth));

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

	}
}
