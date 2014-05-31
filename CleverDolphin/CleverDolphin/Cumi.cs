using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace CleverDolphin
{
    class Cumi : Sprite
    {
        Animation cumiAnimation;

        public Cumi(Texture2D texture, Vector2 position, int width, int height)
            : base(texture)
        {
            myTexture = texture;
            cumiAnimation = new Animation();
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width, height / 2);
            sourcRectangle = new Rectangle(0, 0, width, height / 2);
            cumiAnimation.Initialize(1, 100, width, height / 2);
            
            //destRectangle = new Rectangle(1200, 500, 50,110);
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(myTexture, destRectangle, sourcRectangle, Color.White);
            //spriteBatch.Draw(myTexture, destRectangle, Color.White);
            Console.WriteLine("aaaa");

        }

        public override void Update(GameTime gameTime)
        {
            sourcRectangle = cumiAnimation.Animate(gameTime);

            destRectangle.X -= 2;

            //base.Update(gameTime);
        }
    }
}
