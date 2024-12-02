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
    public class CardsGameScene : Scenes
    {
        public CardsGameScene()
        {
            _GameObjectsInTheScene = new List<GameObject>();
        }
        public override void InitializeScene(ContentManager content)
        {
            int cardsPerRow = 3;
            Vector2 cardSize = new Vector2(150, 100);
            Vector2 startOffset = new Vector2(150, 10);

            for (int i = 0; i < 12; i++)
            {
                CardPrefab card = CreateGenericGameObject<CardPrefab>();

                int row = i / cardsPerRow;
                int col = i % cardsPerRow;

                Vector2 position = startOffset + new Vector2(col * (cardSize.X + 20), row * (cardSize.Y + 20));

                card.SetPrefabProperties(position, cardSize, "Sprites/SingleSanic", $"Carta {i + 1}");
                card.InitializeGameObject(content);
            }
        }         
    } 
}
