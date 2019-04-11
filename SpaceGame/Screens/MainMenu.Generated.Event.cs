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
    public partial class MainMenu
    {
        void OnTestZoneButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.TestZoneButtonClick != null)
            {
                TestZoneButtonClick(window);
            }
        }
        void OnBackButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.BackButtonClick != null)
            {
                BackButtonClick(window);
            }
        }
        void OnPlayButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.PlayButtonClick != null)
            {
                PlayButtonClick(window);
            }
        }
        void OnOptionsButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.OptionsButtonClick != null)
            {
                OptionsButtonClick(window);
            }
        }
        void OnQuitButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.QuitButtonClick != null)
            {
                QuitButtonClick(window);
            }
        }
    }
}
