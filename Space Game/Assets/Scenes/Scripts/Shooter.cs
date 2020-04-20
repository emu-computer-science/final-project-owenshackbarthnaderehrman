using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Ship
{
    public GameObject bulletPrefab;

    public float distance;

    public AudioSource death;

    private GameObject player;
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        player = GameObject.Find("Player");
        if (player == null)
            return;
        Vector3 diff = player.transform.position - transform.position;
        if (diff.magnitude <= distance)
        {
            if (Random.Range(0.0f, 1.0f) < (Time.deltaTime / 1.0f))
            {
                Vector3 dx = 2f * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                GameObject B = Instantiate<GameObject>(bulletPrefab, transform.position + dx, Quaternion.AngleAxis(angle * 180 / 3.141592653f, new Vector3(0, 0, 1)));
            }

            Vector3 direct = player.transform.position - transform.position;
            angle = Mathf.Atan2(direct.y, direct.x);
            v = mag * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            base.Update();
        }
        
    }

    new protected void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Player" || collidedWith.tag == "Bullet")
        {
            death.Play();
            Destroy(this.gameObject);
        }
    }
}
