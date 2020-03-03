using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent agent;
    public GameObject player;
    public Image deathImage;


    [SerializeField]
    private float range;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < range)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject == player)
        {
            deathImage.GetComponent<Animator>().Play("Death");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
