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

    class _3choise : Sprite
    {
        public List<Sprite> listBubble;
        Texture2D textureBubble;
        SpriteFont text;
        int number;

        public _3choise(Texture2D textureBubble, SpriteFont text, int number)
            : base(textureBubble)
        {
            listBubble = new List<Sprite>();
            this.textureBubble =textureBubble;
            this.text = text;
            this.number = number;
            AddThing(textureBubble, text, number);
        }
        
        public void UpdateList()
        {
            AddThing(textureBubble, text, number);
        }

        private void AddThing(Texture2D textureBubble, SpriteFont text, int number)
        {

            Random rand = rand = new Random();
            int num;

            num = rand.Next(0, 10);

            
            int answerPos = rand.Next(1, 4);

            for (int i = 1; i <= 3; i++)
            {
                String _string = CreateAnswer(number , answerPos, i);
                int a = rand.Next(1, 4);

                if(i==answerPos)
                    listBubble.Add(new Bubble(textureBubble, text, _string, true, a, i));
                else
                    listBubble.Add(new Bubble(textureBubble, text, _string, false, a, i));
            }
        }

        private String CreateAnswer(int num, int answerPos, int i)
        {
            Random rand = new Random();

                int a = rand.Next(1, 100);
                int b;

                int idOperand = rand.Next(0, 4);
                int position = rand.Next(0, 3);

                String text = "";

                switch (idOperand)
                {
                    case 0: // '+'
                        b = num + a;
                        if (i != answerPos)
                            b += rand.Next(0, 6);

                        switch (position)
                        {

                            case 0: //_kiri
                                text="_ + " + a.ToString() + " = " + b.ToString();
                                break;
                            case 1: //_tengah
                                text=a.ToString() + " + _ = " + b.ToString();
                                break;
                            case 2: //_kanan
                                text=a.ToString() + " + " + b.ToString() + " = _";
                                break;
                        }
                        break;

                    case 1: // '-'
                        b = num - a;
                        if (i != answerPos)
                            b += rand.Next(0, 6);

                        switch (position)
                        {

                            case 0: //_kiri
                                text="_ - " + a.ToString() + " = " + b.ToString();
                                break;
                            case 1: //_tengah
                                text=a.ToString() + " - _ = " + b.ToString();
                                break;
                            case 2: //_kanan
                                text=a.ToString() + " - " + b.ToString() + " = _";
                                break;
                        }
                        break;

                    case 2: // 'x'
                        b = num * a;
                        if (i != answerPos)
                            b += rand.Next(0, 6);

                        switch (position)
                        {

                            case 0: //_kiri
                                text="_ * " + a.ToString() + " = " + b.ToString();
                                break;
                            case 1: //_tengah
                                text=a.ToString() + " * _ = " + b.ToString();
                                break;
                            case 2: //_kanan
                                text=a.ToString() + " * " + b.ToString() + " = _";
                                break;
                        }
                        break;

                    case 3: // '/'
                        b = num / a;
                        if (i != answerPos)
                            b += rand.Next(0, 6);

                        switch (position)
                        {

                            case 0: //_kiri
                                text="_ / " + a.ToString() + " = " + b.ToString();
                                break;
                            case 1: //_tengah
                                text=a.ToString() + " / _ = " + b.ToString();
                                break;
                            case 2: //_kanan
                                text = a.ToString() + " / " + b.ToString() + " = _";
                                break;
                        }
                        break;
                }

                return text;
        }
    }
}
