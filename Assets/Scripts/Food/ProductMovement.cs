using DG.Tweening;
using UnityEngine;

public class ProductMovement : MonoBehaviour
{
    private float _speed = 0.5f;
    private Vector3 _position;

    private void Start()
    {
        _position = new Vector3(-3f, transform.position.y, transform.position.z);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _position, _speed * Time.deltaTime);
    }
}
