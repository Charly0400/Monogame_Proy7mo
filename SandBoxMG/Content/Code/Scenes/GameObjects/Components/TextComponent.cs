using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxMG.Content.Code.Scenes.GameObjects.Components 
{
    internal class TextComponent : Component
    {
        #region Variables



        #endregion
        public TextComponent() 
        {
            
        }

        #region 
        public override void InitializeComponent(GameObject _GORef) 
        {
            InitializeTextComponent();
        }

        public void InitializeTextComponent( ) 
        {

        }
        public void LoadTextTexture(string _TextureName, ContentManager content) 
        {
           
        }

        public override void RenderComponent(SpriteBatch _spriteBatch) 
        {
            
        }

        #endregion
    }
}
