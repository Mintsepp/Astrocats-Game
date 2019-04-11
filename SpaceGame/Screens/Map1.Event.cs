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
    public partial class Map1
    {

        void OnPlanetButton1Click (FlatRedBall.Gui.IWindow window) 
        {
            if (currentPlanet == 1)
            {
                MoveToScreen(typeof(Shop1));
            }
        }
        void OnPlanetButton2Click (FlatRedBall.Gui.IWindow window) 
        {
            if (currentPlanet == 1)
            {
                StripeBetweenPlanets1_2_red.Visible = false;
                Game1.currentSave.Data.m1p1_2 = true;
            }
            MoveToScreen(typeof(TravelScreen));
        }
        void OnPlanetButton3Click (FlatRedBall.Gui.IWindow window) 
        {
            if (currentPlanet == 1)
            {
                StripeBetweenPlanets1_3_red.Visible = false;
                Game1.currentSave.Data.m1p1_3 = true;
            }
        }
        void OnPlanetButton4Click (FlatRedBall.Gui.IWindow window) 
        {
            
        }
        void OnPlanetButton5Click (FlatRedBall.Gui.IWindow window) 
        {
            
        }
        void OnPlanetButton6Click (FlatRedBall.Gui.IWindow window) 
        {
            
        }

    }
}
