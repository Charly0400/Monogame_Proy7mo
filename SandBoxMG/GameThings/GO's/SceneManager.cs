using SandBoxMG.Content.Code.Scenes.GameObjects.Components;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using SandBoxMG.Content.Code.InputManager;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SandBoxMG.Content.Code.Scenes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;

namespace SandBoxMG.GameThings.GO_s
{
    public class SceneManager : GameObject
    {
        private static Scenes _currentScene;

        public static void SetActiveScene(Scenes newScene, ContentManager content)
        {
            _currentScene?.UnloadScene();
            _currentScene = newScene;
            _currentScene.InitializeScene(content);
        }

        public static void UpdateScene()
        {
            _currentScene?.UpdateScene();
        }

        public static void RenderScene(SpriteBatch spriteBatch)
        {
            _currentScene?.RenderScene(spriteBatch);
        }
    }
}
