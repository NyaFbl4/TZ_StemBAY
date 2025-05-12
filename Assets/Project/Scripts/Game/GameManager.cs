using TZ_StemBAI.UI;
using UnityEngine;

namespace TZ_StemBAI
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        [SerializeField] private ActionBar _actionBar;
        [SerializeField] private PanelMenuController _menuController;

        private void Awake()
        {
            Instance = this;
        }

        public void SelectFigure(FigureController figure)
        {
            _actionBar.AddFigure(figure);
        }

        public void GameOver(bool isWin)
        {
            _menuController.Show();
            _menuController.ResultGame(isWin);
        }
    }
}