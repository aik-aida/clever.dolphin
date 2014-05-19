using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyFramework
{
    class Dolphin : Sprite
    {
        KeyboardState movement;

        public Dolphin(Texture2D dolphinTextr)
            : base(dolphinTextr)
        {
            myRectangle = new Rectangle(0,300,150,100);
        }
        public Dolphin(Texture2D dolphinTextr, Rectangle dolphinRect)
            : base(dolphinTextr, dolphinRect)
        { 
        
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, myRectangle, Color.White);

            //base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            movement = Keyboard.GetState();
            if (movement.IsKeyDown(Keys.Down))
            {
                myRectangle.Y += 20;
            }

            if (movement.IsKeyDown(Keys.Up))
            {
                myRectangle.Y -= 20;
            }
            //base.Update(gameTime);
        }
    }
}
