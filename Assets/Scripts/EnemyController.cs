using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;
    public UnityEvent EnemyDeath;
    
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Rigidbody _rigidbody;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private bool isAlive = true; 
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();

        if (Player == null) Player = FindObjectOfType<PlayerState>().gameObject;
    }

    private void Update()
    {
        if (isAlive)
        {
            _agent.SetDestination(Player.transform.position);
        }
        else
        {
            _agent.isStopped = true;
        }
        
        AnimateAgent();
    }

    private void AnimateAgent()
    {
        if (_agent.velocity.sqrMagnitude > 0)
        {
            _animator.SetBool(IsWalking, true);
        }
        else
        {
            _animator.SetBool(IsWalking, false);
        }
    }

    public void Death()
    {
        isAlive = false;
        StartCoroutine(StartDeath());
        EnemyDeath.Invoke();
    }

    IEnumerator StartDeath()
    {
        _animator.SetTrigger("Death");
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
