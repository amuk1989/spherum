using System;

namespace Cubes.Interfaces
{
    public interface ICubeService
    {
        public void SpawnCubes();
        public void DestroyCubes();
        public IObservable<float> CubesDistanceAsObservable();
    }
}