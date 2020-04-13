using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    protected float angle;
    protected Vector2 a, v, p;

    public float mag;

    // Start is called before the first frame update
    protected void Start()
    {
        a = new Vector2(0, 0);
        v = new Vector2(0, 0);
        p = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    protected void Update()
    {
        v += a * Time.deltaTime;
        p += v * Time.deltaTime;

        Vector3 pos = transform.position;
        pos.x = p.x;
        pos.y = p.y;
        transform.position = pos;
        transform.rotation = Quaternion.AngleAxis(angle * 180.0f / 3.141592653f, new Vector3(0, 0, 1));
    }

    protected void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Planet" || collidedWith.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }

    }
}

