using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TZ_StemBAI
{
    public class FiguresGenerator : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _container;
        
        [SerializeField] private FigureController _prefab;
        private List<FigureData> _figuresPool = new();

        public void StartGenerator(int countFigures)
        {
            ClearField();
            GenerateFiguresPool(countFigures);

            StartCoroutine(SpawnFigures());
        }

        private IEnumerator SpawnFigures()
        {
            while (_figuresPool.Count > 0)
            {
                SpawnFigure();

                yield return new WaitForSeconds(0.5f);
            }
        }
        
        private void SpawnFigure()
        {
            var figureGameObject = Instantiate(_prefab, 
                _spawnPoint.position, Quaternion.identity, _container);

            var figureData = _figuresPool[0];
            _figuresPool.RemoveAt(0);

            figureGameObject.GetComponent<FigureController>().Init(figureData);
        }

        private void GenerateFiguresPool(int countFigures)
        {
            _figuresPool.Clear();

            var figureVariations = countFigures / 3;
            
            for (int i = 0; i < figureVariations; i++)
            {
                var figure = new FigureData(GetRandomShapeFigure(), GetRandomBorderColor(), GetRandomAnimalType());
                
                for (int j = 0; j < 3; j++)
                {
                    _figuresPool.Add(figure);
                }
            }
            
            _figuresPool = _figuresPool.OrderBy(x => Random.value).ToList();
        }
        
        private EShapeFigure GetRandomShapeFigure()
        {
            var values = Enum.GetValues(typeof(EShapeFigure));
            var randomIndex = Random.Range(0, values.Length);
            
            return (EShapeFigure) values.GetValue(randomIndex);
        }
        
        private EBorderColor GetRandomBorderColor()
        {
            var values = Enum.GetValues(typeof(EBorderColor));
            var randomIndex = Random.Range(0, values.Length);
            
            return (EBorderColor) values.GetValue(randomIndex);
        }
        
        private EAnimalType GetRandomAnimalType()
        {
            var values = Enum.GetValues(typeof(EAnimalType));
            var randomIndex = Random.Range(0, values.Length);
            
            return (EAnimalType) values.GetValue(randomIndex);
        }
        
        private void ClearField()
        {
            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }
        }
    }
}