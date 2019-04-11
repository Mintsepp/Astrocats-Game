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
    public partial class PlayMenu
    {
        void OnBackButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.BackButtonClick != null)
            {
                BackButtonClick(window);
            }
        }
        void OnSelectSaveButton1DeleteSaveButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.SelectSaveButton1DeleteSaveButtonClick != null)
            {
                SelectSaveButton1DeleteSaveButtonClick(window);
            }
        }
        void OnSelectSaveButton2DeleteSaveButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.SelectSaveButton2DeleteSaveButtonClick != null)
            {
                SelectSaveButton2DeleteSaveButtonClick(window);
            }
        }
        void OnSelectSaveButton3DeleteSaveButtonClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.SelectSaveButton3DeleteSaveButtonClick != null)
            {
                SelectSaveButton3DeleteSaveButtonClick(window);
            }
        }
        void OnSelectSaveButton1ClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.SelectSaveButton1Click != null)
            {
                SelectSaveButton1Click(window);
            }
        }
        void OnSelectSaveButton2ClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.SelectSaveButton2Click != null)
            {
                SelectSaveButton2Click(window);
            }
        }
        void OnSelectSaveButton3ClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.SelectSaveButton3Click != null)
            {
                SelectSaveButton3Click(window);
            }
        }
    }
}
