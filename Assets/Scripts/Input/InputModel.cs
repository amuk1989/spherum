using System;
using Input.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace Input
{
    public class InputModel: IMoveInput
    {
        public class Factory: PlaceholderFactory<KeyCodeData, InputModel>
        {
        }
        
        private readonly ReactiveProperty<Vector3> _moveInput = new();
        private IDisposable _inputFlow;
        private readonly KeyCodeData _keyCodeData;

        public InputModel(KeyCodeData keyCodeData)
        {
            _keyCodeData = keyCodeData;
        }

        public void StartInputFlow()
        {
            _inputFlow = Observable
                .EveryUpdate()
                .Subscribe(_ => GetInput());
        }

        public void StopInputFlow()
        {
            _inputFlow?.Dispose();
        }

        public IObservable<Vector3> MoveInputAsObservable() => _moveInput.AsObservable();

        private void GetInput()
        {
            var moveVector = Vector3.zero;

            if (UnityEngine.Input.GetKey(_keyCodeData.UpKey)) moveVector += Vector3.up;
            if (UnityEngine.Input.GetKey(_keyCodeData.DownKey)) moveVector += Vector3.down;
            if (UnityEngine.Input.GetKey(_keyCodeData.LeftKey)) moveVector += Vector3.left;
            if (UnityEngine.Input.GetKey(_keyCodeData.RightKey)) moveVector += Vector3.right;

            _moveInput.Value = moveVector.normalized;
        }
    }

    public struct KeyCodeData
    {
        public KeyCode UpKey;
        public KeyCode DownKey;
        public KeyCode LeftKey;
        public KeyCode RightKey;
    }
}