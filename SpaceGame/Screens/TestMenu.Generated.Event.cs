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
        void OnTestKamikazeButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.TestKamikazeButtonClick != null)
            {
                TestKamikazeButtonClick(window);
            }
        }
        void OnTestSpinnerButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.TestSpinnerButtonClick != null)
            {
                TestSpinnerButtonClick(window);
            }
        }
        void OnTestMainShipButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.TestMainShipButtonClick != null)
            {
                TestMainShipButtonClick(window);
            }
        }
    }
}
