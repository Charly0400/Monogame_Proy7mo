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

        private bool IsDiscover = false;
        public int Index = 0;

        //TEST
        private double lastClickTime = 0;
        private const double clickCooldown = 200;
        private double globalTime = 0;

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

        public void SetPrefabProperties(Vector2 position, Vector2 collisionSize, string textureName, string baseCard)
        {
            prefabPosition = position;
            prefabCollisionSize = collisionSize;
            prefabTextureName = textureName;
            prefabBaseCard = baseCard;

            currentTexture = prefabBaseCard; 
            _positionOfTheGameObject = prefabPosition;

        }

        public void OnClick() {

            if (IsDiscover = !IsDiscover)
            {
                currentTexture = prefabTextureName;
                Debug.WriteLine("Carta volteada");
                spriteComponent.LoadSpriteTexture(currentTexture, contentManager);
            }
            else
            {
                currentTexture = prefabBaseCard;
                Debug.WriteLine("Carta base");
                spriteComponent.LoadSpriteTexture(currentTexture, contentManager);

            }
        }
    }
}
