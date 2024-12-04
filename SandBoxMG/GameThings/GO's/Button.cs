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

namespace SandBoxMG.GameThings.GO_s
{
        public class Button : GameObject
    {
        //private Action onClickAction; // Acción a ejecutar al hacer clic
        private Vector2 buttonSize;
        private string buttonText;
        private string buttonTextureName;

        public Button() 
        {
            buttonSize = Vector2.One;
            buttonText = string.Empty;
            buttonTextureName = string.Empty;
        }

        public void SetButtonProperties(Vector2 position, Vector2 size, string textureName, string text, Action onClick)
        {
            _positionOfTheGameObject = position;
            buttonSize = size;
            buttonTextureName = textureName;
            buttonText = text;
            //onClickAction = onClick;
        }

        public override void InitializeGameObject(ContentManager content)
        {
            // Crear y configurar los componentes del botón
            SpriteComponent sprite = CreateGenericComponent<SpriteComponent>();
            sprite.InitializeSpriteComponent(_positionOfTheGameObject);
            sprite.LoadSpriteTexture(buttonTextureName, content);

            CollisionComponent collider = CreateGenericComponent<CollisionComponent>();
            collider.InitializeComponent(this);
            collider.InitializeCollisionComponent(buttonSize, this);

            TextComponent text = CreateGenericComponent<TextComponent>();
            text.InitializeTextComponent(_positionOfTheGameObject);
            text.SetText(buttonText);

            base.InitializeGameObject(content);
        }

        //public override void UpdateGameObject()
        //{
        //    base.UpdateGameObject();

        //    // Detectar clic dentro del área del botón
        //    if (InputManager.Clicked && buttonBounds.Intersects(InputManager.mouseCursor))
        //    {
        //        onClickAction?.Invoke();
        //    }
        //}

        //public override void renderComponents(SpriteBatch spriteBatch)
        //{
        //    base.renderComponents(spriteBatch);
        //    spriteComponent.RenderComponent(spriteBatch);
        //}
    }
}
