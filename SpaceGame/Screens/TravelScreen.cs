using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;
using SpaceGame.Factories;
using SpaceGame.Entities;
using Mouse = FlatRedBall.Input.Mouse;


namespace SpaceGame.Screens
{
    public partial class TravelScreen
    {

        private MonoGameSaveManager.SaveManager save;

        void CustomInitialize()
        {
            SpawnMainShips();
            GetSaveData();
            FlatRedBallServices.Game.IsMouseVisible = true;
        }

        private void SpawnMainShips()
        {
            MainShip mainShip = MainShipFactory.CreateNew();

            if (CharacterMenu.playerShip1 == 1)
            {
                mainShip.CurrentState = MainShip.VariableState.MainShip1;
            } else if (CharacterMenu.playerShip1 == 2)
            {
                mainShip.CurrentState = MainShip.VariableState.MainShip2;
            } else if (CharacterMenu.playerShip1 == 3)
            {
                mainShip.CurrentState = MainShip.VariableState.MainShip3;
            } else if (CharacterMenu.playerShip1 == 4)
            {
                mainShip.CurrentState = MainShip.VariableState.MainShip4;
            }
            mainShip.X = -100;
            mainShip.Y = -100;
            mainShip.MovementInput =
                InputManager.Keyboard.Get2DInput(Keys.A, Keys.D, Keys.W, Keys.S);
        }

        void CustomActivity(bool firstTimeCalled)
        {
            CollisionActivity();
            PlayerLocationActivity();
            MouseLocationActivity();
            PlayerShootingActivity();
            DriftActivity();
            UpdateHUD();
            RemovalActivity();

            if (MainShipList[0].HealthPoints <= 0)
            {
                //Environment.Exit(1);
                Game1.currentSave = this.save;
                DestroyEverything();
               
                MoveToScreen(typeof(TestEndScreen));
            }
        }

        private void DestroyEverything()
        {
            for (int i = AstericeList.Count - 1; i > -1; i--)
            {
                Asterice asterice = AstericeList[i];
                asterice.Destroy();
            }

            for (int i = ExplosionList.Count - 1; i > -1; i--)
            {
                Explosion explosion = ExplosionList[i];
                explosion.Destroy();
            }

            for (int i = MainShipList.Count - 1; i > -1; i--)
            {
                MainShip asterice = MainShipList[i];
                asterice.Destroy();
            }

            for (int i = EnemySpinnerList.Count - 1; i > -1; i--)
            {
                EnemySpinner asterice = EnemySpinnerList[i];
                asterice.Destroy();
            }

            for (int i = EnemyJumperList.Count - 1; i > -1; i--)
            {
                EnemyJumper asterice = EnemyJumperList[i];
                asterice.Destroy();
            }

            for (int i = EnemyKamikazeList.Count - 1; i > -1; i--)
            {
                EnemyKamikaze asterice = EnemyKamikazeList[i];
                asterice.Destroy();
            }

            for (int i = BulletList.Count - 1; i > -1; i--)
            {
                Bullet asterice = BulletList[i];
                asterice.Destroy();
            }

            this.EnemySpawnerInstance.Destroy();
            this.TravelBackgroundInstance.Destroy();
            this.HealthBar.Destroy();
            this.ScoreBar.Destroy();
            this.UnloadsContentManagerWhenDestroyed = true;

        }

        void CustomDestroy()
        {


        }

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void GetSaveData()
        {
            this.save = Game1.currentSave;
        }

        public float PlayerLocationX()
        {
            return MainShipList[1].X;
        }

        public float PlayerLocationY()
        {
            return MainShipList[1].Y;
        }

        private void SpawnEnemies()
        {
            EnemySpinner spinner1 = EnemySpinnerFactory.CreateNew();
            spinner1.EnemyState = EnemySpinner.VariableState.DarkGrey;
            spinner1.TurningSpeed = 50;
            spinner1.Position = new Microsoft.Xna.Framework.Vector3(-200, 200, 0);
            EnemyKamikaze kamikaze3 = EnemyKamikazeFactory.CreateNew();
            kamikaze3.Position = new Microsoft.Xna.Framework.Vector3(200, 200, 0);
            kamikaze3.EnemyState = EnemyKamikaze.VariableState.Purple;
        }

        void MouseLocationActivity()
        {
            MainShipList[0].MouseLocationX = MouseLocationX();
            MainShipList[0].MouseLocationY = MouseLocationY();
        }

