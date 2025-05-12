using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TZ_StemBAI
{
    public class ActionBar : MonoBehaviour
    {
        [SerializeField] private Transform _actionBarTransform;
        [SerializeField] private GameController _gameController;

        public void AddFigure(FigureController newFigure)
        {
            if (_gameController.AddFigureInActiveBar(newFigure))
            {
                newFigure.MoveToActionBar(_actionBarTransform);
            }
        }
        
        public void ClearField()
        {
            foreach (Transform child in _actionBarTransform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}