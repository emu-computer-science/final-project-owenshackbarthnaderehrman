using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private float angle, life;
    private Vector3 dir;

    public AudioSource pew;

    public void Awake()
    {
        angle = 2 * Mathf.Acos(transform.rotation.w);
        float up = 2 * Mathf.Asin(transform.rotation.z);
        angle = (up > 0) ? angle : -angle;
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
        if (collidedWith.tag == "Shooter" || collidedWith.tag == "Player" || collidedWith.tag == "Bullet" || collidedWith.tag == "Planet" || collidedWith.tag == "Finish")
        {
            Destroy(this.gameObject);
        }

    }
}
