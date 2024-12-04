using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SandBoxMG.Content.Code.Scenes;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using SandBoxMG.GameThings;
using SandBoxMG.GameThings.GO_s;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxMG.Content.Code.Scenes
{
    public class MainMenuScene : Scenes
    {
        private Vector2 _position;
        private Vector2 _collsionSize;


        public MainMenuScene()
        {
            _GameObjectsInTheScene = new List<GameObject>();
        }

        public override void InitializeScene(ContentManager content)
        {
            _position = new Vector2(350, 200);
            _collsionSize = new Vector2(150, 150);


            //scriptcardsspawner();
            Button buttons = CreateGenericGameObject<Button>();
            buttons.SetButtonProperties(_position, _collsionSize, "Sprites/pizzaCheck", "MYNIGGAAAAAA", content);
            base.InitializeScene(content);     
        }


        
    }
}
