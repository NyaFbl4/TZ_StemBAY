using System;

namespace TZ_StemBAI
{
    public class FigureData
    {
        private EShapeFigure _shape;
        private EBorderColor _color;
        private EAnimalType _animal;
        
        public EShapeFigure Shape => _shape;
        public EBorderColor Color => _color;
        public EAnimalType Animal => _animal;
    
        public FigureData(EShapeFigure shape, EBorderColor color, EAnimalType animal)
        {
            _shape = shape;
            _color = color;
            _animal = animal;
        }
    }
}