using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BrakeController : MonoBehaviour
{
    private List<GameObject> collidedAgents = new List<GameObject>();
    private NavMeshAgent agent;

    void Start()
    {
	agent = GetComponentInParent<NavMeshAgent>();
    }
    
    void OnTriggerEnter(Collider other)
    {
	Debug.Log("enter");
	if (other.gameObject.GetComponent<NavMeshAgent>() != null)
	{
	    lock(collidedAgents)
	    {
		Debug.Log("agent enter" + collidedAgents.Count.ToString());
		if (collidedAgents.Count == 0)
		{
		    agent.isStopped = true;
		}
		collidedAgents.Add(other.gameObject);
	    }
	}
    }

    void OnTriggerExit(Collider other)
    {
	Debug.Log("exit");
	if (other.gameObject.GetComponent<NavMeshAgent>() != null)
	{
	    lock(collidedAgents)
	    {
		collidedAgents.Remove(other.gameObject);
		Debug.Log("agent exit" + collidedAgents.Count.ToString());
		if (collidedAgents.Count == 0)
		{
		    agent.isStopped = false;
		}
	    }
	}

    }
}
