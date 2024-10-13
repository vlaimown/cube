using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _jumpForce = 2.5f;

    [SerializeField, Range(0.1f, 0.15f)] private float _inputFreeze = 0.1f;

    [Space(10)]
    [SerializeField] private UnityEvent _death;

    private Rigidbody _rb;
    [SerializeField] private Animator _animator;

    private ParticleSystem _particles;

    private AudioSource _deathSound;

    private float _currentSpeed = 0;
    private float _currentInputFreeze = 0;

    private bool _possibleSwitchDirection = true;
    private bool _isStopped = false;

    private bool _isJumping = false;

    private bool _isDead = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _particles = GetComponentInChildren<ParticleSystem>();
        _deathSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _currentSpeed = _speed;
        _possibleSwitchDirection = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            _isJumping = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            _isJumping = true;
    }

    public void Respawn()
    {
        _isDead = false;
        _isStopped = true;
        _rb.isKinematic = false;

        _animator.SetBool("Dead", false);
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
    }

    public void Move(Vector3 direction)
    {
        if (!_isDead && !_isStopped)
            transform.position += direction * _currentSpeed * Time.deltaTime;
    }

    public void Rotate(Vector3 direction)
    {
        if (direction.x == 1)
            transform.eulerAngles = new Vector3(0, 90, 0);
        else if (direction.x == -1)
            transform.eulerAngles = new Vector3(0, -90, 0);
        else if (direction.z == 1)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (direction.z == -1)
            transform.eulerAngles = new Vector3(0, -180, 0);
    }

    public void FreezeMoveInput()
    {
        _possibleSwitchDirection = false;
        StartCoroutine(ResetInputFreeze());
    }

    public void Jump()
    {
        if (!_isDead && !_isJumping)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _animator.SetTrigger("Jump");
        }
    }

    public void MoveOrStop()
    {
        if (_isStopped)
            SwitchMoveState(false, _speed);
        else
            SwitchMoveState(true, 0);
    }

    private void SwitchMoveState(bool stopState, float speed)
    {
        if (!_isDead)
        {
            _isStopped = stopState;
            _currentSpeed = speed;
        }
    }

    public void Death()
    {
        _animator.SetBool("Dead", true);
        _isDead = true;

        _death.Invoke();
        _particles.Play();
        _deathSound.Play();

        _rb.isKinematic = true;
    }

    private IEnumerator ResetInputFreeze()
    {
        if (!_possibleSwitchDirection)
            yield return new WaitForSeconds(_inputFreeze);

        _possibleSwitchDirection = true;
    }

    public bool IsDead => _isDead;

    public bool IsPossibleSwitchDiretion => _possibleSwitchDirection;

    public bool IsStopped => _isStopped;
}
