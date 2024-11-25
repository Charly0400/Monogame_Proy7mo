using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SandBoxMG.Content.Code.Scenes.GameObjects.Components;
using System.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SandBoxMG.Content.Code.Scenes.GameObjects;

namespace SandBoxMG.GameThings
{
    public class Card : GameObject
    {
        public Card() { }

        public override void InitializeGameObject(ContentManager content)
        {
            _positionOfTheGameObject = new Vector2(220, 300);

            SpriteComponent _spriteComponent = CreateGenericComponent<SpriteComponent>();
            _spriteComponent.InitializeSpriteComponent(_positionOfTheGameObject);
            _spriteComponent.LoadSpriteTexture("SingleSanic", content);
            CollisionComponent _collisionComponent = CreateGenericComponent<CollisionComponent>();
            _collisionComponent.InitializeComponent(this);
            _collisionComponent.InitializeCollisionComponent(new Vector2(100, 100), this);
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
