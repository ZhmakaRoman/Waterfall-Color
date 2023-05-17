using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsCubes : MonoBehaviour
{
    [SerializeField]
    private float _chaceColorTime = 0.04f;
    [SerializeField] 
    private MeshRenderer _meshRenderer;//получаем доступ к материалу для смены цвета.

    private Material _material;

    private void Awake()
    {
        _material = _meshRenderer.material;
    }

    public void ChanceColor(Color color,Action onColorChange)
    {
        StopAllCoroutines();
        StartCoroutine(ChanceColorCoroutine(color,onColorChange));
    }

    private IEnumerator ChanceColorCoroutine(Color finalColor,Action onColorChange)
    {
        var startColor = _material.color;//узнаем стартовый цвет
        var currentTime = 0f;

        while (currentTime < _chaceColorTime)
        {
            currentTime += Time.deltaTime;
            var currentColor = Color.Lerp(startColor, finalColor, currentTime / _chaceColorTime);
            _material.color = currentColor;
            yield return null;
        }
        onColorChange?.Invoke();
    }
}
