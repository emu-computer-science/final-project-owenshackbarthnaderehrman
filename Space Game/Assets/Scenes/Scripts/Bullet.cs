using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 p, v;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p += v * Time.deltaTime;
        transform.position = p;
        transform.rotation = Quaternion.AngleAxis(angle * 180.0f / 3.141592653f, new Vector3(0, 0, 1));
    }
}
