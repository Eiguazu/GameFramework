using GameFramework.Content.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class BasicMovementModule : Component
    {
        public float speed { get; set; }
        public bool UseWASD { get; set; } = true;
        public bool UseArrowKeys { get; set; } = true; 
        public bool UseAD { get; set; } = false;
        public bool ToggleMovement { get; set; } = true;
        private Vector2 facing = Vector2.Zero;

        // Enables movmement with a set speed and WASD, AD, or arrow keys. 
        public override void Update(GameTime gameTime)
        {
            if (ToggleMovement)
            {
                float moveX = 0;
                float moveY = 0;

                if (UseWASD)
                {
                    if (Input.KeyHeld(Keys.A))
                    {
                        moveX -= 1;
                    }
                    if (Input.KeyHeld(Keys.D))
                    {
                        moveX += 1;
                    }
                    if (Input.KeyHeld(Keys.W))
                    {
                        moveY -= 1;
                    }
                    if (Input.KeyHeld(Keys.S))
                    {
                        moveY += 1;
                    }
                }

                if (UseArrowKeys)
                {
                    if (Input.KeyHeld(Keys.Left))
                    {
                        moveX -= 1;
                    }
                    if (Input.KeyHeld(Keys.Right))
                    {
                        moveX += 1;
                    }
                    if (Input.KeyHeld(Keys.Up))
                    {
                        moveY -= 1;
                    }
                    if (Input.KeyHeld(Keys.Down))
                    {
                        moveY += 1;
                    }
                }

                if (UseAD)
                {
                    if (Input.KeyHeld(Keys.A))
                    {
                        moveX -= 1;
                    }
                    if (Input.KeyHeld(Keys.D))
                    {
                        moveX += 1;
                    }
                }


                Vector2 dir = new Vector2(moveX, moveY);

                if (dir != Vector2.Zero)
                {
                    dir.Normalize();
                    facing = dir;
                }

                Vector2 delta = dir * speed * Owner.deltaTime;

                float dt = Owner.deltaTime;

                Owner.validMove(new Vector2(dir.X * speed * dt, 0));   // horizontal, checked on its own
                Owner.validMove(new Vector2(0, dir.Y * speed * dt));   // vertical, checked on its own
            }

        }
        
        // Returns the facing direction. 
        public Vector2 GetFacing()
        {
            return facing;
        }

    }

}

