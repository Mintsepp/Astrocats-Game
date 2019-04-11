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

namespace SpaceGame.Entities
{
	public partial class TravelBackground
	{
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
		private void CustomInitialize()
		{
            this.CurrentState = SpaceGame.Entities.TravelBackground.VariableState.Blue;
            this.NebulaSprite2.RelativeX = this.NebulaSprite1.Width;
            this.SmallStarsSprite2.RelativeX = this.SmallStarsSprite1.Width;
            this.BigStarsSprite2.RelativeX = this.BigStarsSprite1.Width;
		}

		private void CustomActivity()
		{
            ScrollBackground();

		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void ScrollBackground()
        {
            this.NebulaSprite1.RelativeXVelocity = -ScrollingSpeed/4;
            this.NebulaSprite2.RelativeXVelocity = -ScrollingSpeed/4;
            this.SmallStarsSprite1.RelativeXVelocity = -ScrollingSpeed/2;
            this.SmallStarsSprite2.RelativeXVelocity = -ScrollingSpeed/2;
            this.BigStarsSprite1.RelativeXVelocity = -ScrollingSpeed;
            this.BigStarsSprite2.RelativeXVelocity = -ScrollingSpeed;

            AdjustNebulaPosition();
            AdjustSmallStarsPosition();
            AdjustBigStarsPosition();
        }

        private void AdjustNebulaPosition()
        {
            if (this.NebulaSprite1.X < -4096 * 0.4)
            {
                this.NebulaSprite1.RelativeX =
                    this.NebulaSprite2.RelativeX + this.NebulaSprite1.Width;
            } else if (this.NebulaSprite2.X < -4096 * 0.4)
            {
                this.NebulaSprite2.RelativeX =
                    this.NebulaSprite1.RelativeX + this.NebulaSprite2.Width;
            }
        }

        private void AdjustSmallStarsPosition()
        {
            if (this.SmallStarsSprite1.X < -4096 * 0.4)
            {
                this.SmallStarsSprite1.RelativeX =
                    this.SmallStarsSprite2.RelativeX + this.SmallStarsSprite1.Width;
            }
            else if (this.SmallStarsSprite2.X < -4096 * 0.4)
            {
                this.SmallStarsSprite2.RelativeX =
                    this.SmallStarsSprite1.RelativeX + this.SmallStarsSprite2.Width;
            }
        }

        private void AdjustBigStarsPosition()
        {
            if (this.BigStarsSprite1.X < -4096 * 0.4)
            {
                this.BigStarsSprite1.RelativeX =
                    this.BigStarsSprite2.RelativeX + this.BigStarsSprite1.Width;
            }
            else if (this.BigStarsSprite2.X < -4096 * 0.4)
            {
                this.BigStarsSprite2.RelativeX =
                    this.BigStarsSprite1.RelativeX + this.BigStarsSprite2.Width;
            }
        }
    }
}
