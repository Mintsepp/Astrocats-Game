using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using SpaceGame.Factories;

namespace SpaceGame.Entities
{
    public partial class MainShip
    {
        
        public I2DInput MovementInput { get; set; }
        public bool ShootingInput { get; set; }
        public MainShip.VariableState shipState;

        private float mouseLocationX;
        private float mouseLocationY;

        public float MouseLocationX
        {
            set { mouseLocationX = value; }
        }

        public float MouseLocationY
        {
            set { mouseLocationY = value; }
        }

        public MainShip.VariableState ShipState
        {
            set { this.CurrentState = value; }
        }

        double mLastSpawnTime;
        private bool IsTimeToSpawn
        {
            get
            {
                return FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(mLastSpawnTime) > 1.0 / BulletsPerSecond;
            }
        }

        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        private void CustomInitialize()
        {

        }

        private void CustomActivity()
        {
            MovementActivity();
            ShootingActivity();
            TurningActivity();

        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void MovementActivity()
        {
            if (MovementInput != null)
            {
                this.XVelocity = MovementInput.X * MovementSpeed;
                this.YVelocity = MovementInput.Y * MovementSpeed;
                ThrustersOn(true);
            } else
            {
                ThrustersOn(false);
            }
        }

        private void TurningActivity()
        {
            //Get the position of the mouse and orientate playership
            //towards the mouse
            if (mouseLocationY > this.Y)
            {
                this.RotationZ = System.Convert.ToSingle
                    (-Math.Atan(System.Convert.ToDouble
                    ((this.X - mouseLocationX)) /
                    (this.Y - mouseLocationY)));
            }
            else
            {
                this.RotationZ = System.Convert.ToSingle
                    (Math.PI - Math.Atan(System.Convert.ToDouble
                    ((this.X - mouseLocationX)) /
                    (this.Y - mouseLocationY)));
            }

            //this.TextInstance.Spacing = 10f;
            //this.TextInstance.DisplayText = System.Convert.ToString(mouseLocationY);
        }

        private void ThrustersOn(bool b)
        {
            if (this.CurrentState.Equals(MainShip.VariableState.MainShip1))
            {
                this.ThrusterSprite1.Visible = b;
            }
            else if (this.CurrentState.Equals(MainShip.VariableState.MainShip2))
            {
                this.ThrusterSprite1.Visible = b;
            }
            else if (this.CurrentState.Equals(MainShip.VariableState.MainShip3))
            {
                this.ThrusterSprite1.Visible = b;
            }
            else if (this.CurrentState.Equals(MainShip.VariableState.MainShip4))
            {
                this.ThrusterSprite1.Visible = b;
                this.ThrusterSprite2.Visible = b;
            }
        }

        private void ShootingActivity()
        {
            if (ShootingInput && IsTimeToSpawn)
            {
                if (this.CurrentState.Equals(MainShip.VariableState.MainShip1))
                {
                    SpawnBulletType1();
                } else if (this.CurrentState.Equals(MainShip.VariableState.MainShip2))
                {
                    SpawnBulletType2();
                } else if (this.CurrentState.Equals(MainShip.VariableState.MainShip3))
                {
                    SpawnBulletType3();
                } else if (this.CurrentState.Equals(MainShip.VariableState.MainShip4))
                {
                    SpawnBulletType4();
                }

                mLastSpawnTime = FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;
            }
        }

        private void SpawnBulletType1()
        {
            Bullet bullet1 = BulletFactory.CreateNew();
            bullet1.CurrentState = Bullet.VariableState.Bullet1;
            bullet1.Position += this.Position + this.RotationMatrix.Up * 25;
            bullet1.Position += this.RotationMatrix.Right * 15;
            bullet1.RotationZ = this.RotationZ;
            bullet1.Velocity = this.RotationMatrix.Up * bullet1.MovementSpeed;

            Bullet bullet2 = BulletFactory.CreateNew();
            bullet2.CurrentState = Bullet.VariableState.Bullet1;
            bullet2.Position += this.Position + this.RotationMatrix.Up * 25;
            bullet2.Position -= this.RotationMatrix.Right * 15;
            bullet2.RotationZ = this.RotationZ;
            bullet2.Velocity = this.RotationMatrix.Up * bullet2.MovementSpeed;
        }

        private void SpawnBulletType2()
        {
            Bullet bullet1 = BulletFactory.CreateNew();
            bullet1.CurrentState = Bullet.VariableState.Bullet2;
            bullet1.Position += this.Position + this.RotationMatrix.Up * 25;
            bullet1.RotationZ = this.RotationZ;
            bullet1.Velocity = this.RotationMatrix.Up * bullet1.MovementSpeed;

            Bullet bullet2 = BulletFactory.CreateNew();
            bullet2.CurrentState = Bullet.VariableState.Bullet2;
            bullet2.Position += this.Position + this.RotationMatrix.Left * 25;
            bullet2.RotationZ = this.RotationZ + System.Convert.ToSingle(Math.PI/2);
            bullet2.Velocity = this.RotationMatrix.Left * bullet2.MovementSpeed;

            Bullet bullet3 = BulletFactory.CreateNew();
            bullet3.CurrentState = Bullet.VariableState.Bullet2;
            bullet3.Position += this.Position + this.RotationMatrix.Right * 25;
            bullet3.RotationZ = this.RotationZ - System.Convert.ToSingle(Math.PI / 2);
            bullet3.Velocity = this.RotationMatrix.Right * bullet3.MovementSpeed;
        }

        private void SpawnBulletType3()
        {
            Bullet bullet = BulletFactory.CreateNew();
            bullet.CurrentState = Bullet.VariableState.Bullet3;
            bullet.Position += this.Position + this.RotationMatrix.Up * 25;
            bullet.RotationZ = this.RotationZ;
            bullet.Velocity = this.RotationMatrix.Up * bullet.MovementSpeed;
        }

        private void SpawnBulletType4()
        {
            Bullet bullet1 = BulletFactory.CreateNew();
            bullet1.CurrentState = Bullet.VariableState.Bullet4;
            bullet1.Position += this.Position + this.RotationMatrix.Up * 25;
            bullet1.RotationZ = this.RotationZ;
            bullet1.Velocity = this.RotationMatrix.Up * bullet1.MovementSpeed 
            * System.Convert.ToSingle(0.85);

            Bullet bullet2 = BulletFactory.CreateNew();
            bullet2.CurrentState = Bullet.VariableState.Bullet4;
            bullet2.Position += this.RotationMatrix.Left * 25
            + this.Position + this.RotationMatrix.Up * 13;
            bullet2.RotationZ = this.RotationZ + System.Convert.ToSingle(Math.PI / 4);
            bullet2.Velocity = this.RotationMatrix.Up * bullet2.MovementSpeed/2
            + this.RotationMatrix.Left * bullet2.MovementSpeed / 2;

            Bullet bullet3 = BulletFactory.CreateNew();
            bullet3.CurrentState = Bullet.VariableState.Bullet4;
            bullet3.Position += this.RotationMatrix.Right * 25
            + this.Position + this.RotationMatrix.Up * 13;
            bullet3.RotationZ = this.RotationZ - System.Convert.ToSingle(Math.PI / 4);
            bullet3.Velocity = this.RotationMatrix.Up * bullet3.MovementSpeed/2
            + this.RotationMatrix.Right * bullet3.MovementSpeed / 2;

            Bullet bullet4 = BulletFactory.CreateNew();
            bullet4.CurrentState = Bullet.VariableState.Bullet4;
            bullet4.Position += this.RotationMatrix.Up * 25
            + this.Position - this.RotationMatrix.Right * 15;
            bullet4.RotationZ = this.RotationZ + System.Convert.ToSingle(Math.PI / 8);
            bullet4.Velocity = this.RotationMatrix.Up * bullet4.MovementSpeed
            * System.Convert.ToSingle(0.75) + this.RotationMatrix.Left
            * bullet4.MovementSpeed * System.Convert.ToSingle(0.25);

            Bullet bullet5 = BulletFactory.CreateNew();
            bullet5.CurrentState = Bullet.VariableState.Bullet4;
            bullet5.Position += this.RotationMatrix.Up * 25
            + this.Position + this.RotationMatrix.Right * 15;
            bullet5.RotationZ = this.RotationZ - System.Convert.ToSingle(Math.PI / 8);
            bullet5.Velocity = this.RotationMatrix.Up * bullet5.MovementSpeed
            * System.Convert.ToSingle(0.75) + this.RotationMatrix.Right
            * bullet5.MovementSpeed * System.Convert.ToSingle(0.25);

        }
    }
}
