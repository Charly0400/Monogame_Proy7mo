using SandBoxMG.Content.Code.Scenes.GameObjects.Components;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using SandBoxMG.Content.Code.InputManager;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SandBoxMG.Content.Code.Scenes;
using System;
using System.Diagnostics;
using SandBoxMG.Content.Code.Localitation;

namespace SandBoxMG.GameThings.GO_s
{
    public class ButtonLocalization : GameObject
    {
        private Vector2 _position;
        private Vector2 _collisionSize;
        private String _textureName;
        public String _text;

        public CardsGameScene CGScene;
        private ContentManager contentManager;

        public Action OnLocalizationButtonClicked { get; set; }
        public string TextKey { get; private set; }

        public ButtonLocalization() { }

        public void SetButtonProperties(Vector2 position, Vector2 collisionSize, string nameTexture, string textKey, ContentManager content)
        {
            _position = position;
            _collisionSize = collisionSize;
            _textureName = nameTexture;
            TextKey = textKey; // Guarda la clave original
            _text = LocalizationManager.GetLocalizedText(textKey); // Obtén el texto traducido
            InitializeGameObject(content);
        }

        public override void InitializeGameObject(ContentManager content)
        {
            _positionOfTheGameObject = _position;

            contentManager = content;

            SpriteComponent _spriteComponent = CreateGenericComponent<SpriteComponent>();
            _spriteComponent.InitializeSpriteComponent(_position);
            _spriteComponent.LoadSpriteTexture(_textureName, content);

            CollisionComponent _collisionComponent = CreateGenericComponent<CollisionComponent>();
            _collisionComponent.InitializeComponent(this);
            _collisionComponent.InitializeCollisionComponent(_collisionSize, this);

            TextComponent _textComponent = CreateGenericComponent<TextComponent>();
            _textComponent.InitializeTextComponent(_position);
            _textComponent.SetText(_text);

            base.InitializeGameObject(content);
        }

        public override void UpdateGameObject()
        {
            base.UpdateGameObject();
            if (InputManager.Clicked &&
                new Rectangle((int)_position.X, (int)_position.Y, (int)_collisionSize.X, (int)_collisionSize.Y)
                    .Intersects(InputManager.mouseCursor))
            {
                OnLocalizationButtonClicked?.Invoke();
            }
        }
        public override void renderComponents(SpriteBatch _spriteBatch)
        {
            base.renderComponents(_spriteBatch);
        }

        public virtual void OnClickLocalization()
        {
            CGScene = new CardsGameScene();
            SceneManager.SetActiveScene(CGScene, contentManager);
        }

        public void ReloadButtonText(string textKey)
        {
            _text = LocalizationManager.GetLocalizedText(textKey);

            foreach (var component in components)
            {
                if (component is TextComponent textComponent)
                {
                    textComponent.SetText(_text);
                }
            }
        }
    }
}
