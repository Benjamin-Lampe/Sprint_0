using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_Graphics
{
    public class SetMovingAnimatedCommand : ICommand
    {
        private Sprint_0 game;
        public SetMovingAnimatedCommand(Sprint_0 game) 
        { 
            this.game = game;
        }

        public void Execute()
        {
            game.setSprite(new MovingAnimated());
        }
    }
}
