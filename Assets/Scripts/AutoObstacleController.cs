using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoObstacleController : MonoBehaviour
{
    public float speed = 1f;
    public float wait = 1f;
    private int increment = -1;
    private Vector3[] waypoints;
    private int next = 0;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] transforms = GetComponentsInChildren<Transform>();
	waypoints = new Vector3[transforms.Length];
	for (int i = 0; i < transforms.Length; i++)
	{
	    waypoints[i] = transforms[i].position;
	}
    }

    // Update is called once per frame
    void Update()
    {
	if (timer > 0)
	{
	    timer -= Time.deltaTime;
	}
	else
	{
	    if (Vector3.Distance(waypoints[next], transform.position) < 0.01f)
	    {
		if (next == 0 || next == waypoints.Length - 1)
		{
		    increment *= -1;
		}
		timer = wait;
		next += increment;
	    }
	    else
	    {
		float total = waypoints[next].z - transform.position.z;
		transform.position += new Vector3(0, 0, Mathf.Sign(total) * Time.deltaTime * speed);
	    }
	}
    }
}
