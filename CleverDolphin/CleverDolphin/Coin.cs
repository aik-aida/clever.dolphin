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

        public Coin(Texture2D textureCoin, int id, int row)
            : base(textureCoin)
        {

            int datar=0;
            int tinggi=0;
            switch (id)
            {
                case 1: datar = 1500; break;
                case 2: datar = 1450; break;
                case 3: datar = 1400; break;
            }
            switch (row)
            {
                case 1: tinggi = 350; break;
                case 2: tinggi = 500; break;
                case 3: tinggi = 650; break;
            }

           
            destRectangle = new Rectangle(datar, tinggi, 50, 50);


        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, destRectangle, Color.White);

        }


        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            destRectangle.X -= 2;
           
        }
    }
}


