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

namespace SandBoxMG.GameThings.GO_s
{
    internal class Button : GameObject
    {
        private readonly string _texture;
        private Vector2 _position;


        public Button() 
        { 
            _texture = string.Empty;
            _position = Vector2.Zero;
        }
        public Button(string texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
        }
        public override void InitializeGameObject(ContentManager content)
        {
            CollisionComponent _colisionComponent = CreateGenericComponent<CollisionComponent>();
            _colisionComponent.InitializeComponent(this);
            _colisionComponent.InitializeCollisionComponent(new Vector2(12, 112), this);
            base.InitializeGameObject(content);
        }
        public override void UpdateGameObject()
        {
            base.UpdateGameObject();
        }
        public override void renderComponents(SpriteBatch _spriteBatch)
        {
            base.renderComponents(_spriteBatch);
        }

    }
}
