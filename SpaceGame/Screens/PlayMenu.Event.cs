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
                void OnBackButtonClick (FlatRedBall.Gui.IWindow window) 
        {
            MoveToScreen(typeof(MainMenu));
        }
        void OnSelectSaveButton1DeleteSaveButtonClick (FlatRedBall.Gui.IWindow window) 
        {
            
        }
        void OnSelectSaveButton2DeleteSaveButtonClick (FlatRedBall.Gui.IWindow window) 
        {
            
        }
        void OnSelectSaveButton3DeleteSaveButtonClick (FlatRedBall.Gui.IWindow window) 
        {
            
        }
        void OnSelectSaveButton1Click (FlatRedBall.Gui.IWindow window) 
        {
            selectedSave = 1;
            MoveToScreen(typeof(CharacterMenu));
        }
        void OnSelectSaveButton2Click (FlatRedBall.Gui.IWindow window) 
        {
            selectedSave = 2;
            MoveToScreen(typeof(CharacterMenu));
        }
        void OnSelectSaveButton3Click (FlatRedBall.Gui.IWindow window) 
        {
            selectedSave = 3;
            MoveToScreen(typeof(CharacterMenu));
        }

    }
}
