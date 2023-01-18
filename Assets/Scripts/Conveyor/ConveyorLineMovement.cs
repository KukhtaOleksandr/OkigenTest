using UnityEngine;

public class ConveyorLineMovement : MonoBehaviour
{
    private float _speed = -0.5f;
    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}
