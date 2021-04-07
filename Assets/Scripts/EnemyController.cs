using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Vector3 = UnityEngine.Vector3;

public class EnemyController : MonoBehaviour
{
    
    public GameObject Player;
    public UnityEvent EnemyDeath;
    public WayPointRoute WayPointRoute;

    public float WaitTime = 3.0f; 
    // GO Components
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private EnemyState _enemyState;
    
    // Animation Hashes
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private bool _isAlive = true;
    private bool _destinationSet = false;
    private GameObject _currentDestination = null;
    private int _currentWayPointIndex = 0; 
    
    private void Start()
    {
        // Grab Components 
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _enemyState = GetComponent<EnemyState>();
        
        // Set First Destination 
        if(WayPointRoute) SetDestination(WayPointRoute.GetFirstPoint());
    }

    private void Update()
    {
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
        }
        else
        {
            _animator.SetBool(IsWalking, false);
            _enemyState.isMoving = false;
        }
    }

    public void Death()
    {
        _isAlive = false;
        StartCoroutine(StartDeath());
        EnemyDeath.Invoke();
    }

    public void Wait()
    {
        StartCoroutine(StartWaiting(WaitTime));
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
        if (_destinationSet)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                Wait();
            }
        }
    }

    IEnumerator StartWaiting(float waitTime)
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
