using System;
using Input.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace Cubes
{
    public class Cube: MonoBehaviour, IDisposable
    {
        public class Factory: PlaceholderFactory<Vector3, IMoveInput, Color, Cube>
        {
        }

        [SerializeField] private Renderer _renderer;

        private IMoveInput _moveInput;
        private Color _color;
        private Vector3 _move;
        private Transform _target;
        
        private static readonly int Color = Shader.PropertyToID("_BaseColor");

        [Inject]
        private void Construct(Vector3 position, IMoveInput moveInput, Color color)
        {
            _moveInput = moveInput;
            _color = color;
            transform.position = position;
        }

        private void Start()
        {
            _renderer.material.SetColor(Color, _color);
            
            _moveInput
                .MoveInputAsObservable()
                .Subscribe(move =>
                {
                    _move = new Vector3(move.x, 0, move.y) * Time.deltaTime*5;
                })
                .AddTo(this);
        }

        private void Update()
        {
            transform.position += _move;
            if (_target == null) return;
            var trans = transform;
            trans.forward = (_target.position - trans.position).normalized;
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }

        public void SetTarget(Cube cube)
        {
            _target = cube.transform;
        }
    }
}