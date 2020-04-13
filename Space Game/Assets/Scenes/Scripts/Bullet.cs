using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed, angle, life;
    private Vector3 dir;

    public AudioSource pew;

    public void findAngle(Vector3 from, Vector3 to)
    {
        transform.position = from;
        Vector3 direct = to - from;
        angle = Mathf.Atan2(direct.y, direct.x);
        dir = speed * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        life = 0;
        pew.Play();
    }
  
    void Update()
    {
        transform.position += dir * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(angle * 180.0f / 3.141592653f, new Vector3(0, 0, 1));
        life += Time.deltaTime;
        if (life >= 10f)
            Destroy(this.gameObject);
    }

    protected void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Shooter" || collidedWith.tag == "Player" || collidedWith.tag == "Bullet" || collidedWith.tag == "Planet")
        {
            Destroy(this.gameObject);
        }

    }
}
