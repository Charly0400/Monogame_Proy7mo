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
using System.Diagnostics;

namespace SandBoxMG.GameThings.GO_s
{
    public static class SceneManager 
    {
        private static Scenes _currentScene;

        public static void StartScene(Scenes ActualScene, ContentManager content) {
            _currentScene = ActualScene;
            ActualScene.InitializeScene(content);
        }

        public static void SetActiveScene(Scenes newScene, ContentManager content)
        {
            _currentScene?.UnloadScene();
            _currentScene = newScene;
            _currentScene.InitializeScene(content);
        }

        public static void UpdateScene(Scenes ActualScene)
        {
            _currentScene?.UpdateScene();
        }

        public static void RenderScene(SpriteBatch spriteBatch)
        {
            _currentScene?.RenderScene(spriteBatch);
        }

    }
}
