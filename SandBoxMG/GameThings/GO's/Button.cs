using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SandBoxMG.Content.Code.Scenes.GameObjects.Components;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using Microsoft.Xna.Framework.Content;
using SandBoxMG.Content.Code.InputManager;
using System.Diagnostics;

namespace SandBoxMG.GameThings.GO_s
{
        public class Button : GameObject
    {
        private Vector2 buttonSize;
        private Vector2 buttonPosition;
        private string buttonText;
        private string buttonTextureName;

        public Button()
        {
            buttonPosition = Vector2.Zero;
            buttonSize = Vector2.One;
            buttonText = string.Empty;
            buttonTextureName = string.Empty;
        }

        public Button(Vector2 position, Vector2 size, string textureName, string text)
        {
            buttonPosition = position;
            buttonSize = size;
            buttonText = text;
            buttonTextureName = textureName;
        }

        public override void InitializeGameObject(ContentManager content)
        {
            SpriteComponent sprite = CreateGenericComponent<SpriteComponent>();
            sprite.InitializeSpriteComponent(buttonPosition);
            sprite.LoadSpriteTexture(buttonTextureName, content);

            CollisionComponent collider = CreateGenericComponent<CollisionComponent>();
            collider.InitializeComponent(this);
            collider.InitializeCollisionComponent(buttonSize, this);

            TextComponent text = CreateGenericComponent<TextComponent>();
            text.InitializeTextComponent(buttonPosition);
            text.SetText(buttonText);


            base.InitializeGameObject(content);
        }

        public override void UpdateGameObject()
        {
            if (InputManager.Clicked)
            {
                Debug.WriteLine(InputManager.mouseCursor);
                {
                    Debug.WriteLine("asdas");

                }
            }
            base.UpdateGameObject();
        }
        public override void renderComponents(SpriteBatch _spriteBatch)
        {
            base.renderComponents(_spriteBatch);
        }
        public void SetButtonProperties(Vector2 position, Vector2 collisionSize, string textureName, string text)
        {
            buttonPosition = position;
            buttonSize = collisionSize;
            buttonTextureName = textureName;
            buttonText = text;

            _positionOfTheGameObject = buttonPosition;
        }
    }
}
