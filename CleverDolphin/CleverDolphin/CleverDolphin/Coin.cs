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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    class Coin : Sprite
    {
        Rectangle coinA;
        Rectangle coinB;
        Rectangle coinC;
        //Texture2D texture2d;
        int height;
        int delay;
        //float delay;
        //float elapsed;
        //float keyboardFreeze;
        //int speed;

        public Coin(Texture2D textureCoin, int maxY)
            : base(textureCoin)
        {
            this.delay = 0;
            this.height = maxY;
            //myRectangle = new Rectangle(300, 330, 60, 60);
            coinA = new Rectangle(2000, 340, 60, 60);
            coinB = new Rectangle(1900, 490, 60, 60);
            coinC = new Rectangle(2000, 630, 60, 60);

        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(myTexture, myRectangle, Color.White);
            spriteBatch.Draw(myTexture, coinA, Color.White);
            spriteBatch.Draw(myTexture, coinB, Color.White);
            spriteBatch.Draw(myTexture, coinC, Color.White);
        }


        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            //delay = 100;
            //speed = 30;
            coinA.X -= 2;
            coinB.X -= 2;
            coinC.X -= 2;
            //keyboardFreeze += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

           /*
                elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsed <= delay)
                    myRectangle.Y += speed;
                else
                {
                    keyboardFreeze = 0;
                    elapsed = 0;
                }
            */
        }
    }
}


