using DG.Tweening;
using UnityEngine;

public class ProductMovement : MonoBehaviour
{
    private float _speed = 0.5f;
    private Vector3 pos;

    private void Start()
    {
        pos = new Vector3(-3f, transform.position.y, transform.position.z);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, _speed * Time.deltaTime);
    }
}
