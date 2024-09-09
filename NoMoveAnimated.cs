using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_Graphics
{
    public class NoMoveAnimated : ISprite
    {
        private Texture2D Texture;
        private int Rows;
        private int Columns;
        private const int DEFAULT_ROW = 0;
        private int currentFrame;
        private int totalFrames;
        private const int FRAME_SLOW = 7;
        private int[] spriteCol = { 1, 2, 3, 4, 3, 2 };

        public NoMoveAnimated()
        {
            this.currentFrame = 1;
            this.totalFrames = spriteCol.Length * FRAME_SLOW;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void Draw(SpriteBatch _spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int column = (currentFrame / FRAME_SLOW) % spriteCol.Length;

            Rectangle sourceRectangle = new Rectangle(width * spriteCol[column], height * DEFAULT_ROW, width, height);
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
