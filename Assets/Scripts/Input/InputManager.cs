using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputControllerKeyboard _inputKeyboard;
    [SerializeField] private InputControllerMobile _inputMobile;

    private InputController _activeInput;

    private void Start()
    {
        //if (Input.touchSupported)
        //    _activeInput = _inputMobile;
        //else
        //    _activeInput = _inputKeyboard;

        _activeInput = _inputKeyboard;
    }
}
