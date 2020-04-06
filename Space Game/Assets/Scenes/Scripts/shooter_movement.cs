using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter_movement : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody rb;
    public Vector3 dir;
    private GameObject target;
    void Start() {
        rb = this.GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
    }   

    void Update() {
        // Vector3 dir = (targetObj.transform.position - transform.position).normalized;
    }

    void FixedUpdate() {
        moveEnemy();
    } 

    void moveEnemy() {
        float step =  speed * Time.deltaTime;
        
        //Look at target
        transform.up = target.transform.position - transform.position;
        //Move to target
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

}

