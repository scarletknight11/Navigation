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
    public float minWander = 4;

    private bool moving = false;
    private bool wandering = false;
    private float time = 0.0f;

    Vector3 randomPosition()
    {
	int tries = 4;
	NavMeshHit hit;
	Vector3 direction;
	Vector3 newPos;
	do
	{
	    direction = Random.insideUnitSphere * Random.Range(minWander, wanderZone);
	    newPos = transform.position + direction;
	    NavMesh.SamplePosition(newPos, out hit, wanderZone, 1);
	    tries--;
	} while (Vector3.Distance(transform.position, hit.position) < minWander
		 && tries > 0);
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
