using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CleverDolphin
{
    class Obstacle : Sprite
    {
        public Obstacle(Texture2D obsTextr)
            : base(obsTextr)
        {
            destRectangle = new Rectangle(1000,300,50,50);
        }

        public override void Update(GameTime gameTime)
        {
            destRectangle.X -= 3;
        }

        
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }


    }
}
