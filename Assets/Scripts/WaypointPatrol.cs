using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;


    int m_CurrentWaypointIndex;


    void Start()
    {
       navMeshAgent.SetDestination(waypoints[0].position);
        InvokeRepeating("ActivateParticles", 0, 1.5f);

    }

    void Update()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }


    }

    void ActivateParticles()
    {
        StartCoroutine(ActivateParticlesForDuration(0.5f));
    }

    IEnumerator ActivateParticlesForDuration(float duration)
    {
        var particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Play();
        yield return new WaitForSeconds(duration);
        particleSystem.Stop();
    }
}
