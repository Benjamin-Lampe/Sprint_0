using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_Graphics
{
    internal class SetNoMoveNotAnimatedCommand : ICommand
    {
        private Sprint_0 game;

        public SetNoMoveNotAnimatedCommand(Sprint_0 game)
        {
            this.game = game;
        }

        public void Execute() 
        {
            game.setSprite(new NoMoveNotAnimated());
        }
    }
}
