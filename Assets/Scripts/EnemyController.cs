using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Vector3 = UnityEngine.Vector3;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent EnemyDeath;
    
    [Tooltip("WayPoints must be Nav Mesh reachable")]
    public WayPointRoute WayPointRoute;
    
    // Controller Editor Settings
    public float WaitTime = 3.0f; 
    public float ChaseSpeed = 7.5f; 
    public float DefaultSpeed = 5.0f; 
   
    // GO Components
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private EnemyState _enemyState;
    [SerializeField] private EnemySensor _enemySensor;
    
    // Animation Hashes
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    
    // Private Stuff
    private bool _isAlive = true;
    private bool _isRunning = false;
    private bool _destinationSet = false;
    private GameObject _currentDestination = null;
    private int _currentWayPointIndex = 0;
    

    private void Start()
    {
        // Grab Components 
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _enemyState = GetComponent<EnemyState>();
        _enemySensor = GetComponent<EnemySensor>();
        
        // Set First Destination 
        if (WayPointRoute) SetDestination(WayPointRoute.GetFirstPoint());
        
        //Default Values
        _agent.speed = DefaultSpeed;
    }

    private void Update()
    {
        // Basic AI Loop
        if (!_isAlive) _agent.isStopped = true;
        DetermineState();
        AnimateAgent();
    }

    private void AnimateAgent()
    {
        if (_agent.velocity.sqrMagnitude > 0)
        {
            _animator.SetBool(IsWalking, true);
            _enemyState.isMoving = true;
            _enemyState.isWaiting = false;
            if (_isRunning)
            {
                _animator.SetBool(IsRunning, true);
            }
            else
            {
                _animator.SetBool(IsRunning, false);
            }
        }
        else
        {
            _animator.SetBool(IsRunning, false);
            _animator.SetBool(IsWalking, false);
            _enemyState.isMoving = false;
            _enemyState.isWaiting = true;
        }
    }

    public void Death()
    {
        _isAlive = false;
        StartCoroutine(StartDeath());
        EnemyDeath.Invoke();
    }

    public void EnterChase()
    {
        _isRunning = true;
        _enemyState.isChasing = true;
        ClearDestination();
        SetDestination(_enemySensor.Player);
        _agent.speed = ChaseSpeed;
    }

    public void ExitChase()
    {
        _isRunning = false;
        _enemyState.isChasing = false;
        ClearDestination();
        SetDestination(WayPointRoute.GetWayPointAtIndex(_currentWayPointIndex));
        _agent.speed = DefaultSpeed;
    }

    public void WaitForNextPoint()
    {
        StartCoroutine(StartWaitingForNextPoint(WaitTime));
    }

    public void SetDestination(GameObject destination)
    {
        _currentDestination = destination;
        _destinationSet = true;
        _agent.SetDestination(_currentDestination.transform.position);
    }

    public void ClearDestination()
    {
        _currentDestination = null;
        _destinationSet = false;
    }

    public void NextWayPointIndex()
    {
        _currentWayPointIndex++;
        if (_currentWayPointIndex >= WayPointRoute.WayPoints.Length) _currentWayPointIndex = 0;
    }

    void DetermineState()
    {
        if (_enemyState.isTargetInLOS)
        {
            if (!_enemyState.isChasing)
            {
                EnterChase();
            }
        }
        else
        {
            if (_enemyState.isChasing)
            {
                ExitChase();
            }
        }
        
        if (_destinationSet)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (_enemyState.isChasing)
                {
                    // Trigger Alarm Ends Game
                    ClearDestination();
                    SetDestination(_enemySensor.Player);
                }
                else
                {
                    WaitForNextPoint();
                }
                
            }
        }
    }

    IEnumerator StartWaitingForNextPoint(float waitTime)
    {
        _animator.SetBool(IsWalking, false);
        _enemyState.isWaiting = true;
        ClearDestination();
        yield return new WaitForSeconds(waitTime);
        _enemyState.isWaiting = false;
        NextWayPointIndex();
        SetDestination(WayPointRoute.GetWayPointAtIndex(_currentWayPointIndex));
    }

    IEnumerator StartDeath()
    {
        _animator.SetTrigger("Death");
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
