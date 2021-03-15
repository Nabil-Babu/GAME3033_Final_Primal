using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject Player; 
    
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Rigidbody _rigidbody;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();

        if (Player == null) Player = FindObjectOfType<PlayerState>().gameObject;
    }

    private void Update()
    {
        _agent.SetDestination(Player.transform.position);
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
        StartCoroutine(StartDeath());
    }

    IEnumerator StartDeath()
    {
        _animator.SetTrigger("Death");
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
