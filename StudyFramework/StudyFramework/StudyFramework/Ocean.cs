using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StudyFramework
{
    class Ocean : Sprite
    {
        Rectangle rect1;
        Rectangle rect2;
        int width = 800;
        int height = 600;
        public Ocean(Texture2D oceanTxtr) : base(oceanTxtr)
        {
            rect1 = new Rectangle(0,0,width, height);
            rect2 = new Rectangle(width, 0, width, height);
        
        }

        public Ocean(Texture2D oceanTxtr, Rectangle oceanRect)
            : base(oceanTxtr, oceanRect)
        { 
        
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, rect1, Color.White);
            spriteBatch.Draw(myTexture, rect2, Color.White);
            //base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (rect1.X + width <= 0)
                rect1.X = rect2.X + width;
            if (rect2.X + width <= 0)
                rect2.X = rect1.X + width;

            rect1.X -= 5;
            rect2.X -= 5;
            //base.Update(gameTime);
        }
    }
}
