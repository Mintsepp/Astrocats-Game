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
        void OnSelectShip1ButtonClick(FlatRedBall.Gui.IWindow window)
        {
            if (SelectShip1Button.PlayerSelectionText == "Not selected"
                && !playerHasSelected1)
            {
                playerShip1 = 1;
                SelectShip1Button.PlayerSelectionText = "Player 1";
                playerHasSelected1 = true;
            }
            else if (playerShip1 == 1)
            {
                playerShip1 = 0;
                SelectShip1Button.PlayerSelectionText = "Not selected";
                playerHasSelected1 = false;
            }
        }
        void OnSelectShip2ButtonClick(FlatRedBall.Gui.IWindow window)
        {
            if (SelectShip2Button.PlayerSelectionText == "Not selected"
                && !playerHasSelected1)
            {
                playerShip1 = 2;
                SelectShip2Button.PlayerSelectionText = "Player 1";
                playerHasSelected1 = true;
            }
            else if (playerShip1 == 2)
            {
                playerShip1 = 0;
                SelectShip2Button.PlayerSelectionText = "Not selected";
                playerHasSelected1 = false;
            }
        }
        void OnSelectShip3ButtonClick(FlatRedBall.Gui.IWindow window)
        {
            if (SelectShip3Button.PlayerSelectionText == "Not selected"
                && !playerHasSelected1)
            {
                playerShip1 = 3;
                SelectShip3Button.PlayerSelectionText = "Player 1";
                playerHasSelected1 = true;
            }
            else if (playerShip1 == 3)
            {
                playerShip1 = 0;
                SelectShip3Button.PlayerSelectionText = "Not selected";
                playerHasSelected1 = false;
            }
        }
        void OnSelectShip4ButtonClick(FlatRedBall.Gui.IWindow window)
        {
            if (SelectShip4Button.PlayerSelectionText == "Not selected"
                && !playerHasSelected1)
            {
                playerShip1 = 4;
                SelectShip4Button.PlayerSelectionText = "Player 1";
                playerHasSelected1 = true;
            }
            else if (playerShip1 == 4)
            {
                playerShip1 = 0;
                SelectShip4Button.PlayerSelectionText = "Not selected";
                playerHasSelected1 = false;
            }
        }
        void OnStartButtonClick(FlatRedBall.Gui.IWindow window)
        {
            if (playerShip1 == 0 & playerShip2 == 0
                & playerShip3 == 0 & playerShip4 == 0)
            {
                //ship not selected.. give indication of that
            }
            else
            {
                MoveToScreen(typeof(Map1));
            }
        }





    }
}
