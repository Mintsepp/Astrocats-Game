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
using Microsoft.Xna.Framework.Input;
using Mouse = FlatRedBall.Input.Mouse;

namespace SpaceGame.Screens
{
	public partial class MainShipTest
	{

		void CustomInitialize()
		{
            MainShipInstance.MovementInput =
                InputManager.Keyboard.Get2DInput(Keys.A, Keys.D, Keys.W, Keys.S);
            FlatRedBallServices.Game.IsMouseVisible = true;
            MainShipInstance.CurrentState = SpaceGame.Entities.MainShip.VariableState.MainShip1;
        }

		void CustomActivity(bool firstTimeCalled)
		{
            PlayerShootingActivity();
            MouseLocationActivity();

        }

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        void MouseLocationActivity()
        {
            MainShipInstance.MouseLocationX = MouseLocationX();
            MainShipInstance.MouseLocationY = MouseLocationY();
        }

        public int MouseLocationX()
        {
            return InputManager.Mouse.X -
                FlatRedBallServices.GraphicsOptions.ResolutionWidth/2;
        }

        public int MouseLocationY()
        {
            return -InputManager.Mouse.Y +
                FlatRedBallServices.GraphicsOptions.ResolutionHeight/2;
        }

        void PlayerShootingActivity()
        {
            MainShipInstance.ShootingInput =
                InputManager.Mouse.ButtonDown(Mouse.MouseButtons.LeftButton);
        }

	}
}
