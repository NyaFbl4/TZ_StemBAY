using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TZ_StemBAI
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private FiguresGenerator _figuresGenerator;
        [SerializeField] private ActionBar _actionBar;
        
        [SerializeField] private int _countFigureVariations;
        [SerializeField] private int _maxFigureCount;
        
        private int _countCurrentFigures;
        
        private readonly List<FigureController> _activeFigure = new();

        public void StartGame()
        {
            _countCurrentFigures = _countFigureVariations * 3;
            SpawnFigures();
        }

        public void RespawnFigures()
        {
            SpawnFigures();
        }

        public bool AddFigureInActiveBar(FigureController newFigure)
        {
            _activeFigure.Add(newFigure);
            CheckMatches(newFigure);
            
            if (_activeFigure.Count >= _maxFigureCount)
            {
                GameManager.Instance.GameOver(false);
                return false;
            }

            return true;
        }
        
        private void SpawnFigures()
        {
            _actionBar.ClearField();
            _activeFigure.Clear();
            _figuresGenerator.StartGenerator(_countCurrentFigures);
        }
        
        private void CheckMatches(FigureController newFigure)
        {
            List<FigureController> matches = new();
            
            foreach (var figure in _activeFigure)
            {
                if (figure != null && 
                    newFigure.FigureData.Animal == figure.FigureData.Animal &&
                    newFigure.FigureData.Color == figure.FigureData.Color &&
                    newFigure.FigureData.Shape == figure.FigureData.Shape)
                {
                    matches.Add(figure);
                }
            }
            
            if (matches.Count >= 3)
            {
                var figuresToRemove = matches.Take(3).ToList();
                
                foreach (var figure in figuresToRemove)
                {
                    _activeFigure.Remove(figure);
                    Destroy(figure.gameObject);
                    _countCurrentFigures--;
                }
            }

            if (_countCurrentFigures <= 0)
            {
                GameManager.Instance.GameOver(true);
            }
        }
    }
}