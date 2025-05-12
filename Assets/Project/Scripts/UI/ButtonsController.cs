using UnityEngine;

namespace TZ_StemBAI.UI
{
    public class ButtonsController : MonoBehaviour
    {
        [SerializeField] private GameController _gameController;

        public void StartGame()
        {
            _gameController.StartGame();
        }

        public void RespawnFigures()
        {
            _gameController.RespawnFigures();
        }
    }
}