        public int MouseLocationX()
        {
            return InputManager.Mouse.X -
                FlatRedBallServices.GraphicsOptions.ResolutionWidth / 2;
        }

        public int MouseLocationY()
        {
            return -InputManager.Mouse.Y +
                FlatRedBallServices.GraphicsOptions.ResolutionHeight / 2;
        }

        void PlayerShootingActivity()
        {
            MainShipList[0].ShootingInput =
                InputManager.Mouse.ButtonDown(Mouse.MouseButtons.LeftButton);
        }

        private void PlayerLocationActivity()
        {
            for (int i = 0; i < EnemySpinnerList.Count; i++)
            {
                EnemySpinner spinner = EnemySpinnerList[i];
                spinner.PlayerLocationX = MainShipList[0].X;
                spinner.PlayerLocationY = MainShipList[0].Y;
                
            }
            
            for (int i = 0; i < EnemyKamikazeList.Count; i++)
            {
                EnemyKamikaze kamikaze = EnemyKamikazeList[i];
                kamikaze.PlayerLocationX = MainShipList[0].X;
                kamikaze.PlayerLocationY = MainShipList[0].Y;
            }
        }

        private void CollisionActivity()
        {
            SpinnerVsMainShipCollisionActivity();
            KamikazeVsMainShipCollisionActivity();
            BulletVsKamikazeCollisionActivity();
            BulletVsSpinnerCollisionActivity();
            BulletVsMainShipCollisionActivity();
            AstericeVsMainShipCollisionActivity();
            BulletVsJumperCollisionActivity();
            JumperVsMainShipCollisionActivity();
        }

        private void SpinnerVsMainShipCollisionActivity()
        {
            for (int i = EnemySpinnerList.Count - 1; i > -1; i--)
            {
                EnemySpinner spinner = EnemySpinnerList[i];
                if (spinner.Polygon.CollideAgainst(MainShipList[0].Polygon))
                {
                    MainShipList[0].HealthPoints -= spinner.Damage;
                    spinner.Explode();
                }
            }
        }

        private void BulletVsMainShipCollisionActivity()
        {
            for (int i = BulletList.Count - 1; i > -1; i--)
            {
                Bullet bullet = BulletList[i];
                if (bullet.Polygon.CollideAgainst(MainShipList[0].Polygon)
                    && !bullet.IsFromPlayer)
                {
                    //Change this to PlayerShip.TakeDamage() later as well..
                    MainShipList[0].HealthPoints -= bullet.Damage;
                    bullet.Destroy();
                    break;
                }
            }
        }

        private void UpdateHUD()
        {
            UpdateHealthBar();
            UpdateScoreBar();
        }

        private void UpdateHealthBar()
        {
            HealthBar.BarWidth = 250 * MainShipList[0].HealthPoints / 100;
        }

        private void UpdateScoreBar()
        {
            ScoreBar.ScoreText = save.Data.astericeNumber.ToString();
        }

        private void KamikazeVsMainShipCollisionActivity()
        {
            for (int i = EnemyKamikazeList.Count - 1; i > -1; i--)
            {
                EnemyKamikaze kamikaze = EnemyKamikazeList[i];
                if (kamikaze.Polygon.CollideAgainst(MainShipList[0].Polygon))
                {
                    //Change this to PlayerShip.TakeDamage() later?
                    MainShipList[0].HealthPoints -= kamikaze.Damage;
                    kamikaze.Explode();
                }
            }
        }

        private void JumperVsMainShipCollisionActivity()
        {
            for (int i = EnemyJumperList.Count - 1; i > -1; i--)
            {
                EnemyJumper jumper = EnemyJumperList[i];
                if (jumper.Polygon.CollideAgainst(MainShipList[0].Polygon))
                {
                    //Change this to PlayerShip.TakeDamage() later?
                    MainShipList[0].HealthPoints -= jumper.Damage;
                    jumper.Explode();
                }
            }
        }

        private void BulletVsKamikazeCollisionActivity()
        {
            for (int i = BulletList.Count - 1; i > -1; i--)
            {
                for (int j = EnemyKamikazeList.Count - 1; j > -1; j--)
                {
                    Bullet bullet = BulletList[i];
                    EnemyKamikaze kamikaze = EnemyKamikazeList[j];
                    if (bullet.Polygon.CollideAgainst(kamikaze.Polygon)
                        && bullet.IsFromPlayer)
                    {
                        //Change this to PlayerShip.TakeDamage() later as well..
                        kamikaze.HealthPoints -= bullet.Damage;
                        bullet.Destroy();
                        break;
                    }
                }
            }
        }

