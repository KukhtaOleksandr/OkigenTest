using UnityEngine;
using Zenject;

namespace Conveyor
{
    public class ConveyorLinesFactory
    {
        private const float Offset = 0.7f;
        //private readonly Vector3 CreatePosition = new Vector3(2.532f, 0.135f, 0.21f);
        private readonly Vector3 CreatePosition = new Vector3(-1.648f, 0.135f, 0.21f);
        private readonly Vector3 CreateRotation = new Vector3(-90, 0, 0);
        private ConveyorLineMovement _conveyorPrefab;
        private ConveyorLineMovement _lastConveyorLine;

        public ConveyorLinesFactory(ConveyorLineMovement conveyorPrefab = null)
        {
            _conveyorPrefab = conveyorPrefab;
            InitialCreate();
        }

        public void Create()
        {
            Vector3 position = new Vector3(_lastConveyorLine.transform.position.x + Offset,
                                           _lastConveyorLine.transform.position.y,
                                           _lastConveyorLine.transform.position.z);
            _lastConveyorLine = GameObject.Instantiate(_conveyorPrefab, position, Quaternion.Euler(CreateRotation));
            
        }

        private void InitialCreate()
        {
            _lastConveyorLine = GameObject.Instantiate(_conveyorPrefab, CreatePosition, Quaternion.Euler(CreateRotation));
            for (int i = 0; i < 6; i++)
            {
                Create();
            }
        }
    }
}