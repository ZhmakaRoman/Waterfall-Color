using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCube : MonoBehaviour
{
    [SerializeField] 
    private float _delayBeforeColor;
    [SerializeField]
    private ColorsCubes _cubePrefab;
  
    [SerializeField] 
    private int _count = 20; 

    [SerializeField]
    private float _step = 2; // Расстояние между кубиками

    [SerializeField]
    private float _delayBeforeSpawn = 0.1f; // Зажержка между спавном
    [SerializeField]
    private Transform _startSpawnPoint;
    [SerializeField]
    private float _recoloringDuration = 0.5f;

    private List<ColorsCubes> _colorsCubes = new List<ColorsCubes>();



    private void Start()
    {
        StartCoroutine(SpawnCubes());
    }
    
    public void ChanceColor()
    {
        StartCoroutine(ChageColorsCoroutine());
    }

    private IEnumerator ChageColorsCoroutine()
    {
        Color random = Random.ColorHSV();
        for (int i = 0; i < _colorsCubes.Count; i++)
        {
            _colorsCubes[i].ChanceColor(random,null );
            yield return new WaitForSeconds(_delayBeforeColor);
        }
    }

    private IEnumerator SpawnCubes()
    {
        for (var x = 0; x < _count; x++)
        {
            for (var z = 0; z < _count; z++)
            {
                var cube = Instantiate(_cubePrefab); // Создаем кубик на сцене

                var offset = new Vector3(x * _step, 0, z * _step); // Меняем ему позицию

                var position = _startSpawnPoint.position + offset;
                cube.transform.position = position;
                _colorsCubes.Add(cube);
                yield return new WaitForSeconds(_delayBeforeSpawn); // Ожидаем заданное время
            }
        }
    }
  
}


