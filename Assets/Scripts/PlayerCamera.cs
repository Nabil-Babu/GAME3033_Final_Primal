using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    
    public GameObject followTarget;
    public GameObject StandardCamera;
    public GameObject AimCamera; 
    
    [Header("Camera Settings")]
    [SerializeField] private float UpperPitchLimit = 80;
    [SerializeField] private float LowerPitchLimit = 5;
    [SerializeField] private float DefaultCameraPitch = 10; 
    [SerializeField] private float cameraRotationSpeed = 1f;
    [SerializeField] private float horizontalDamping = 1f;
    [SerializeField] private float verticalDamping = 1f;
    
    [Header("Debug Values")]
    [SerializeField] private Vector2 lookDelta;
    [SerializeField] private bool _isRMBPresssed = false; 
    
    private Animator _playerAnimator;
    private Transform _followTargetTransform;
    private Transform _playerTransform;
    private PlayerState _playerState;
    private Vector2 _previousMouseDelta;
    
    private static readonly int EquipArrow = Animator.StringToHash("EquipArrow");
    private static readonly int IsAiming = Animator.StringToHash("IsAiming");

    // Start is called before the first frame update
    void Start()
    {
        _followTargetTransform = followTarget.transform;
        _playerTransform = transform;
        _playerState = GetComponent<PlayerState>();
        _playerAnimator = GetComponent<Animator>();
        _previousMouseDelta = Vector2.zero; 
        _followTargetTransform.localEulerAngles = new Vector3(DefaultCameraPitch, 0, 0);
    }

    public void OnAim(InputValue value)
    {
        if (value.isPressed)
        {
            if (!_playerState.IsBowEquipped) return;
            _playerState.IsAiming = true; 
            _isRMBPresssed = true;
            _playerAnimator.SetTrigger(EquipArrow);
            StandardCamera.SetActive(false);
            AimCamera.SetActive(true);
        }
        else
        {
            _playerState.IsAiming = false; 
            _isRMBPresssed = false;
            StandardCamera.SetActive(true);
            AimCamera.SetActive(false);
        }
        _playerAnimator.SetBool(IsAiming, _playerState.IsAiming);
    }

    public void OnLook(InputValue value)
    {
        lookDelta = value.Get<Vector2>();
        _followTargetTransform.rotation *=
            Quaternion.AngleAxis(
                Mathf.Lerp(_previousMouseDelta.x, lookDelta.x, 1f / horizontalDamping) * cameraRotationSpeed,
                transform.up
            );
        
        transform.rotation = Quaternion.Euler(0, _followTargetTransform.transform.rotation.eulerAngles.y, 0);
        _followTargetTransform.localEulerAngles = new Vector3(DefaultCameraPitch, 0, 0);
        
        _previousMouseDelta = lookDelta;
    }
}
