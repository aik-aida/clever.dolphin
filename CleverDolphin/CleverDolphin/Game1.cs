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

        _3choise _3pilihan;
        List<Sprite> listCumi;
        SpriteFont score;
        SpriteFont number;
        Vector2 fontScore;
        Vector2 fontNumber;
        int sc;
        int n;

        TimeSpan newTimeBubble;
        TimeSpan newTimeCumi;
        TimeSpan prevTimeBubble;
        Random rand;

        int height;
        int width;
        
        public Game1()
        {
         
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
            rand = new Random();
            n = rand.Next(1, 10);

            _3pilihan = new _3choise(Content.Load<Texture2D>("si bubble"), Content.Load<SpriteFont>("medium"), n);
            listCumi = new List<Sprite>();
            prevTimeBubble = TimeSpan.Zero;
            newTimeBubble = TimeSpan.FromSeconds(15.0);
            newTimeCumi = TimeSpan.FromSeconds(10.0);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            dolphin = new Dolphin(Content.Load<Texture2D>("si lumba lumba"), playerPosition, 140 ,240, height);
            sky = new Sky(Content.Load<Texture2D>("awan copy"), Content.Load<Texture2D>("awan copy2"),width,380);
            ocean = new Ocean(Content.Load<Texture2D>("SEANEW"), Content.Load<Texture2D>("SEANEW"),width, height);

            score = Content.Load<SpriteFont>("coinText");
            fontScore = new Vector2(1100, 0);

            number = Content.Load<SpriteFont>("small");
            fontNumber = dolphin.numberPos;

            AddThing();
            
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            dolphin.UpdateMovement(gameTime);
            fontNumber = dolphin.numberPos;

            sky.Update(gameTime);
            ocean.Update(gameTime);

            UpdateThing(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            sky.Draw(spriteBatch);
            ocean.Draw(spriteBatch);
            dolphin.Draw(spriteBatch);

            //menampilkan list Bubble
            foreach (Sprite sp in _3pilihan.listBubble)
                sp.Draw(spriteBatch);

            foreach (Sprite rp in listCumi)
                rp.Draw(spriteBatch);

            //menampilkan font score Bubble
            spriteBatch.DrawString(score, sc.ToString(), fontScore, Color.Black);

            spriteBatch.DrawString(number, n.ToString(), fontNumber, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
         
        private void CollisionThing()
        {
            Sprite bubbleRemove = null;
            Sprite cumiRemove = null;

            foreach (Sprite sp in _3pilihan.listBubble)
            {
                if (dolphin.destRectangle.Intersects(sp.destRectangle))
                {
                    bubbleRemove = sp;
                    sc += 100;
                    break;
                }
            }
            
            foreach (Sprite rp in listCumi)
            {
                if (dolphin.destRectangle.Intersects(rp.destRectangle))
                {
                    cumiRemove = rp;
                    sc += 50;
                    break;
                }
            }

            if (bubbleRemove != null)
                _3pilihan.listBubble.Remove(bubbleRemove);
            
            if (cumiRemove != null)
                listCumi.Remove(cumiRemove);
             
        }

        private void AddThing()
        {
            
            Random r = new Random();

            _3pilihan.UpdateList();

            
            int nCumi = r.Next(1,6);
            for (int i = 1; i <= nCumi; i++)
            {
                int y = r.Next(1, 4);
                int x = r.Next(1, 23);
                switch (y)
                {
                    case 1: y = 350; break;
                    case 2: y = 500; break;
                    case 3: y = 650; break;
                }
                listCumi.Add(new Cumi(Content.Load<Texture2D>("si cumi cumi"), new Vector2((1280 + (x * 58)), y), 58, 123));
            }
            
        }

        private void UpdateThing(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - prevTimeBubble > newTimeBubble)
            {
                prevTimeBubble = gameTime.TotalGameTime;
                _3pilihan.listBubble.Clear();
                AddThing();
            }

            if (gameTime.TotalGameTime - prevTimeBubble > newTimeCumi)
            {
                prevTimeBubble = gameTime.TotalGameTime;
                AddThing();
            }



            foreach (Sprite sp in _3pilihan.listBubble)
                sp.Update(gameTime);
            
            foreach (Sprite rp in listCumi)
                rp.Update(gameTime);
            
            CollisionThing();
        }
    }
}
