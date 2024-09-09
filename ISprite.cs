using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_Graphics
{
    public interface ISprite
    {
        void Draw(SpriteBatch _spriteBatch, Vector2 location);

        void Update();

        void setSprite(Texture2D texture, int rows, int columns);
    }
}
