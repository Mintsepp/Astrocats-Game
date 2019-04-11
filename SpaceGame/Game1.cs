using System;
using System.Collections.Generic;
using System.Reflection;

using FlatRedBall;
using FlatRedBall.Graphics;
using FlatRedBall.Screens;
using Microsoft.Xna.Framework;

using System.Linq;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceGame
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        public static MonoGameSaveManager.SaveManager save1;
        public static MonoGameSaveManager.SaveManager save2;
        public static MonoGameSaveManager.SaveManager save3;
        public static MonoGameSaveManager.SaveManager currentSave;

        public Game1() : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            string saveFolder = "AstrocatsSaves";
            string saveFile1 = "save1.sav";
            string saveFile2 = "save2.sav";
            string saveFile3 = "save3.sav";

            save1 = new MonoGameSaveManager.IsolatedStorageSaveManager(saveFolder, saveFile1);
            save2 = new MonoGameSaveManager.IsolatedStorageSaveManager(saveFolder, saveFile2);
            save3 = new MonoGameSaveManager.IsolatedStorageSaveManager(saveFolder, saveFile3);

#if WINDOWS_PHONE || ANDROID || IOS

            // Frame rate is 30 fps by default for Windows Phone,
            // so let's keep that for other phones too
            TargetElapsedTime = TimeSpan.FromTicks(333333);
            graphics.IsFullScreen = true;
#elif WINDOWS || DESKTOP_GL
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
#endif


#if WINDOWS_8
            FlatRedBall.Instructions.Reflection.PropertyValuePair.TopLevelAssembly = 
                this.GetType().GetTypeInfo().Assembly;
#endif

        }

        protected override void Initialize()
        {
            #if IOS
            var bounds = UIKit.UIScreen.MainScreen.Bounds;
            var nativeScale = UIKit.UIScreen.MainScreen.Scale;
            var screenWidth = (int)(bounds.Width * nativeScale);
            var screenHeight = (int)(bounds.Height * nativeScale);
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            #endif
        
            FlatRedBallServices.InitializeFlatRedBall(this, graphics);

			GlobalContent.Initialize();
			CameraSetup.SetupCamera(SpriteManager.Camera, graphics);
			FlatRedBall.Screens.ScreenManager.Start(typeof(SpaceGame.Screens.StartMenu));

            base.Initialize();


            //Template to create empty save
            save1.Data.m1p1_2 = false;
            save1.Data.m1p1_3 = false;
            save1.Data.m1p3_4 = false;
            save1.Data.m1p3_5 = false;
            save1.Data.m1p5_6 = false;
            save1.Data.m1p2_6 = false;

            save2.Data.m1p1_2 = false;
            save2.Data.m1p1_3 = false;
            save2.Data.m1p3_4 = false;
            save2.Data.m1p3_5 = false;
            save2.Data.m1p5_6 = false;
            save2.Data.m1p2_6 = false;

            save2.Data.m1p1_2 = false;
            save2.Data.m1p1_3 = false;
            save2.Data.m1p3_4 = false;
            save2.Data.m1p3_5 = false;
            save2.Data.m1p5_6 = false;
            save2.Data.m1p2_6 = false;

            save1.Load();
            save2.Load();
            save3.Load();
        }


        protected override void Update(GameTime gameTime)
        {
            FlatRedBallServices.Update(gameTime);

                FlatRedBall.Screens.ScreenManager.Activity();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            FlatRedBallServices.Draw();

            base.Draw(gameTime);
        }
    }
}
