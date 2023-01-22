using UnityEngine;

public class AdaptiveCamera : MonoBehaviour
{
    [SerializeField] private float _pixelsToUnits;
    [SerializeField] private int _targetWidth;
    [SerializeField] private Camera _camera;

    private float _targetFOV = 60;
    private float _targetZPosition = -3.2f;
    private float _fov;

    void Start()
    {
        int height = Mathf.RoundToInt(_targetWidth / (float)Screen.width * Screen.height);

        _fov = (height / _pixelsToUnits / 4);
        _camera.fieldOfView = _fov;
        float zPosition = _targetZPosition * _targetFOV / _fov;
        transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
    }
}
