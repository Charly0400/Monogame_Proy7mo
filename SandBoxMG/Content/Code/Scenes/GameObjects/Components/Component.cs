using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxMG.Content.Code.Scenes.GameObjects.Components
{
    public class Component
    { 
        public Component() { }
        public virtual void InitializeComponent(GameObject _GOref) { }

        public virtual void RenderComponent(SpriteBatch _spriteBatch) { }

        public virtual void UpdateComponent() { }


        public virtual void UnloadComponent() { }

    }
}
