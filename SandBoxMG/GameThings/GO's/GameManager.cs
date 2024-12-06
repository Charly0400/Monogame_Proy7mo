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
            // Evitar seleccionar más de dos cartas
            if (selectedCards.Count >= 2 || selectedCards.Contains(card))
                return;

            // Agregar la carta seleccionada
            selectedCards.Add(card);

            // Si ya hay dos cartas seleccionadas, evaluarlas
            if (selectedCards.Count == 2)
            {
                EvaluateSelectedCards();
            }
        }

        private void EvaluateSelectedCards()
        {
            // Obtener las dos cartas seleccionadas
            var firstCard = selectedCards[0];
            var secondCard = selectedCards[1];

            // Si coinciden (mismo índice)
            if (firstCard.index == secondCard.index)
            {
                // Eliminarlas de la escena
                gameScene.RemoveCardFromScene(firstCard);
                gameScene.RemoveCardFromScene(secondCard);
            }
            else
            {
                // Voltearlas nuevamente después de un pequeño retraso
                Task.Delay(600).ContinueWith(_ => {
                    firstCard.FlipBack();
                    secondCard.FlipBack();
                });
            }

            // Reiniciar la lista de cartas seleccionadas
            selectedCards.Clear();
        }
    }
}

