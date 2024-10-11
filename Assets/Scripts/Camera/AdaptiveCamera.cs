using UnityEngine;

public class AdaptiveCamera : MonoBehaviour
{
    [Header("Position & Rotation")]
    [SerializeField] private Vector3 _normalPosition = new Vector3(0f, 2.25f, -3.05f);
    [SerializeField] private Vector3 _normalRotation = new Vector3(47f, 0f, 0f);

    [Header("Field Of View")]
    [SerializeField] private float _fieldOfViewNormal = 60;
    [SerializeField] private float _fieldOfViewCube = 90;

    private Camera _camera;

    private float _viewCoeff = 1f;

    private float _screenWidth = 0;
    private float _screenHeigth = 0;

    private float _normalResolution = 9f / 16f;

    private void Awake()
    {
        _camera = GetComponent<Camera>();

        _screenHeigth = Screen.height;
        _screenWidth = Screen.width;

        if (_screenHeigth / _screenWidth > 1f)
        {
            _viewCoeff = _screenHeigth / _screenWidth;

            if (_viewCoeff > 2.35f)
                _viewCoeff = 2.35f;

            _camera.fieldOfView = _fieldOfViewNormal * _viewCoeff;
        }
        else if (_screenWidth / _screenHeigth == 1f)
            _camera.fieldOfView = _fieldOfViewCube;
        else
            _camera.fieldOfView = (1f + (_screenHeigth / _screenWidth) - _normalResolution) * _fieldOfViewNormal;

        gameObject.transform.position = _normalPosition;
    }
}
