using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    
    public GameObject followTarget;
    public GameObject StandardCamera;
    public GameObject AimCamera;

    public GameObject CrossHair; 
    
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
    private Vector3 HitLocation;
    
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
            CrossHair.SetActive(true);
        }
        else
        {
            _playerState.IsAiming = false; 
            _isRMBPresssed = false;
            StandardCamera.SetActive(true);
            AimCamera.SetActive(false);
            CrossHair.SetActive(false);
            _followTargetTransform.localEulerAngles = new Vector3(DefaultCameraPitch, 0, 0);
        }
        _playerAnimator.SetBool(IsAiming, _playerState.IsAiming);
    }

    public void OnLook(InputValue value)
    {
        HitLocation = Vector3.zero;
        lookDelta = value.Get<Vector2>();
        
        if (_isRMBPresssed)
        {
            transform.rotation *=
                Quaternion.AngleAxis(
                    Mathf.Lerp(_previousMouseDelta.x, lookDelta.x, 1f / horizontalDamping) * cameraRotationSpeed,
                    transform.up
                );
            
            
            _followTargetTransform.rotation *=
                Quaternion.AngleAxis(
                    Mathf.Lerp(_previousMouseDelta.y, lookDelta.y, 1f / verticalDamping) * cameraRotationSpeed,
                    transform.right
                );

            var followtargetRotation = _followTargetTransform.rotation.eulerAngles;
            followtargetRotation.z = 0;
            _followTargetTransform.eulerAngles= followtargetRotation;
            
            Ray screenRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
            Debug.DrawRay(screenRay.origin, screenRay.direction*100, Color.green);

            if (!Physics.Raycast(screenRay, out RaycastHit hitInfo, 100.0f)) return;
            HitLocation = hitInfo.point;
            
        }
        else
        {
            _followTargetTransform.rotation *=
                Quaternion.AngleAxis(
                    Mathf.Lerp(_previousMouseDelta.x, lookDelta.x, 1f / horizontalDamping) * cameraRotationSpeed,
                    transform.up
                );
            
            
            transform.rotation = Quaternion.Euler(0, _followTargetTransform.transform.rotation.eulerAngles.y, 0);
            _followTargetTransform.localEulerAngles = new Vector3(DefaultCameraPitch, 0, 0);
        }
        
        _previousMouseDelta = lookDelta;
    }
    
    private void OnDrawGizmos()
    {
        if (HitLocation == Vector3.zero) return;
        if (!_playerState.IsAiming) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(HitLocation, 0.2f);
    }
}
