using System;
using UnityEngine;

namespace Input.Interface
{
    public interface IMoveInput
    {
        public IObservable<Vector3> MoveInputAsObservable();
    }
}