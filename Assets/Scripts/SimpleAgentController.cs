using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAgentController : MonoBehaviour
{
    public float moveTime = 4.0f;
    public float waitTime = 1.0f;
    public float deviation = 0.5f;
    public float wanderZone = 8;

    private bool moving = false;
    private bool wandering = true;
    private float time = 0.0f;

    Vector3 randomPosition()
    {
	Vector3 direction = Random.insideUnitSphere * wanderZone;
	Vector3 newPos = transform.position + direction;
	NavMeshHit hit;
	NavMesh.SamplePosition(newPos, out hit, wanderZone, 1);
	return hit.position;
    }
    
    void Update()
    {
	if (Input.GetKeyUp("r"))
	{
	    wandering = !wandering;
	    time = 0.0f;
	}
	
        if (wandering)
	{
	    time -= Time.deltaTime;
	    if (time <= 0)
	    {
		if (moving)
		{
		    moving = false;
		    time = waitTime + Random.Range(-deviation, deviation);
		}
		else
		{
		    moving = true;
		    GetComponent<NavMeshAgent>().SetDestination(randomPosition());
		    time = moveTime + Random.Range(-deviation, deviation);
		}
	    }
	    
	}
    }
}
