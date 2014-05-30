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
        Dolphin dolphin;
        Sprite ocean;
        Sprite sky;
        Vector2 playerPosition;

        List<Sprite> listCoin;
        SpriteFont score;
        Vector2 font1;
        int sc;

        TimeSpan newTimeCoin;
        TimeSpan prevTimeCoin;
        Random rand;

        int height;
        int width;
        int delay;
        public Game1()
        {
            delay = 300;
            height = 720;
            width = 1280;
            playerPosition = new Vector2(35, 330);
            sc = 0;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
           //graphics.IsFullScreen = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            listCoin = new List<Sprite>();
            prevTimeCoin = TimeSpan.Zero;
            newTimeCoin = TimeSpan.FromSeconds(15.0);
            rand = new Random();

            base.Initialize();
        }

   
        protected override void LoadContent()
        {
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            dolphin = new Dolphin(Content.Load<Texture2D>("si lumba lumba"), playerPosition, 140 ,240, height);
            sky = new Sky(Content.Load<Texture2D>("awan copy"), Content.Load<Texture2D>("awan copy2"),width,380);
            ocean = new Ocean(Content.Load<Texture2D>("SEANEW"), Content.Load<Texture2D>("SEANEW"),width, height);
            score = Content.Load<SpriteFont>("SpriteFont1");
            font1 = new Vector2(1100, 0);

            AddChoise();
            
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            dolphin.UpdateMovement(gameTime);
            sky.Update(gameTime);
            ocean.Update(gameTime);

            UpdateChoise(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            sky.Draw(spriteBatch);
            ocean.Draw(spriteBatch);
            dolphin.Draw(spriteBatch);

            //menampilkan list coin
            foreach (Sprite sp in listCoin)
            {
                sp.Draw(spriteBatch);
                Console.WriteLine("gambar coin");
            }

            //menampilkan font score coin
            spriteBatch.DrawString(score, sc.ToString(), font1, Color.Black);
            spriteBatch.End();
            

            base.Draw(gameTime);
        }
         
        private void CollisionChoise()
        {
            Sprite toRemove = null;

            foreach (Sprite sp in listCoin)
            {
                if (dolphin.destRectangle.Intersects(sp.destRectangle))
                {
                    toRemove = sp;
                    sc += 100;
                    break;
                }
            }

            if (toRemove!=null)
                listCoin.Remove(toRemove);
        }

        private void AddChoise()
        {
            for (int i = 1; i <= 3; i++)
            {
                Random r = new Random();
                int a = r.Next(1, 4);
                Console.WriteLine(a);
                listCoin.Add(new Coin(Content.Load<Texture2D>("coin"), a, i));
            }
        }

        private void UpdateChoise(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - prevTimeCoin > newTimeCoin)
            {
                prevTimeCoin = gameTime.TotalGameTime;
                listCoin.Clear();
                AddChoise();
            }

            foreach (Sprite sp in listCoin)
            {
                sp.Update(gameTime);
            }
            CollisionChoise();
        }
    }
}
