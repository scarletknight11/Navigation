using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualWall : MonoBehaviour
{
    public float max = 4f;
    public float min = 4f;
    public float speed = 1f;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
	{
	    var newPos = transform.position + new Vector3(speed * Time.deltaTime, 0f, 0f);
	    if (newPos.x < startPos.x + max)
	    {
		transform.position = newPos;
	    }
	}
	else if (Input.GetKey("left"))
	{
	    var newPos = transform.position - new Vector3(speed * Time.deltaTime, 0f, 0f);
	    if (newPos.x > startPos.x - min)
	    {
		transform.position = newPos;
	    }
	}
    }
}
