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
    public class CardPrefab : GameObject
    {
        private Vector2 prefabPosition;
        private Vector2 prefabCollisionSize;
        private string prefabTextureName;
        private string prefabBaseCard;
        private string currentTexture;

        private SpriteComponent spriteComponent;
        private ContentManager contentManager;
        //TEST
        public GameManager GameManager { get; set; }

        private bool isDiscover = false;
        public int index = 0;

        public CardPrefab() { }
        
        public override void InitializeGameObject(ContentManager content)
        {
            currentTexture = prefabBaseCard;
            contentManager = content;

            spriteComponent = CreateGenericComponent<SpriteComponent>();
            spriteComponent.InitializeSpriteComponent(prefabPosition);
            spriteComponent.LoadSpriteTexture(currentTexture, content);

            CollisionComponent collisionComponent = CreateGenericComponent<CollisionComponent>();
            collisionComponent.InitializeComponent(this);
            collisionComponent.InitializeCollisionComponent(prefabCollisionSize, this);

            base.InitializeGameObject(content);
        }

        public override void UpdateGameObject()
        {
            base.UpdateGameObject();

            if (InputManager.Clicked && 
                new Rectangle((int)prefabPosition.X, (int)prefabPosition.Y, 
                (int)prefabCollisionSize.X, (int)prefabCollisionSize.Y)
               .Intersects(InputManager.mouseCursor))
            {
                OnClick();
            }
        }
        public override void renderComponents(SpriteBatch _spriteBatch)
        {
            base.renderComponents(_spriteBatch);
        }

        public void SetPrefabProperties(Vector2 position, Vector2 collisionSize, string textureName, string baseCard, int indexCard)
        {
            prefabPosition = position;
            prefabCollisionSize = collisionSize;
            prefabTextureName = textureName;
            prefabBaseCard = baseCard;
            index = indexCard;

            currentTexture = prefabBaseCard; 
            _positionOfTheGameObject = prefabPosition;

        }

        public void OnClick() {

            //if (!isClickable)
            //{
            //    if (isDiscover == false && currentTexture == prefabBaseCard)
            //    {
            //        currentTexture = prefabTextureName;
            //        Debug.WriteLine("Carta volteada");
            //        Debug.WriteLine(index);
            //        spriteComponent.LoadSpriteTexture(currentTexture, contentManager);
            //        isDiscover = true;
            //    }
            //    else if (isDiscover == true && currentTexture == prefabTextureName)
            //    {
            //        currentTexture = prefabBaseCard;
            //        Debug.WriteLine("Carta base");
            //        spriteComponent.LoadSpriteTexture(currentTexture, contentManager);
            //        isDiscover = false;
            //    }

            //}

            //isClickable = false;
            //Task.Delay(10).ContinueWith(_ => isClickable = true);

            if (!isDiscover)
            {
                currentTexture = prefabTextureName;
                spriteComponent.LoadSpriteTexture(currentTexture, contentManager);
                isDiscover = true;

                // Notificar al GameManager que esta carta ha sido seleccionada
                GameManager?.OnCardSelected(this);
            }

        }
        public void FlipBack()
        {
            currentTexture = prefabBaseCard;
            spriteComponent.LoadSpriteTexture(currentTexture, contentManager);
            isDiscover = false;
        }
    }
}
