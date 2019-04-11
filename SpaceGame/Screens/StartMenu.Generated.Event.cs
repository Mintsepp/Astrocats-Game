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
    public partial class StartMenu
    {
        void OnStartButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.StartButtonClick != null)
            {
                StartButtonClick(window);
            }
        }
    }
}
