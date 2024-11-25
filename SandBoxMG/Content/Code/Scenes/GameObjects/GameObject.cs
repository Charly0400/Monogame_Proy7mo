using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SandBoxMG.Content.Code.Scenes.GameObjects.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxMG.Content.Code.Scenes.GameObjects
{
    public class GameObject
    {
        public List<Component> _componentsOfTheGO;
        public Vector2 _positionOfTheGameObject;
        

        public GameObject()
        {
            _componentsOfTheGO = new List<Component>();
        }

        public virtual void InitializeGameObject(ContentManager content)
        {
            foreach (Component component in _componentsOfTheGO)
            {
                component.InitializeComponent(this);
            }
        }

        public virtual void renderComponents(SpriteBatch _spriteBatch)
        {
            foreach (Component component in _componentsOfTheGO)
            {
                component.RenderComponent(_spriteBatch);
            }
        }
        
        public virtual void UpdateGameObject()
        {
            foreach (Component component in _componentsOfTheGO)
            {
                component.UpdateComponent();
            }
        }
        public virtual void UnloadGameObject()
        {
            foreach (Component component in _componentsOfTheGO.ToList())
            {
                if (_componentsOfTheGO.Count != 0)
                {
                    _componentsOfTheGO.Remove(component);
                }
            }
        }

        public virtual T CreateGenericComponent<T>() where T : Component, new()   
        {
            T component = new T();
            _componentsOfTheGO.Add(component);
            return component;
        }
    }
}
