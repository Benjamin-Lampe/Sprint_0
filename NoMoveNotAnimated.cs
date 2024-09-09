using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Common;

namespace Intro_Graphics
{
    public class NoMoveNotAnimated : ISprite
    {
        private Texture2D Texture;
        private int Rows;
        private int Columns;
        private const int DEFAULT_ROW = 0;
        private const int DEFAULT_COL = 0;

        public NoMoveNotAnimated() 
        {
            
        }

        // Does nothing, this sprite does not update
        public void Update()
        {

        }

        // Draws the Sprite in it's default pose.
        public void Draw(SpriteBatch _spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;

            Rectangle sourceRectangle = new Rectangle(width * DEFAULT_COL, height * DEFAULT_ROW, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            _spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void setSprite(Texture2D texture, int rows, int columns)
        {
            this.Texture = texture;
            this.Rows = rows;
            this.Columns = columns;
        }
    }
}
