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
	public partial class KamikazeTest
	{

		void CustomInitialize()
		{
            MainShipInstance.MovementInput =
                InputManager.Keyboard.Get2DInput(Keys.A, Keys.D, Keys.W, Keys.S);
            SpawnEnemies();
        }

		void CustomActivity(bool firstTimeCalled)
		{
            
            CollisionActivity();
            RemovalActivity();
            PlayerLocationActivity();
            MouseLocationActivity();
            PlayerShootingActivity();

		}

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        //these codes should be changed to be about the actual playership later
        public float PlayerLocationX()
        {
            return MainShipInstance.X;
        }

        public float PlayerLocationY()
        {
            return MainShipInstance.Y;
        }

        void MouseLocationActivity()
        {
            MainShipInstance.MouseLocationX = MouseLocationX();
            MainShipInstance.MouseLocationY = MouseLocationY();
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
            MainShipInstance.ShootingInput =
                InputManager.Mouse.ButtonDown(Mouse.MouseButtons.LeftButton);
        }

        private void SpawnEnemies()
        {
            EnemyKamikaze kamikaze1 = EnemyKamikazeFactory.CreateNew();
            kamikaze1.EnemyState = EnemyKamikaze.VariableState.DarkGrey;
            kamikaze1.Position = new Microsoft.Xna.Framework.Vector3(-200, 200, 0);
            EnemyKamikaze kamikaze2 = EnemyKamikazeFactory.CreateNew();
            kamikaze2.Position = new Microsoft.Xna.Framework.Vector3(0, 200, 0);
            kamikaze2.EnemyState = EnemyKamikaze.VariableState.Metallic;
            EnemyKamikaze kamikaze3 = EnemyKamikazeFactory.CreateNew();
            kamikaze3.Position = new Microsoft.Xna.Framework.Vector3(200, 200, 0);
            kamikaze3.EnemyState = EnemyKamikaze.VariableState.Purple;
        }

        private void PlayerLocationActivity()
        {
            for (int i = 0; i < EnemyKamikazeList.Count; i++)
            //for (int i = EnemyKamikazeList.Count - 1; i > -1; i--)
            {
                EnemyKamikaze kamikaze = EnemyKamikazeList[i];
                kamikaze.PlayerLocationX = MainShipInstance.X;
                kamikaze.PlayerLocationY = MainShipInstance.Y;
            }
        }

        private void CollisionActivity()
        {
            KamikazeVsPlayerShipCollisionActivity();
            BulletVsKamikazeCollisionActivity();
        }

        private void KamikazeVsPlayerShipCollisionActivity()
        {
            for (int i = EnemyKamikazeList.Count -1; i > -1; i--)
            {
                EnemyKamikaze kamikaze = EnemyKamikazeList[i];
                if (kamikaze.Polygon.CollideAgainst(MainShipInstance.Polygon))
                {
                    //Change this to PlayerShip.TakeDamage() later?
                    MainShipInstance.HealthPoints -= kamikaze.Damage;
                    kamikaze.Explode();
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
                    if (bullet.Polygon.CollideAgainst(kamikaze.Polygon))
                    {
                        //Change this to PlayerShip.TakeDamage() later as well..
                        kamikaze.HealthPoints -= bullet.Damage;
                        bullet.Destroy();
                        break;
                    }
                }
            }
        }

        private void RemovalActivity()
        {
            RemoveExplosions();
        }

        private void RemoveExplosions()
        {
            //remove explosions after their time is up
            for (int i = ExplosionList.Count - 1; i > -1; i--)
            {
                Explosion explosion = ExplosionList[i];
                explosion.DestroyExplosion();
            }
        }

        private void RemoveBullets()
        {
            for (int i = BulletList.Count - 1; i > -1; i--)
            {
                Bullet bullet = BulletList[i];
                if (Math.Abs(bullet.X) > 300 || Math.Abs(bullet.Y) > 300)
                {
                    bullet.Destroy();
                }
            }
        }
    }
}
