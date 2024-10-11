using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputController _inputController;

    [SerializeField] private Player _player;

    [SerializeField, Range(0.1975f, 0.21f)] private float _doubleClickTime = .2f;
    private float _currentHoldButtonTime = 0f;

    private int _clickCounter = 0;

    private float _horizontal = 0;
    private float _vertical = 0;

    private float lastClickTime;  

    private void Awake()
    {
        _player = GetComponent<Player>();
        _currentHoldButtonTime = 0f;
    }

    private void Update()
    {
        if (_inputController.HorizontalAxisDown() /*Input.GetButtonDown(GlobalStringVars.HORIZONTAL)*/ || _inputController.VerticalAxisDown() /*Input.GetButtonDown(GlobalStringVars.VERTICAL)*/)
        {
            if (_player.IsPossibleSwitchDiretion)
            {
                SetMoveDirection();

                if (_player.IsStopped)
                    SwitchPlayerMoveState();

                _player.FreezeMoveInput();
            }
        }
        else
        {
            if (_inputController.ActionInputDown())
            {
                if (_clickCounter == 0)
                {
                    _clickCounter = 1;
                    StartCoroutine(CountDownSwitchMoveState());
                }
                else if (_clickCounter == 1)
                {
                    Jump();
                    _clickCounter = 0;
                }
            }

            if (_inputController.ActionInputUp())
            {
                _currentHoldButtonTime = 0f;
            }
        }

        MovePlayer();
    }

    private void SetMoveDirection()
    {
        float inputResult = 0;

        if (_inputController.HorizontalAxisDown()/*Input.GetButtonDown(GlobalStringVars.HORIZONTAL)*/)
        {
            _vertical = 0;
            inputResult = _inputController.HorizontalAxisRaw();

            if (inputResult != 0)
                _horizontal = inputResult;
        }
        else if (_inputController.VerticalAxisDown()/*Input.GetButtonDown(GlobalStringVars.VERTICAL)*/)
        {
            _horizontal = 0;
            inputResult = _inputController.VerticalAxisRaw();

            if (inputResult != 0)
                _vertical = inputResult;
        }
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(_horizontal, 0, _vertical);
        _player.Move(moveDirection);
    }

    private void Jump()
    {
        _player.Jump();
    }

    private void SwitchPlayerMoveState()
    {
        _player.MoveOrStop();
    }

    private IEnumerator CountDownSwitchMoveState()
    {
        yield return new WaitForSeconds(_doubleClickTime);

        if (_clickCounter == 1)
        {
            if (!_player.IsStopped)
                SwitchPlayerMoveState();
        }

        _clickCounter = 0;
    }
}
