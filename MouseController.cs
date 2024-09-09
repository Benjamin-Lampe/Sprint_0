using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_Graphics
{
    public class MouseController : IController
    {
        private Dictionary<string, ICommand> mouseMappings;
        private int screenWidth;
        private int screenHeight;
        
        public MouseController(GraphicsDeviceManager _graphics) 
        {
            mouseMappings = new Dictionary<string, ICommand>();
            this.screenWidth = _graphics.GraphicsDevice.Viewport.Bounds.Width;
            this.screenHeight = _graphics.GraphicsDevice.Viewport.Bounds.Height;
        }

        public void RegisterCommand(string name, ICommand command)
        {
            mouseMappings.Add(name, command);
        }

        public void Update()
        {
            MouseState state = Mouse.GetState();

            if(state.LeftButton == ButtonState.Pressed) 
            {
                HandleLeftClick(state);
            }

            if(state.RightButton == ButtonState.Pressed)
            {
                HandleRightClick(state);
            }
        }

        private void HandleRightClick(MouseState state)
        {
            mouseMappings["RightClick"].Execute();
        }

        private void HandleLeftClick(MouseState state) 
        {
            // Upper left hand corner
            if(state.X < screenWidth / 2 && state.Y < screenHeight / 2)
            {
                mouseMappings["LeftClickUL"].Execute();
            }

            // Lower left hand corner
            if(state.X < screenWidth / 2 && state.Y > screenHeight / 2)
            {
                mouseMappings["LeftClickLL"].Execute();
            }

            // Upper right hand corner
            if(state.X > screenWidth / 2 && state.Y < screenHeight / 2)
            {
                mouseMappings["LeftClickUR"].Execute();
            }

            // Lower right hand corner
            if(state.X > screenWidth / 2 && state.Y > screenHeight / 2)
            {
                mouseMappings["LeftClickLR"].Execute();
            }
        }
    }
}
