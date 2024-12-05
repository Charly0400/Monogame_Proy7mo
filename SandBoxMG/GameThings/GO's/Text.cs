using SandBoxMG.Content.Code.Scenes.GameObjects.Components;
using SandBoxMG.Content.Code.Scenes.GameObjects;
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
        private String _text;
        public Text() { }

        public void SetPropertiesText(Vector2 position, String text, ContentManager content)
        {
            _position = position;
            _text = text;
            InitializeGameObject(content);
        }

        public override void InitializeGameObject(ContentManager content)
        {
            _positionOfTheGameObject = _position;

            TextComponent _textComponent = CreateGenericComponent<TextComponent>();
            _textComponent.InitializeComponent(this);
            _textComponent.SetText(_text);
            base.InitializeGameObject(content);
        }

    }
}
