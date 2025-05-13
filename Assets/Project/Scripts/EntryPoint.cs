using UnityEngine;

namespace TZ_StemBAI
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameController _gameController;

        [SerializeField] private int _countFiguresInPool;
        
        private void Start()
        {
            _gameController.StartGame();
        }
    }
}