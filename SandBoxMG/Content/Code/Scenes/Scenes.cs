using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxMG.Content.Code.Scenes
{
    public class Scenes
    {
        protected List<GameObject> _GameObjectsInTheScene;

        public Scenes()
        {
            _GameObjectsInTheScene = new List<GameObject>();
        }

        public virtual void InitializeScene(ContentManager content)
        {
           foreach(GameObject gameObject in _GameObjectsInTheScene)
            {
                gameObject.InitializeGameObject(content);
            }
        }

        public void UpdateScene()
        {
            foreach (GameObject gameObject in _GameObjectsInTheScene.ToList<GameObject>())
            {
                gameObject.UpdateGameObject();
            }
        }

        public void RenderScene(SpriteBatch _spriteBatch)
        {
            foreach (GameObject gameObject in _GameObjectsInTheScene)
            {
                gameObject.renderComponents(_spriteBatch);
            }
        }

        public void UnloadScene()
        {
            foreach (GameObject gameObject in _GameObjectsInTheScene.ToList())
            {
                if (_GameObjectsInTheScene.Count != 0)
                {
                    _GameObjectsInTheScene.Remove(gameObject);
                }
               
            }
        }

        public T CreateGenericGameObject<T>() where T : GameObject, new()
        {
            T gameObject = new T();
            _GameObjectsInTheScene.Add(gameObject);
            return gameObject;
        }


    }
}