        private void BulletVsSpinnerCollisionActivity()
        {
            for (int i = BulletList.Count - 1; i > -1; i--)
            {
                for (int j = EnemySpinnerList.Count - 1; j > -1; j--)
                {
                    Bullet bullet = BulletList[i];
                    EnemySpinner spinner = EnemySpinnerList[j];
                    if (bullet.Polygon.CollideAgainst(spinner.Polygon)
                        && bullet.IsFromPlayer)
                    {
                        spinner.HealthPoints -= bullet.Damage;
                        bullet.Destroy();
                        break;
                    }
                }
            }
        }

        private void BulletVsJumperCollisionActivity()
        {
            for (int i = BulletList.Count - 1; i > -1; i--)
            {
                for (int j = EnemyJumperList.Count - 1; j > -1; j--)
                {
                    Bullet bullet = BulletList[i];
                    EnemyJumper jumper = EnemyJumperList[j];
                    if (bullet.Polygon.CollideAgainst(jumper.Polygon)
                        && bullet.IsFromPlayer)
                    {
                        jumper.HealthPoints -= bullet.Damage;
                        bullet.Destroy();
                        break;
                    }
                }
            }
        }

        private void AstericeVsMainShipCollisionActivity()
        {
            for (int i = MainShipList.Count - 1; i > -1; i--)
            {
                for (int j = AstericeList.Count - 1; j > -1; j--)
                {
                    MainShip mainShip = MainShipList[i];
                    Asterice asterice = AstericeList[j];
                    if (mainShip.Polygon.CollideAgainst(asterice.Polygon))
                    {
                        this.save.Data.astericeNumber += asterice.Value;
                        asterice.Destroy();
                        break;
                    }
                }
            }
        }

        private void RemovalActivity()
        {
            RemoveExplosions();
            RemoveBullets();
            RemoveAsterice();
        }

        private async void RemoveExplosions()
        {
            //remove explosions after their time is up

            for (int i = ExplosionList.Count - 1; i > -1; i--)
            {
                Explosion explosion = ExplosionList[i];
                if (explosion.IsItTimeToDisappear())
                {
                    explosion.Destroy();
                }
                //explosion.DestroyExplosion();
            }
        }

        private void RemoveBullets()
        {
            for (int i = BulletList.Count - 1; i > -1; i--)
            {
                Bullet bullet = BulletList[i];
                //Remove bullets when outside screen + then some
                if (Math.Abs(bullet.X) > 800+30 || Math.Abs(bullet.Y) > 450+30)
                {
                    bullet.Destroy();
                }
            }
        }

        private void RemoveAsterice()
        {
            for (int i = AstericeList.Count - 1; i > -1; i--)
            {
                Asterice asterice = AstericeList[i];
                //Remove asterice when outside screen + then some
                if (Math.Abs(asterice.X) > 800 + 30 || Math.Abs(asterice.Y) > 450 + 30)
                {
                    asterice.Destroy();
                }
            }
        }

        private void DriftActivity()
        {
            DriftSpinners();
            DriftKamikazes();
            DriftAsterices();
            DriftExplosions();
            DriftJumpers();
        }

        private void DriftSpinners()
        {
            for (int i = 0; i < EnemySpinnerList.Count; i++)
            {
                EnemySpinnerList[i].X -= 1;
            }
        }

        private void DriftKamikazes()
        {
            for (int i = 0; i < EnemyKamikazeList.Count; i++)
            {
                EnemyKamikazeList[i].X -= 1;
            }
        }

        private void DriftAsterices()
        {
            for (int i = 0; i < AstericeList.Count; i++)
            {
                AstericeList[i].X -= 1;
            }
        }

        private void DriftExplosions()
        {
            for (int i = 0; i < ExplosionList.Count; i++)
            {
                ExplosionList[i].X -= 1;
            }
        }

        private void DriftJumpers()
        {
            for (int i = 0; i < EnemyJumperList.Count; i++)
            {
                EnemyJumperList[i].X -= 1;
            }
        }
    }
}
