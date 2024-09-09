using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_Graphics
{
    public class GamePadController : IController
    {
        private Sprint_0 game;

        public GamePadController(Sprint_0 game)
        {
            this.game = game;
        }

        public void Update() 
        { 
            // Todo: Make this do something
        }
    }
}
