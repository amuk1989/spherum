using System.Collections;
using System.Collections.Generic;
using Cubes.Interfaces;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class DistanceUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _distanceIndicator;

    [Inject] private readonly ICubeService _cubeService;
    // Start is called before the first frame update
    void Start()
    {
        _cubeService
            .CubesDistanceAsObservable()
            .Subscribe(distance => _distanceIndicator.text = $"Distance: {distance:F2}")
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
