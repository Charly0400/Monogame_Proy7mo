using SandBoxMG.Content.Code.Scenes.GameObjects;
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

namespace SandBoxMG.Content.Code.Scenes {
    public class CardsGameScene : Scenes {

        public CardsGameScene() {
            _GameObjectsInTheScene = new List<GameObject>();
        }
        public override void InitializeScene(ContentManager content) {

            //TestGO testGO = CreateGenericGameObject<TestGO>();
            base.InitializeScene(content);
            int cardsPerRow = 4;
            Vector2 cardSize = new Vector2(157.5f, 157.5f);
            Vector2 startOffset = new Vector2(55, 55);
            for (int i = 0; i < 16; i++) {
                CardPrefab card = CreateGenericGameObject<CardPrefab>();

                int row = i / cardsPerRow;
                int col = i % cardsPerRow;

                Vector2 position = startOffset + new Vector2(col * (cardSize.X), row * (cardSize.Y));

                card.SetPrefabProperties(position, cardSize, "Sprites/is_7", "Sprites/Portada");
                card.InitializeGameObject(content);
                _GameObjectsInTheScene.Add(card);

            }
        }     
    }
}

