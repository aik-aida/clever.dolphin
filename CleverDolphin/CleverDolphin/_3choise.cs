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
        Random rand;

        public _3choise(Texture2D textureBubble, SpriteFont text, int number)
            : base(textureBubble)
        {
            listBubble = new List<Sprite>();
            this.textureBubble =textureBubble;
            this.text = text;
            this.number = number;

            rand = new Random();
        }
        
        public void UpdateList()
        {
            AddThing();
        }

        private void AddThing()
        {
            
            int answerPos;
            int a;
            int i;
            String _string;

            answerPos = rand.Next(1, 4);
            

            for(i = 1; i <= 3; i++)
            {
                
                a = rand.Next(1, 4);

                if (i == answerPos)
                {
                    _string = CreateAnswer(true);
                    listBubble.Add(new Bubble(textureBubble, text, _string, true, a, i));
                }
                else
                {
                    _string = CreateAnswer(false);
                    listBubble.Add(new Bubble(textureBubble, text, _string, false, a, i));
                }
            }
        }

        private String CreateAnswer(Boolean val)
        {
                int a=0;
                int b=0;
                int idOperand;
                int position;
                int num;
                String text;

                num = number;
                a = rand.Next(1, 10);
                idOperand = rand.Next(0, 1); // belum pembagian, dan pengalian
                position = rand.Next(0, 3);

                text = "";

                switch (idOperand)
                {
                    case 0: // '+'
                        b = num + a;
                        if (!val)
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
                        if (!val)
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
                                text=a.ToString() + " ";
                                if(b>=0)
                                    text+="-";
                                text+= " "+b.ToString() + " = _";
                                break;
                        }
                        break;

                    case 2: // 'x'
                        b = num * a;
                        if (!val)
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
                        if(true)
                        {
                            if (num > a)
                                b = num / a;
                            else
                                b = a / num;

                            if (!val)
                                b += rand.Next(0, 6);

                            switch (position)
                            {

                                case 0: //_kiri
                                    text="_ : " + a.ToString() + " = " + b.ToString();
                                    break;
                                case 1: //_tengah
                                    text=a.ToString() + " : _ = " + b.ToString();
                                    break;
                                case 2: //_kanan
                                    text = a.ToString() + " : " + b.ToString() + " = _";
                                    break;
                            }
                        }
                            break;
                }

                return text;
        }
    }
}
