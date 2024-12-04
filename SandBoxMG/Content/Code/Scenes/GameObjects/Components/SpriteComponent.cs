using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SandBoxMG.Content.Code.Scenes.GameObjects;

namespace SandBoxMG.Content.Code.Scenes.GameObjects.Components {
    public class SpriteComponent : Component {
        Texture2D _Texture;
        Vector2 _TexturePos;

        public SpriteComponent() {

        }

        public override void InitializeComponent(GameObject _GORef) {
            InitializeSpriteComponent(_GORef._positionOfTheGameObject);
        }

        public void InitializeSpriteComponent(Vector2 _TexturePosParam) {

            _TexturePos = new Vector2(_TexturePosParam.X, _TexturePosParam.Y);
        }

        public void LoadSpriteTexture(string _TextureName, ContentManager content) {
            _Texture = content.Load<Texture2D>(_TextureName);
        }

        public override void RenderComponent(SpriteBatch _spriteBatch) {
            _spriteBatch.Draw(_Texture, _TexturePos, null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
        }

    }
}
