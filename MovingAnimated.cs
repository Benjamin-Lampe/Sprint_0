using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Intro_Graphics
{
    public class MovingAnimated : ISprite
    {
        private Texture2D Texture;
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;

        private const int FRAME_SLOW = 7;
        private const int DEFAULT_ROW = 0;

        private int[] rightRun = { 1, 2, 3, 4, 3, 2};
        private int[] leftRun = { 5, 6, 7, 8, 7, 6 };

        private int x;
        private int y;

        private bool is_running_left;

        private const int DEFAULT_X = 360;
        private const int DEFAULT_Y = 200;

        private const int LEFT_BOUNDARY = 150;
        private const int RIGHT_BOUNDARY = 600;

        public MovingAnimated() 
        {
            this.currentFrame = 0;
            this.totalFrames = (leftRun.Length) * FRAME_SLOW;
            this.x = DEFAULT_X;
            this.y = DEFAULT_Y;
        }

        public void Draw(SpriteBatch _spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int column = (currentFrame / FRAME_SLOW) % leftRun.Length;
            int frame = 0;

            if (is_running_left)
            {
                frame = leftRun[column];
            } else
            {
                frame = rightRun[column];
            }

            Rectangle sourceRectangle = new Rectangle(width * frame, height * DEFAULT_ROW, width, height);
            Rectangle destinationRectangle = new Rectangle(this.x, this.y, width, height);

            _spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void setSprite(Texture2D texture, int rows, int columns)
        {
            this.Texture = texture;
            this.Rows = rows;
            this.Columns = columns;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;

            Move_Sprite();
        }

        public void Move_Sprite()
        {
            // Kirby has run far enough to the left
            if(this.x < LEFT_BOUNDARY)
                is_running_left = false;

            // Kirby has run far enough to the right
            if (this.x > RIGHT_BOUNDARY)
                is_running_left = true;

            // Move Kirby to the left or right based on which direction they are running
            if (is_running_left)
            {
                this.x--;
            } else
            {
                this.x++;
            }

        }
    }
}
