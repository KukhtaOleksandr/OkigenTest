using Architecture.StateMachine;
using UnityEngine;
using Zenject;

public class ProductMovement : MonoBehaviour
{
    [Inject] private SignalBus _signalBus;
    private float _speed = 0.5f;
    private Vector3 _position;

    private void Start()
    {
        _position = new Vector3(-3f, transform.position.y, transform.position.z);
    }

    void OnEnable()
    {
        _signalBus.Subscribe<SignalGameFinished>(OnGameFinished);
    }
    void OnDisable()
    {
        _signalBus.Unsubscribe<SignalGameFinished>(OnGameFinished);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _position, _speed * Time.deltaTime);
    }

    private void OnGameFinished()
    {
        GameObject.Destroy(this);
    }
}
