using Food;
using UnityEngine;
using Zenject;

namespace Conveyor
{
    public class ConveyorTrigger : MonoBehaviour
    {
        [Inject] private ConveyorLinesFactory _conveyorLinesFactory;
        void OnDrawGizmos()
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position,
            new Vector3(boxCollider.size.x, boxCollider.size.y, boxCollider.size.z));
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ConveyorLineMovement conveyorLine))
            {
                GameObject.Destroy(other.gameObject);
                _conveyorLinesFactory.Create();
            }
            else if (other.transform.parent.TryGetComponent(out Product product))
            {
                GameObject.Destroy(product.gameObject);
            }
        }
    }
}