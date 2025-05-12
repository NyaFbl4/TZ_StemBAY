using UnityEngine;

namespace TZ_StemBAI
{
    [CreateAssetMenu(menuName = "Game/FigureConfig", fileName = "FigureConfig ")]
    public class FigureConfig : ScriptableObject
    {
        [SerializeField] private Sprite[] _shapeSprites;
        [SerializeField] private Sprite[] _animalSprites;
        
        public Sprite[] ShapeSprites => _shapeSprites;
        public Sprite[] AnimalSprites => _animalSprites;
    }
}