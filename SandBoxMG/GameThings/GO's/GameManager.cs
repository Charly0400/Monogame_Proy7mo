using SandBoxMG.Content.Code.Scenes;
using System.Collections.Generic;
using SandBoxMG.GameThings.GO_s;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;

namespace SandBoxMG.GameThings.GO_s
{
    public class GameManager
    {
        private List<CardPrefab> selectedCards = new List<CardPrefab>();
        private CardsGameScene gameScene;

        public GameManager(CardsGameScene scene)
        {
            gameScene = scene;
        }

        public void OnCardSelected(CardPrefab card)
        {
            if (selectedCards.Count >= 2 || selectedCards.Contains(card))
                return;

            selectedCards.Add(card);

            if (selectedCards.Count == 2)
            {
                CheckSelectedCards();
            }
        }

        private void CheckSelectedCards()
        {
            var firstCard = selectedCards[0];
            var secondCard = selectedCards[1];

            if (firstCard.index == secondCard.index)
            {
                gameScene.RemoveCardFromScene(firstCard);
                gameScene.RemoveCardFromScene(secondCard);
            }
            else
            {
                Task.Delay(600).ContinueWith(_ => {
                    firstCard.FlipBack();
                    secondCard.FlipBack();
                });
            }

            selectedCards.Clear();
        }
    }
}

