using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_Graphics
{
    internal class MovingNotAnimated : ISprite
    {
        private Texture2D Texture;
        private int Rows;
        private int Columns;
        private const int DEFAULT_ROW = 0;
        private const int DEFAULT_COL = 0;
        private int x;
        private int y;
        private bool is_moving_up;
        private const int DEFAULT_X = 360;
        private const int DEFAULT_Y = 200;
        private const int TOP_Y = 100;
        private const int BOTTOM_Y = 300;

        public MovingNotAnimated() 
        {
            this.x = DEFAULT_X;
            this.y = DEFAULT_Y;
        }

        public void Draw(SpriteBatch _spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;

            Rectangle sourceRectangle = new Rectangle(width * DEFAULT_COL, height * DEFAULT_ROW, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);

            _spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        // Needs to move the sprite back and forth
        public void Update()
        {
            Move_Sprite();
        }

        private void Move_Sprite()
        {
            if (y < TOP_Y)
                is_moving_up = false;

            if(y > BOTTOM_Y)
                is_moving_up = true;

            if (is_moving_up)
            {
                y--;
            } else
            {
                y++;
            }

        }

        public void setSprite(Texture2D texture, int rows, int columns)
        {
            this.Texture = texture;
            this.Rows = rows;
            this.Columns = columns;
        }
    }
}
