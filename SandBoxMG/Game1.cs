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

        private SpriteFont font;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content/Media";
            IsMouseVisible = true;
            MMTestScene = new MainMenuScene();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _SampleTexturePos = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            _STSpeed = 100f;
            deadZone = 460;
            base.Initialize();
            //TestGO _testGo =  MMTestScene.CreateGenericGameObject<TestGO>();
            MMTestScene.InitializeScene(Content);
            
            //_GameObjectsInTheScene = new List<GameObject>();
            //_GameObjectsInTheScene.Add(new TestGO());
            //foreach (GameObject gameObject in _GameObjectsInTheScene)
            //    gameObject.InitializeGameObject(Content/*, new Vector2(120, 200)*/);
            //}


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Fonts/fontTest");
          
            // TODO: use this.Content to load your game content here

            //_SampleTexture = Content.Load<Texture2D>("SingleSanic");

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
            Draw(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            //SpriteTest();
            //GOTest();
            //Gameobject[].draw(SpriteBatch);
            //_spriteBatch.Draw(_SampleTexture, _SampleTexturePos, null, Color.White, 0f, new Vector2(_SampleTexture.Width / 2, _SampleTexture.Height/2), Vector2.One,SpriteEffects.None,0f);
            //foreach (GameObject gameObject in _GameObjectsInTheScene)
            //{
            //    gameObject.renderComponents(_spriteBatch);
            //}
            _spriteBatch.DrawString(font, "El triple P", Vector2.Zero, Color.Black);

            MMTestScene.RenderScene(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);


        }

        //protected void SpriteTest()
        //{
        //    SpriteComponent spriteComponent = new SpriteComponent();
        //    spriteComponent.InitializeSpriteComponent(new Vector2(0, 0));
        //    spriteComponent.LoadSpriteTexture("SingleSanic", Content);
        //    spriteComponent.Draw(_spriteBatch);
        //}

        //protected GameObject GOTest()
        //{
        //    GameObject go = new GameObject();
        //    SpriteComponent _spriteComponent = new SpriteComponent();
        //    go._positionOfTheGameObject = new Vector2(0, 0);
        //    go._componentsOfTheGO.Add(_spriteComponent);
        //    _spriteComponent.InitializeComponent(go);
        //    _spriteComponent.LoadSpriteTexture("SingleSanic", Content);
        //    go.InitializeGameObject(Content);
        //    return go;
        //}
    }
}
