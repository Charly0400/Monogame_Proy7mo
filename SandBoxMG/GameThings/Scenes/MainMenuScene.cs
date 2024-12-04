using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SandBoxMG.Content.Code.Scenes;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using SandBoxMG.GameThings;
using SandBoxMG.GameThings.GO_s;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxMG.Content.Code.Scenes
{
    public class MainMenuScene : Scenes
    {
        Button button;

        public MainMenuScene()
        {
            _GameObjectsInTheScene = new List<GameObject>();

        }

        public override void InitializeScene(ContentManager content)
        {
            button = CreateGenericGameObject<Button>();
            base.InitializeScene(content);
        }
    }
}
