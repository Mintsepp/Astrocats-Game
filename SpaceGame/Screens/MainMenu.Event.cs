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

        void OnTestZoneButtonClick (FlatRedBall.Gui.IWindow window) 
        {
            MoveToScreen(typeof(TestMenu));
        }
        void OnBackButtonClick (FlatRedBall.Gui.IWindow window) 
        {
            MoveToScreen(typeof(StartMenu));
        }
        void OnPlayButtonClick (FlatRedBall.Gui.IWindow window) 
        {
            MoveToScreen(typeof(PlayMenu));
        }
        void OnOptionsButtonClick (FlatRedBall.Gui.IWindow window) 
        {
            //MoveToScreen(typeof(OptionsMenu));
        }
        void OnQuitButtonClick (FlatRedBall.Gui.IWindow window) 
        {
            Environment.Exit(1);
        }

    }
}
