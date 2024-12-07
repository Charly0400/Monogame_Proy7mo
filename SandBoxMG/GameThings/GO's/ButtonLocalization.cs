using SandBoxMG.Content.Code.Scenes.GameObjects.Components;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using SandBoxMG.Content.Code.Localitation;
using SandBoxMG.Content.Code.InputManager;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SandBoxMG.Content.Code.Scenes;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace SandBoxMG.GameThings.GO_s
{
    public class ButtonLocalization : GameObject
    {
        private Vector2 _position;
        private Vector2 _collisionSize;
        private String _textureName;
        private string _textKey;
        private TextComponent _textComponent;
        private ContentManager contentManager;
        private MainMenuScene _parentScene;
        private bool _clickProcessed = false;



        public ButtonLocalization() { }

        public void SetButtonProperties(Vector2 position, Vector2 collisionSize, string nameTexture, string textKey, ContentManager content, MainMenuScene parentScene)
        {
            _position = position;
            _collisionSize = collisionSize;
            _textureName = nameTexture;
            _textKey = textKey;
            _parentScene = parentScene;
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

            _textComponent = CreateGenericComponent<TextComponent>(); // Actualizar miembro de clase
            _textComponent.InitializeComponent(this);
            _textComponent.SetText(LocalizationManager.GetLocalizedText(_textKey));

            base.InitializeGameObject(content);
        }

        public void ReloadButtonText()
        {
            if (_textComponent != null)
            {
                _textComponent.SetText(LocalizationManager.GetLocalizedText(_textKey)); // Actualizar texto
            }
        }
        
        public override void UpdateGameObject()
        {
            if (InputManager.Clicked &&
        !   _clickProcessed && // Procesar solo si no está marcado
            new Rectangle((int)_position.X, (int)_position.Y, (int)_collisionSize.X, (int)_collisionSize.Y)
            .Intersects(InputManager.mouseCursor))
            {
                _clickProcessed = true;
                OnClickLocalization();
            }

            if(!InputManager.Clicked)
            {
                _clickProcessed = false;
            }

            
        }
        public override void renderComponents(SpriteBatch _spriteBatch)
        {
            base.renderComponents(_spriteBatch);
        }

        public virtual void OnClickLocalization()
        {
            
            LocalizationManager.ToggleLanguage();
            _parentScene.UpdateLocalizedTexts();
            Debug.WriteLine("HOLA");
      
        }
    }
}
