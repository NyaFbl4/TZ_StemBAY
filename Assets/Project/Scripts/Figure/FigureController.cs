using System;
using UnityEngine;

namespace TZ_StemBAI
{
    public class FigureController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _shapeRenderer;
        [SerializeField] private SpriteRenderer _animalRenderer;

        [SerializeField] private FigureConfig _figureConfig;

        private bool _isInteractable = true;
        private FigureData _figureData;

        public FigureData FigureData => _figureData;
        
        public void Initialize(FigureData data)
        {
            _figureData = data;
            
            _shapeRenderer.sprite = _figureConfig.ShapeSprites[(int)_figureData.Shape];
            _shapeRenderer.color = GetColorFromEnum(_figureData.Color);
            _animalRenderer.sprite = _figureConfig.AnimalSprites[(int)_figureData.Animal];
        }
        
        public void MoveToActionBar(Transform newPosition)
        {
            _isInteractable = false;

            var o = this.gameObject;
            
            o.transform.position = newPosition.position;
            o.transform.parent = newPosition;
            Destroy(this.gameObject.GetComponent<Rigidbody2D>());
        }

        private Color GetColorFromEnum(EBorderColor color)
        {
            return color switch
            {
                EBorderColor.Red => Color.red,
                EBorderColor.Green => Color.green,
                EBorderColor.Blue => Color.blue,
                EBorderColor.Yellow => Color.yellow
            };
        }

        private void OnMouseDown()
        {
            GameManager.Instance.SelectFigure(this);
        }
    }
}