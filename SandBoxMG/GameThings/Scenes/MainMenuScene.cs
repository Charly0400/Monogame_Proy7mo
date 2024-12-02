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
            List<CardPrefab> CardsP;
        public MainMenuScene()
        {
            _GameObjectsInTheScene = new List<GameObject>();

      
        }

        public override void InitializeScene(ContentManager content)
        {
            int cardsPerRow = 9; // Cantidad de cartas por fila
            Vector2 cardSize = new Vector2(50, 75);
            Vector2 startOffset = new Vector2(10, 10);

            for (int i = 0; i < 112; i++) // 9 cartas en total
            {
                CardPrefab card = CreateGenericGameObject<CardPrefab>();

                // Calcular fila y columna
                int row = i / cardsPerRow;
                int col = i % cardsPerRow;

                // Calcular posición de cada carta
                Vector2 position = startOffset + new Vector2(col * (cardSize.X + 20), row * (cardSize.Y + 20));

                card.SetPrefabProperties(position, cardSize, "Sprites/SingleSanic", $"Carta {i + 1}");
                card.InitializeGameObject(content);
            }
        }
    }
}
