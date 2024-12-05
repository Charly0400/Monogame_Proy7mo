using SandBoxMG.Content.Code.Scenes.GameObjects.Components;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using SandBoxMG.Content.Code.InputManager;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System;

namespace SandBoxMG.GameThings.GO_s
{
    public class Button : GameObject
    {
        private Vector2 _position;
        private Vector2 _collsionSize;
        private String _textureName;
        private String _text;

        public Button()
        {

        }

        public void SetButtonProperties(Vector2 postion, Vector2 collsiionSize, String nameTexture, String text, ContentManager content)
        {
            _position = postion;
            _collsionSize = collsiionSize;
            _textureName = nameTexture;
            _text = text;
            InitializeGameObject(content);
        }

        public override void InitializeGameObject(ContentManager content)
        {
            _positionOfTheGameObject = _position;

            SpriteComponent _spriteComponent = CreateGenericComponent<SpriteComponent>();
            _spriteComponent.InitializeSpriteComponent(_position);
            _spriteComponent.LoadSpriteTexture(_textureName, content);

            CollisionComponent _collisionComponent = CreateGenericComponent<CollisionComponent>();
            _collisionComponent.InitializeComponent(this);
            _collisionComponent.InitializeCollisionComponent(_collsionSize, this);

            TextComponent _textComponent = CreateGenericComponent<TextComponent>();
            _textComponent.InitializeTextComponent(_position);
            _textComponent.SetText(_text);

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
