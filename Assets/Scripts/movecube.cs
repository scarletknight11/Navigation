using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movecube : MonoBehaviour {

    public float Speed;


    // Start is called before the first frame update
    void Start()
    {
        Speed = 1f;
    }

    // Update is called once per frame
    void Update() {
        Destination();
        if (Input.GetMouseButtonDown(0))
        {
            transform.position += Vector3.back * Time.deltaTime;
        }

    }

    private void Destination()
    {
        transform.Translate(Input.GetAxis("Horizontal")* Time.deltaTime, 0f, Input.GetAxis("Vertical")*Time.deltaTime);
    }
}
