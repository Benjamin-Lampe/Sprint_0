using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_Graphics
{
    internal class SetNoMoveAnimatedCommand : ICommand
    {
        private Sprint_0 game;
        public SetNoMoveAnimatedCommand(Sprint_0 game) 
        {
            this.game = game;
        }

        public void Execute()
        {
            game.setSprite(new NoMoveAnimated());
        }
    }
}
