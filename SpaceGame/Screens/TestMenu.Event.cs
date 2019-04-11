using System;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using FlatRedBall.Audio;
using FlatRedBall.Screens;
using SpaceGame.Entities;
using SpaceGame.Screens;
namespace SpaceGame.Screens
{
    public partial class TestMenu
    {
        void OnTestKamikazeButtonClick (FlatRedBall.Gui.IWindow window) 
        {
            MoveToScreen(typeof(TestLevel));
        }
        void OnTestSpinnerButtonClick (FlatRedBall.Gui.IWindow window) 
        {
            MoveToScreen(typeof(SpinnerTest));
        }
        void OnTestMainShipButtonClick (FlatRedBall.Gui.IWindow window) 
        {
            MoveToScreen(typeof(TestLevel));
        }

    }
}
