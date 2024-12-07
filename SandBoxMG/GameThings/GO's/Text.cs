using SandBoxMG.Content.Code.Scenes.GameObjects.Components;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using SandBoxMG.Content.Code.Localitation;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;

namespace SandBoxMG.GameThings.GO_s
{
    internal class Text : GameObject
    {
        private Vector2 _position;
        private string _textKey;
        private TextComponent _textComponent;
        public Text() { }

        public void SetPropertiesText(Vector2 position, String textKey, ContentManager content)
        {
            _position = position;
            _textKey = textKey;
            InitializeGameObject(content);
        }

        public override void InitializeGameObject(ContentManager content)
        {
            _positionOfTheGameObject = _position;

            _textComponent = CreateGenericComponent<TextComponent>();
            _textComponent.InitializeComponent(this);
            _textComponent.SetText(LocalizationManager.GetLocalizedText(_textKey));
            base.InitializeGameObject(content);
        }

        public override void renderComponents(SpriteBatch _spriteBatch)
        {
            base.renderComponents(_spriteBatch);
        }

        public void ReloadText()
        {
            if (_textComponent != null)
            {
                _textComponent.SetText(LocalizationManager.GetLocalizedText(_textKey));
            }
        }

    }
}
