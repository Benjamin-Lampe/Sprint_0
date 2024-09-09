using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_Graphics
{
    internal class QuitCommand : ICommand
    {
        private Sprint_0 game;

        public QuitCommand(Sprint_0 game) 
        { 
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
