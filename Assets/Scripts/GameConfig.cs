using System;
using Spheres;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "TexturesRegistry", menuName = "TexturesRegistry", order = 0)]
public class GameConfig : ScriptableObject
{
    [SerializeField] private SphereConfigData sphereConfigData;

    public SphereConfigData ConfigData => sphereConfigData;
}

[Serializable]
public class SphereConfigData
{
    [SerializeField] private Texture2D[] _textures;
    [SerializeField] private Material _sphereMaterial;
    [SerializeField] private Sphere _sphere;
    [SerializeField] private uint _count;

    [SerializeField] private float _minRadius;
    [SerializeField] private float _maxRadius;
        
    public Texture2D[] Textures => _textures;
    public Material SphereMaterial => _sphereMaterial;
    public Sphere SpherePrefab => _sphere;
    public uint Count => _count;
    public float MinRadius => _minRadius;
    public float MaxRadius => _maxRadius;
}