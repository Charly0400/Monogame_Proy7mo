using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxMG.Content.Code.Scenes
{
    public class SceneManager
    {
        private Scenes _currentScene;

        public void SetActiveScene(Scenes newScene, ContentManager content)
        {
            // Desactiva la escena actual si existe
            _currentScene?.UnloadScene();

            // Asigna la nueva escena y la inicializa
            _currentScene = newScene;
            _currentScene.InitializeScene(content);
        }

        public void UpdateCurrentScene()
        {
            _currentScene?.UpdateScene();
        }

        public void RenderCurrentScene(SpriteBatch spriteBatch)
        {
            _currentScene?.RenderScene(spriteBatch);
        }
    }
}
