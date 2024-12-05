using SandBoxMG.Content.Code.Scenes.GameObjects.Components;
using SandBoxMG.Content.Code.Scenes.GameObjects;
using SandBoxMG.Content.Code.InputManager;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SandBoxMG.Content.Code.Scenes;
using System.Collections.Generic;
using SandBoxMG.GameThings.GO_s;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using SandBoxMG.GameThings;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System;
using System.Reflection.Metadata;

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
            MainMenuText(content);
            ButtonLocalitation(content);
            ButtonGame(content);
            base.InitializeScene(content);
           
        }

        #region Botones

        public void ButtonGame(ContentManager content)
        {
            Vector2 _position = new Vector2(450, 450);
            Vector2 _collsionSize = new Vector2(190, 60);

            Button buttons = CreateGenericGameObject<Button>();
            buttons.SetButtonProperties(_position, _collsionSize, "Sprites/Boton", "       Play", content);
            //TEST
            //buttons.OnClick(() =>
            //{
            //    SceneManager.SetActiveScene(new Scenes(), content);
            //});

            _GameObjectsInTheScene.Add(buttons);
        }

        public void ButtonLocalitation(ContentManager content)
        {
            Vector2 _position = new Vector2(100, 450);
            Vector2 _collsionSize = new Vector2(190, 60);

            //scriptcardsspawner();
            Button buttons = CreateGenericGameObject<Button>();
            buttons.SetButtonProperties(_position, _collsionSize, "Sprites/Boton", "  Localization", content);

            _GameObjectsInTheScene.Add(buttons);

        }

        public void MainMenuText(ContentManager content)
        {
            Vector2 _position = new Vector2(275, 100);

            Text text = CreateGenericGameObject<Text>();
            text.SetPropertiesText(_position, "SIMIOJUEGO", content);

            _GameObjectsInTheScene.Add(text);
        }

        #endregion


    }
}
