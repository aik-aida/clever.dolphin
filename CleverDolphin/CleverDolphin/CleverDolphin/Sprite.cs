using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverDolphin
{
    class Sprite
    {
        protected Texture2D myTexture;
        public Rectangle myRectangle;
       
        public Sprite(Texture2D myTexture)
        {
            this.myTexture = myTexture;
        }


        public Sprite(Texture2D myTexture, Rectangle myRectangle)
        {

            this.myTexture = myTexture;
            this.myRectangle = myRectangle;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(myTexture, myRectangle, Color.White);

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public Rectangle BoundingBox
        {
            get { return new Rectangle((int)myRectangle.X, (int)myRectangle.Y, myTexture.Width, myTexture.Height); }
        }


    }
}
