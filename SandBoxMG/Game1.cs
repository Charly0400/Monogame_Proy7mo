using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using SandBoxMG.GameThings.GO_s;
using SandBoxMG.Content.Code.InputManager;
using SandBoxMG.Content.Code.Scenes;


namespace SandBoxMG
{
    public class Game1 : Game
    {
        Texture2D _SampleTexture;
        Vector2 _SampleTexturePos;
        float _STSpeed;
        int deadZone; 

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        protected List<GameObject> _GameObjectsInTheScene;
        public MainMenuScene MMTestScene;
        public CardsGameScene CGScene;

        public static SpriteFont _spriteFont { get; set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 720;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content/Media";
            IsMouseVisible = true;
            MMTestScene = new MainMenuScene();
            CGScene = new CardsGameScene();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _SampleTexturePos = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            _STSpeed = 100f;
            deadZone = 460;
            base.Initialize();
            CGScene.InitializeScene(Content);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _spriteFont = Content.Load<SpriteFont>("Fonts/fontTest");
          
            // TODO: use this.Content to load your game content here

        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space))
                MMTestScene.UnloadScene();

            if (Joystick.LastConnectedIndex == 0)
            {
                JoystickState jstate = Joystick.GetState((int)PlayerIndex.One);

                float updatedSampletextureSpeed = _STSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (jstate.Axes[1] < deadZone)
                {
                    _SampleTexturePos.Y -= updatedSampletextureSpeed;
                }
                else if (jstate.Axes[1] > deadZone)
                { 
                    _SampleTexturePos.Y += updatedSampletextureSpeed;
                }

                if (jstate.Axes[0] < deadZone)
                {
                    _SampleTexturePos.X -= updatedSampletextureSpeed;
                }
                else if (jstate.Axes[0] > deadZone)
                {
                    _SampleTexturePos.X += updatedSampletextureSpeed;
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
            InputManager.Update();
            MMTestScene.UpdateScene();
            //CGScene.UpdateScene();   
            Draw(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            MMTestScene.RenderScene(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        #region Getters&Setters

        public SpriteFont GetFont { get { return _spriteFont; } }

        #endregion
    }
}
