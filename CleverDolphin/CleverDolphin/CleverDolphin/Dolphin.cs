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
        float keyboardFreeze;

        public Dolphin(Texture2D dolphinTextr, int maxHeight)
            : base(dolphinTextr)
        {
            this.maxHeight = maxHeight;
            myRectangle = new Rectangle(35, 330, 120, 60);
        }
        public Dolphin(Texture2D dolphinTextr, Rectangle dolphinRect, int maxHeight)
            : base(dolphinTextr, dolphinRect)
        {
            this.maxHeight = maxHeight;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, myRectangle, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            delay = 100;
            speed = 30;
            keyboardFreeze += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (moveDown == 1)
            {
                elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsed <= delay)
                    myRectangle.Y += speed;
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
                    myRectangle.Y -= speed;
                else
                {
                    keyboardFreeze = 0;
                    moveUp = 0;
                    elapsed = 0;
                }
            }

            movement = Keyboard.GetState();
            if (movement.IsKeyDown(Keys.Down) && keyboardFreeze >= delay && myRectangle.Y + 200 < maxHeight)
            {
                keyboardFreeze = 0;
                moveDown = 1;
            }

            if (movement.IsKeyDown(Keys.Up) && keyboardFreeze >= delay && myRectangle.Y - 200 > (maxHeight/3))
            {
                keyboardFreeze = 0;
                moveUp = 1;
            }
            //base.Update(gameTime);
        }
    }
}
