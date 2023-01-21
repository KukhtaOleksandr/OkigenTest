using Architecture.StateMachine;
using UnityEngine;
using Zenject;

public class ConveyorLineMovement : MonoBehaviour
{
    [Inject] private SignalBus _signalBus;
    private float _speed = -0.5f;

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
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
    private void OnGameFinished()
    {
        GameObject.Destroy(this);
    }
}
