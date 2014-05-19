using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstXNAProject
{
    class Ocean : Sprite
    {
        private Rectangle rectangle1;
        private Rectangle rectangle2;

        public Ocean(Texture2D myTexture) : base(myTexture)
        {
            rectangle1 = new Rectangle(0,0, 518 * 2, 600);
            rectangle2 = new Rectangle(518 * 2, 0, 518 * 2, 600);
        }
    
        public Ocean(Texture2D myTexture, Rectangle myRectangle)
            : base(myTexture, myRectangle)
        { 
        
        }

        
        public override void Update(GameTime gameTime)
        {
            if (rectangle1.X + (myTexture2D.Width * 2) <= 0)
                rectangle1.X = rectangle2.X + (myTexture2D.Width * 2);

            if (rectangle2.X + (myTexture2D.Width * 2) <= 0)
                rectangle2.X = rectangle1.X + (myTexture2D.Width * 2);

            rectangle1.X -= 5;
            rectangle2.X -= 5;
            //myRectangle.X -= 5;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture2D, rectangle1, Color.White);
            spriteBatch.Draw(myTexture2D, rectangle2, Color.White);
           // base.Draw(spriteBatch);
        }
    }
}
