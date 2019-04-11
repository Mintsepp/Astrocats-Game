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
        void OnPlanetButton1ClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.PlanetButton1Click != null)
            {
                PlanetButton1Click(window);
            }
        }
        void OnPlanetButton2ClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.PlanetButton2Click != null)
            {
                PlanetButton2Click(window);
            }
        }
        void OnPlanetButton3ClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.PlanetButton3Click != null)
            {
                PlanetButton3Click(window);
            }
        }
        void OnPlanetButton4ClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.PlanetButton4Click != null)
            {
                PlanetButton4Click(window);
            }
        }
        void OnPlanetButton5ClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.PlanetButton5Click != null)
            {
                PlanetButton5Click(window);
            }
        }
        void OnPlanetButton6ClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.PlanetButton6Click != null)
            {
                PlanetButton6Click(window);
            }
        }
    }
}
