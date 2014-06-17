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
        public Rectangle destRectangle;
        public Rectangle sourcRectangle;
        public bool Active;
        public int speed;
        public Sprite(Texture2D myTexture)
        {
            this.myTexture = myTexture;
        }


        public Sprite(Texture2D myTexture, Rectangle myRectangle)
        {

            this.myTexture = myTexture;
            this.destRectangle = myRectangle;
        }

        
        public virtual void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(myTexture, destRectangle, Color.White);

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public Rectangle BoundingBox
        {
            get { return new Rectangle((int)destRectangle.X, (int)destRectangle.Y, myTexture.Width, myTexture.Height); }
        }


    }
}
