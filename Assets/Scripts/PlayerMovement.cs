using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float RunSpeed;
    [SerializeField] private Vector2 _inputVector = Vector2.zero;
    [SerializeField] private GameObject playerWeapon;
    
    private Animator _playerAnimator;
    private PlayerState _playerState;
    private Vector3 _moveDirection = Vector3.zero;
    private Transform _playerTransform; 
    
    private readonly int MovementXHash = Animator.StringToHash("MovementX");
    private readonly int MovementYHash = Animator.StringToHash("MovementY");
    private static readonly int IsRunningHash = Animator.StringToHash("IsRunning");
    private static readonly int EquipBow = Animator.StringToHash("EquipBow");
    private static readonly int IsBowEquipped = Animator.StringToHash("IsBowEquipped");

    private void Awake()
    {
        _playerTransform = transform;
        _playerAnimator = GetComponent<Animator>();
        _playerState = GetComponent<PlayerState>();
    }

    public void OnMove(InputValue value)
    {
        _inputVector = value.Get<Vector2>();
        
        _playerAnimator.SetFloat(MovementXHash, _inputVector.x);
        _playerAnimator.SetFloat(MovementYHash, _inputVector.y);
    }

    public void OnRun(InputValue value)
    {
        if (value.isPressed)
        {
            if (!_playerState.IsBowEquipped) return;
            if (_playerState.IsAiming) return;
            _playerState.IsRunning = true;
        }
        else
        {
            _playerState.IsRunning = false;
        }
        _playerAnimator.SetBool(IsRunningHash, _playerState.IsRunning);
    }

    public void OnEquipBow(InputValue value)
    {
        if (value.isPressed)
        {
            _playerState.IsBowEquipped = !_playerState.IsBowEquipped;
            if(_playerState.IsBowEquipped) _playerAnimator.SetTrigger(EquipBow);
            _playerAnimator.SetBool(IsBowEquipped,  _playerState.IsBowEquipped);
            playerWeapon.SetActive(_playerState.IsBowEquipped);
        }
    }

    public void Update()
    {
        _moveDirection = _playerTransform.forward * _inputVector.y + _playerTransform.right * _inputVector.x;
        float currentSpeed = _playerState.IsRunning ? RunSpeed : WalkSpeed;
        if (_playerState.IsAiming) currentSpeed = WalkSpeed / 2;
        Vector3 movementDirection = _moveDirection * (currentSpeed * Time.deltaTime);
        transform.position += movementDirection;
    }
}
