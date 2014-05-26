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
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite dolphin;
        Sprite ocean;
        Sprite sky;
        List<Sprite> listCoin;

        SpriteFont score;
        Vector2 font1;
        int sc;

        int height;
        int width;
        int delay;
        public Game1()
        {
            delay = 300;
            height = 720;
            width = 1280;
            sc = 0;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
            listCoin = new List<Sprite>();
            
            //graphics.IsFullScreen = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

   
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            dolphin = new Dolphin(Content.Load<Texture2D>("clever1"), height);
            sky = new Sky(Content.Load<Texture2D>("awan copy"), Content.Load<Texture2D>("awan copy2"),width,380);
            ocean = new Ocean(Content.Load<Texture2D>("SEANEW"), Content.Load<Texture2D>("SEANEW"),width, height);

            score = Content.Load<SpriteFont>("SpriteFont1");
            font1 = new Vector2(1100, 0);
            
            //coin = new Coin(Content.Load<Texture2D>("coin"), height);
            
            for (int i = 1; i <= 3; i++)
            {
                Random r = new Random();
                int a = r.Next(1, 4);
                Console.WriteLine(a);
                listCoin.Add(new Coin(Content.Load<Texture2D>("coin"), a, i));
            }
            
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            dolphin.Update(gameTime);
            
            sky.Update(gameTime);
            ocean.Update(gameTime);

            
            /*
            if (delay <= 301)
                delay += 10;
            else
                delay = 0;
            
            Console.WriteLine(delay);

            if (delay == 300)
            {*/
            int a = 1;
                foreach (Sprite sp in listCoin)
                {
                    sp.Update(gameTime);
                    a++;
                }
            //}

           
                Console.WriteLine(a);

                if (a >= 3)
                {
                    Console.WriteLine("masuk collision");
                    Collision();
                }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            sky.Draw(spriteBatch);
            ocean.Draw(spriteBatch);
            dolphin.Draw(spriteBatch);

            /*
            if (delay == 300)
            {
                Console.WriteLine("lalala");*/
                foreach (Sprite sp in listCoin)
                {
                    sp.Draw(spriteBatch);
                    Console.WriteLine("gambar coin");
                }
            //}

            spriteBatch.DrawString(score, sc.ToString(), font1, Color.Black);
            spriteBatch.End();
            

            base.Draw(gameTime);
        }

        private void Collision()
        {
            Sprite toRemove = null;

            foreach (Sprite sp in listCoin)
            {
                /*
                if (dolphin.BoundingBox.Intersects(sp.BoundingBox))
                {
                    Console.WriteLine("tabrak");
                    toRemove = sp;
                    break;
                }*/
                if (dolphin.myRectangle.Intersects(sp.myRectangle))
                {
                    Console.WriteLine("tabrak");
                    toRemove = sp;
                    sc += 100;
                    break;
                }
            }

            if (toRemove!=null)
                listCoin.Remove(toRemove);
        }
    }
}
