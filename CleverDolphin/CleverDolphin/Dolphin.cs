using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverDolphin
{
    class Dolphin : Sprite
    {
        KeyboardState movement;
        float elapsed;
        float delay;
        int speed;
        int maxHeight;
        int moveDown = 0;
        int moveUp = 0;
        public Vector2 Position;
        float keyboardFreeze;
        Animation dolphinAnimation;
        
        public Dolphin(Texture2D dolphinTextr, Vector2 position, int width, int height,int maxHeight)
            : base(dolphinTextr)
        {
            Position = position;
            dolphinAnimation = new Animation();
            this.maxHeight = maxHeight;
            destRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height/4);
            sourcRectangle = new Rectangle(0, 0, width, height / 4);

            dolphinAnimation.Initialize(3, 100, width, height / 4);
        }

        
        public void UpdateMovement(GameTime gameTime)
        {
            sourcRectangle = dolphinAnimation.Animate(gameTime);
            delay = 100;
            speed = 30;
            keyboardFreeze += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (moveDown == 1)
            {
                elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsed <= delay)
                    destRectangle.Y += speed;
                else
                {
                    keyboardFreeze = 0;
                    moveDown = 0;
                    elapsed = 0;
                }   
            }

            if (moveUp == 1)
            {
                elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsed <= delay)
                    destRectangle.Y -= speed;
                else
                {
                    keyboardFreeze = 0;
                    moveUp = 0;
                    elapsed = 0;
                }
            }

            movement = Keyboard.GetState();
            if (movement.IsKeyDown(Keys.Down) && keyboardFreeze >= delay && destRectangle.Y + 200 < maxHeight)
            {
                keyboardFreeze = 0;
                moveDown = 1;
            }

            if (movement.IsKeyDown(Keys.Up) && keyboardFreeze >= delay && destRectangle.Y - 200 > (maxHeight / 3))
            {
                keyboardFreeze = 0;
                moveUp = 1;
            }
            //base.Update(gameTime);
             
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Console.WriteLine("bbbb");
           // DolphinAnimation.Draw(spriteBatch);
            spriteBatch.Draw(myTexture, destRectangle, sourcRectangle, Color.White);
        }

        
    }
}
