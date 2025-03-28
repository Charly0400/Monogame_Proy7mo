﻿using SandBoxMG.Content.Code.Scenes.GameObjects.Components;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using SandBoxMG.Content.Code.InputManager;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SandBoxMG.Content.Code.Scenes;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System;
using SandBoxMG.Content.Code.Localization;

namespace SandBoxMG.GameThings.GO_s
{
    public class ButtonGame : GameObject
    {
        private Vector2 _position;
        private Vector2 _collisionSize;
        private String _textureName;
        public String _textKey;

        public CardsGameScene CGScene;
        private TextComponent _textComponent;
        private ContentManager contentManager;


        public ButtonGame() { }

        public void SetButtonProperties(Vector2 postion, Vector2 collsiionSize, String nameTexture, String text, ContentManager content)
        {
            _position = postion;
            _collisionSize = collsiionSize;
            _textureName = nameTexture;
            _textKey = text;

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

            _textComponent = CreateGenericComponent<TextComponent>();
            _textComponent.InitializeComponent(this);
            _textComponent.SetText(LocalizationManager.GetLocalizedText(_textKey));

            base.InitializeGameObject(content);
        }

        public override void UpdateGameObject()
        {
            base.UpdateGameObject();
            if (InputManager.Clicked && new Rectangle((int)_position.X, (int)_position.Y, (int)_collisionSize.X, (int)_collisionSize.Y)
                .Intersects(InputManager.mouseCursor) )
            {
                OnClick();
            }
        }
        public override void renderComponents(SpriteBatch _spriteBatch)
        {
            base.renderComponents(_spriteBatch);
        }

        public virtual void OnClick()
        {
            CGScene = new CardsGameScene();
            SceneManager.SetActiveScene(CGScene, contentManager);
        }

        public void ReloadButtonText()
        {
            if (_textComponent != null)
            {
                _textComponent.SetText(LocalizationManager.GetLocalizedText(_textKey));
            }
        }
    }
}
