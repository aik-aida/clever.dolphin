using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverDolphin
{
    class Ocean : Sprite
    {
        Rectangle rect1;
        Rectangle rect2;
        Texture2D oceanTxtr2;
        int width;
        int height;
        public Ocean(Texture2D oceanTxtr, Texture2D oceanTxtr2,int width, int height)
            : base(oceanTxtr)
        {
            this.width = width;
            this.height = height;
            speed = 5;
            this.oceanTxtr2 = oceanTxtr2;
            rect1 = new Rectangle(0, 0, width, height);
            rect2 = new Rectangle(width, 0, width, height);
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, rect1, Color.White);
            spriteBatch.Draw(oceanTxtr2, rect2, Color.White);
            //base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (rect1.X + width <= 0)
                rect1.X = rect2.X + width;
            if (rect2.X + width <= 0)
                rect2.X = rect1.X + width;

            rect1.X -= speed;
            rect2.X -= speed;
            //base.Update(gameTime);
        }
    }
}
