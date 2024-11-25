using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SandBoxMG.Content.Code.Scenes;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using SandBoxMG.GameThings.GO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxMG.Content.Code.Scenes
{
    public class MainMenuScene : Scenes
    {
        public MainMenuScene()
        {
            _GameObjectsInTheScene = new List<GameObject>();

      
        }

        public override void InitializeScene(ContentManager content)
        {
            //scriptcardsspawner();
            TestGO _testGo = CreateGenericGameObject<TestGO>();
            base.InitializeScene(content);
        }


    }
}
