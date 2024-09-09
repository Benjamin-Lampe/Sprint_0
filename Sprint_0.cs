using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;

namespace Intro_Graphics
{
    public class Sprint_0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont font;

        private ISprite sprite;

        private List<IController> controllerList;

        private const int FONT_X = 150;
        private const int FONT_Y = 400;

        public Sprint_0()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            controllerList = new List<IController>();

            // Initialize the keyboard
            KeyboardController keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.D0, new QuitCommand(this));
            keyboardController.RegisterCommand(Keys.D1, new SetNoMoveNotAnimatedCommand(this));
            keyboardController.RegisterCommand(Keys.D2, new SetNoMoveAnimatedCommand(this));
            keyboardController.RegisterCommand(Keys.D3, new SetMovingNotAnimatedCommand(this));
            keyboardController.RegisterCommand(Keys.D4, new SetMovingAnimatedCommand(this));

            // Initialize the mouse controller
            MouseController mouseController = new MouseController(_graphics);
            mouseController.RegisterCommand("RightClick", new QuitCommand(this));
            mouseController.RegisterCommand("LeftClickUL", new SetNoMoveNotAnimatedCommand(this));
            mouseController.RegisterCommand("LeftClickUR", new SetNoMoveAnimatedCommand(this));
            mouseController.RegisterCommand("LeftClickLL", new SetMovingNotAnimatedCommand(this));
            mouseController.RegisterCommand("LeftClickLR", new SetMovingAnimatedCommand(this));

            controllerList.Add(keyboardController);
            controllerList.Add(mouseController);

            sprite = new NoMoveNotAnimated();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Texture2D texture = Content.Load<Texture2D>("Kirby_Sprite_Atlas_NoBG");

            font = Content.Load<SpriteFont>("Credit");


            sprite.setSprite(texture, 1, 9);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach(IController controller in controllerList)
            {
                controller.Update();
            }

            sprite.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here
            sprite.Draw(_spriteBatch, new Vector2(360, 200));
            _spriteBatch.DrawString(font, "Credits\nPrgram Made By: Ben Lampe\nSprites From: https://www.spriters-resource.com/fullview/2853/", new Vector2(FONT_X, FONT_Y), Color.Black);

            _spriteBatch.End(); 

            base.Draw(gameTime);
        }

        public void setSprite(ISprite sprite)
        {
            this.sprite = sprite;

            Content.Unload();

            LoadContent();
        }
    }
}