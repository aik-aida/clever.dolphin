using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace FirstXNAProject
{
    class Dolphin : Sprite
    {
        KeyboardState movement;
        float delay = 200;
        float elapsed = 200;
        public Dolphin(Texture2D myTexture, Rectangle myRectangle) : base(myTexture, myRectangle)
        {
            
        
        }

        public override void Update(GameTime gameTime)
        {
            movement = Keyboard.GetState();
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (movement.IsKeyDown(Keys.Down) && elapsed >= delay)
            {
                myRectangle.Y += 150;
                elapsed = 0;
            }
            if (movement.IsKeyDown(Keys.Up) && elapsed >= delay)
            {
                myRectangle.Y -= 150;
                elapsed = 0;
            }//myRectangle.X -= 2;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }


    }
}
