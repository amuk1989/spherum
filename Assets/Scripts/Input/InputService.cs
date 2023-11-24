using Input.Interface;
using UnityEngine;
using Zenject;

namespace Input
{
    public class InputService: IInputService
    {
        private readonly InputModel.Factory _factory;

        private IMoveInput _moveInput;
        private IMoveInput _altMoveInput;

        public InputService(InputModel.Factory factory)
        {
            _factory = factory;
        }

        public void InitiateInputs()
        {
            var keyCodeData = new KeyCodeData()
            {
                DownKey = KeyCode.S,
                UpKey = KeyCode.W,
                LeftKey = KeyCode.A,
                RightKey = KeyCode.D
            };
            
            _moveInput = CreateInputModel(keyCodeData);
            
            var altKeyCodeData = new KeyCodeData()
            {
                DownKey = KeyCode.DownArrow,
                UpKey = KeyCode.UpArrow,
                LeftKey = KeyCode.LeftArrow,
                RightKey = KeyCode.RightArrow
            };
            
            _altMoveInput = CreateInputModel(altKeyCodeData);
        }


        public IMoveInput GetInputModel()
        {
            return _moveInput;
        }

        private InputModel CreateInputModel(KeyCodeData keyCodeData)
        {
            var model = _factory.Create(keyCodeData);
            model.StartInputFlow();
            return model;
        }

        public IMoveInput GetAlternativeInputModel()
        {
            return _altMoveInput;
        }
    }
}