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
    public partial class CharacterMenu
    {
        void OnSelectShip1ButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.SelectShip1ButtonClick != null)
            {
                SelectShip1ButtonClick(window);
            }
        }
        void OnSelectShip2ButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.SelectShip2ButtonClick != null)
            {
                SelectShip2ButtonClick(window);
            }
        }
        void OnSelectShip3ButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.SelectShip3ButtonClick != null)
            {
                SelectShip3ButtonClick(window);
            }
        }
        void OnSelectShip4ButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.SelectShip4ButtonClick != null)
            {
                SelectShip4ButtonClick(window);
            }
        }
        void OnStartButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.StartButtonClick != null)
            {
                StartButtonClick(window);
            }
        }
    }
}
