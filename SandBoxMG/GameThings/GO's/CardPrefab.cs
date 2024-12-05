using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SandBoxMG.Content.Code.Scenes.GameObjects.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using SandBoxMG.Content.Code.InputManager;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace SandBoxMG.GameThings.GO_s
{
    public class CardPrefab : GameObject
    {
        private Vector2 prefabPosition;
        private Vector2 prefabCollisionSize;
        private string prefabTextureName;
        private string prefabBaseCard;
        private string currentTexture;
        private bool switchTexture;

        private string prefabText;

        private bool IsDiscover = false;
        public int Index = 0;
        public CardPrefab() 
        {

        }
        public CardPrefab(Vector2 position, Vector2 collisionSize, string textureName, string baseCard) 
        {
            prefabPosition = position;
            prefabCollisionSize = collisionSize;
            prefabTextureName = textureName;
            prefabBaseCard = baseCard;


        }

        public override void InitializeGameObject(ContentManager content)
        {
            currentTexture = prefabBaseCard;
            SpriteComponent _spriteComponent = CreateGenericComponent<SpriteComponent>();
            _spriteComponent.InitializeSpriteComponent(prefabPosition);
            _spriteComponent.LoadSpriteTexture(currentTexture, content);

            CollisionComponent _collisionComponent = CreateGenericComponent<CollisionComponent>();
            _collisionComponent.InitializeComponent(this);
            _collisionComponent.InitializeCollisionComponent(prefabCollisionSize, this);

            base.InitializeGameObject(content);
        }

        public override void UpdateGameObject()
        {

            base.UpdateGameObject();
            if (InputManager.Clicked && new Rectangle((int)prefabPosition.X, (int)prefabPosition.Y, (int)prefabCollisionSize.X, (int)prefabCollisionSize.Y)
               .Intersects(InputManager.mouseCursor)) {
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

            _positionOfTheGameObject = prefabPosition;

        }

        public void OnClick() {

            if (switchTexture != !switchTexture) {

                if (currentTexture == prefabTextureName) {
                    currentTexture = prefabBaseCard;
                    Debug.WriteLine("CartaBase");
                }

                else if (currentTexture == prefabBaseCard) {
                    currentTexture = prefabTextureName;
                    Debug.WriteLine("tanqueALV");
                }

                switchTexture = !switchTexture;
            }
            //this.UnloadGameObject();
        }

    }
}
