using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxMG.Content.Code.Scenes.GameObjects.Components 
{
    public class TextComponent : Component
    {
        #region Variables

        SpriteFont font;
        Vector2 textPosition;
        string text;

        #endregion

        public TextComponent()
        {
            text = string.Empty;
        }

        #region 
        public override void InitializeComponent(GameObject _GORef)
        {
            InitializeTextComponent(_GORef._positionOfTheGameObject);
        }

        public void InitializeTextComponent(Vector2 posParam)
        {
            textPosition = new Vector2(posParam.X, posParam.Y);
            font = Game1._spriteFont;
        }

        public void SetText(string newText)
        {
            text = newText;
        }

        public override void RenderComponent(SpriteBatch _spriteBatch)
        {
            _spriteBatch.DrawString(font, text, textPosition, Color.Black); ;
        }

        #endregion
    }
}
