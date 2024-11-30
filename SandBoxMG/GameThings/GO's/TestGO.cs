using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using SandBoxMG.Content.Code.Scenes.GameObjects.Components;
using System.Numerics;


namespace SandBoxMG.GameThings.GO_s
{
    internal class TestGO : GameObject
    {
        public TestGO() {  }

        public override void InitializeGameObject(ContentManager content)
        {
            //float x = 0;
            //float y = 0;
            //x += 10;
            _positionOfTheGameObject = new Vector2(200,120 /*x, y*/);

            SpriteComponent _spriteComponent = CreateGenericComponent<SpriteComponent>();
            _spriteComponent.InitializeSpriteComponent(_positionOfTheGameObject);
            _spriteComponent.LoadSpriteTexture("Sprites/SingleSanic", content);
            CollisionComponent _collisionComponent = CreateGenericComponent<CollisionComponent>();
            _collisionComponent.InitializeComponent(this);
            _collisionComponent.InitializeCollisionComponent(new Vector2(100, 100), this);
            TextComponent _textComponent = CreateGenericComponent<TextComponent>();
            _textComponent.InitializeTextComponent(_positionOfTheGameObject);
            _textComponent.SetText("MyNIGGA");
            base.InitializeGameObject(content);
        }

        public override void UpdateGameObject()
        {
           
            base.UpdateGameObject();

        }
        public override void renderComponents(SpriteBatch _spriteBatch)
        {
            base.renderComponents(_spriteBatch);
        }

    }
}
