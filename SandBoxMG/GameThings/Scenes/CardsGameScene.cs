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

        private GameManager gameManager;
        public CardsGameScene() {
            _GameObjectsInTheScene = new List<GameObject>();
            gameManager = new GameManager(this);
        }
        public override void InitializeScene(ContentManager content) {
            base.InitializeScene(content);

            #region Variables

            int cardsPerRow = 4;
            Vector2 cardSize = new Vector2(157.5f, 157.5f);
            Vector2 startOffset = new Vector2(55, 55);

            var cardTypes = new List<(string textureName, int index)> {
                ("Sprites/abrams", 1),
                ("Sprites/churchill", 2),
                ("Sprites/landsverk", 3),
                ("Sprites/pizzaCheck", 4),
                ("Sprites/onichan", 5),
                ("Sprites/tiger", 6),
                ("Sprites/is_7", 7),
                ("Sprites/ztz", 8),
            };

            var cardPool = cardTypes.SelectMany(card => Enumerable.Repeat(card, 2)).ToList();

            var random = new Random();
            cardPool = cardPool.OrderBy( _ => random.Next()).ToList();

            #endregion

            for (int i = 0; i < cardPool.Count; i++)
            {
                var (textureName, index) = cardPool[i];
                CardPrefab card = CreateGenericGameObject<CardPrefab>();

                int row = i / cardsPerRow;
                int col = i % cardsPerRow;

                Vector2 position = startOffset + new Vector2(col * (cardSize.X), row * (cardSize.Y));

                card.SetPrefabProperties(position, cardSize, textureName, "Sprites/Portada", index);
                card.InitializeGameObject(content);
                card.GameManager = gameManager;
                _GameObjectsInTheScene.Add(card);
            }           
        }
        public void RemoveCardFromScene(CardPrefab card)
        {
            Task.Delay(600).ContinueWith(_ =>
            {
                card.UnloadGameObject();

            });
            //_GameObjectsInTheScene.Remove(card);
        }
    }
}

