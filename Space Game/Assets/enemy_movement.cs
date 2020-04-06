using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D rb;
    public Vector3 dir;
    public GameObject target;
    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        // rb.isKinematic = true;
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
