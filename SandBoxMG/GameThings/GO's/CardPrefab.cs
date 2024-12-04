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
using static System.Net.Mime.MediaTypeNames;

namespace SandBoxMG.GameThings.GO_s
{
    public class CardPrefab : GameObject
    {
        private Vector2 prefabPosition;
        private Vector2 prefabCollisionSize;
        private string prefabTextureName;
        private string prefabText;
        public CardPrefab() 
        {
            prefabPosition = Vector2.Zero;
            prefabCollisionSize = Vector2.One;
            prefabTextureName = string.Empty;
            prefabText = string.Empty;
                
        }
        public CardPrefab(Vector2 position, Vector2 collisionSize, string textureName, string text) 
        {
            prefabPosition = position;
            prefabCollisionSize = collisionSize;
            prefabTextureName = textureName;
            prefabText = text;

        }

        public override void InitializeGameObject(ContentManager content)
        {
            SpriteComponent _spriteComponent = CreateGenericComponent<SpriteComponent>();
            _spriteComponent.InitializeSpriteComponent(prefabPosition);
            _spriteComponent.LoadSpriteTexture(prefabTextureName, content);

            CollisionComponent _collisionComponent = CreateGenericComponent<CollisionComponent>();
            _collisionComponent.InitializeComponent(this);
            _collisionComponent.InitializeCollisionComponent(prefabCollisionSize, this);

            TextComponent _textComponent = CreateGenericComponent<TextComponent>();
            _textComponent.InitializeTextComponent(prefabPosition);
            _textComponent.SetText(prefabText);

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

        public void SetPrefabProperties(Vector2 position, Vector2 collisionSize, string textureName, string text)
        {
            prefabPosition = position;
            prefabCollisionSize = collisionSize;
            prefabTextureName = textureName;
            prefabText = text;

            _positionOfTheGameObject = prefabPosition;

        }

    }
}
