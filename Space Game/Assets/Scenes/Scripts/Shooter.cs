using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Ship
{
    private float time = 0;

    public GameObject bulletPrefab;

    public AudioSource death;

    private GameObject target;
    void Start()
    {
        base.Start();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0.0f, 1.0f) < (Time.deltaTime / 5.0f) && target != null)
        {
            GameObject B = Instantiate<GameObject>(bulletPrefab);
            Bullet b = B.GetComponent<Bullet>();
            Vector3 from = transform.position + 2f * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            b.findAngle(from, target.transform.position);
        }

        //Look at target
        if (target != null)
        {
            Vector3 direct = target.transform.position - transform.position;
            angle = Mathf.Atan2(direct.y, direct.x);
            v = mag * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            base.Update();
        }
    }

    protected void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Player" || collidedWith.tag == "Bullet")
        {
            death.Play();
            Destroy(this.gameObject);
        }
    }
}
