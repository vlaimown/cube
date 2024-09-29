using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField, Range(0.2f, 0.21f)] private float _doubleClickTime = .2f;
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
        if (Input.GetButtonDown(GlobalStringVars.HORIZONTAL) || Input.GetButtonDown(GlobalStringVars.VERTICAL))
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
            if (Input.GetButtonDown(GlobalStringVars.ACTION))
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

            if (Input.GetButtonUp(GlobalStringVars.ACTION))
            {
                _currentHoldButtonTime = 0f;
            }
        }

        MovePlayer();
    }

    private void SetMoveDirection()
    {
        float inputResult = 0;

        if (Input.GetButtonDown(GlobalStringVars.HORIZONTAL))
        {
            _vertical = 0;
            inputResult = Input.GetAxisRaw(GlobalStringVars.HORIZONTAL);

            if (inputResult != 0)
                _horizontal = inputResult;
        }
        else if (Input.GetButtonDown(GlobalStringVars.VERTICAL))
        {
            _horizontal = 0;
            inputResult = Input.GetAxisRaw(GlobalStringVars.VERTICAL);

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
