using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Ship
{
    public float reps = 1;
    private float time = 0;

    public GameObject bulletPrefab;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            /*
            GameObject bullet = Instantiate<Bullet>(bulletPrefab);
            Vector3 cPos = Vector3.zero;
            GameObject player = GameObject.Find("Player");

            Vector3 pp = player.transform.position, ps = transform.position;

            float angle = Mathf.Atan2(pp.y - ps.y, pp.x - ps.x);
            Vector2 pos = new Vector2(ps.x, ps.y) + new Vector2(Mathf.Cos(angle) * 1.5f, Mathf.Sin(angle) * 1.5f);
            bullet.p = pos;
            bullet.v = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            */
        }
    }
}
