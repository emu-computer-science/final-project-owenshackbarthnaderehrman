﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Ship
{

    public Text deathsGT;
    public Text distanceGT;

    public GameObject bulletPrefab;

    private int deaths;
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        GameObject scoreGO = GameObject.Find("Deaths");
        deathsGT = scoreGO.GetComponent<Text>();
        scoreGO = GameObject.Find("Distance");
        distanceGT = scoreGO.GetComponent<Text>();
        
        deaths = PlayerPrefs.GetInt("deaths");
        deathsGT.text = "DEATHS: " + deaths;
        cooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        
        controls();
        base.Update();
        GameObject goal = GameObject.Find("Goal");
        distanceGT.text = "DISTANCE: " + (transform.position - goal.transform.position).magnitude;
    }

    protected void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Finish")
            deathsGT.text = "WINNER";
        if (collidedWith.tag == "Planet" || collidedWith.tag == "Bullet" || collidedWith.tag == "Shooter")
        {
            p = Vector2.zero;
            v = Vector2.zero;
            deaths++;
            deathsGT.text = "DEATHS: " + deaths;
            Destroy(this.gameObject);
            resetLevel();
        }
    }

    public void controls()
    {
        a = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
            ++a.y;
        if (Input.GetKey(KeyCode.A))
            --a.x;
        if (Input.GetKey(KeyCode.S))
            --a.y;
        if (Input.GetKey(KeyCode.D))
            ++a.x;
        if (Input.GetMouseButtonDown(0) && cooldown < 0)
        {
            GameObject B = Instantiate<GameObject>(bulletPrefab);
            Bullet b = B.GetComponent<Bullet>();
            Vector3 dx = 2f * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            b.findAngle(transform.position + dx, transform.position + 2 * dx);
            cooldown = 0.5f;
        }
        a *= mag;
        Vector3 pos = Input.mousePosition;
        angle = Mathf.Atan2(pos.y - 0.5f * Screen.height, pos.x - 0.5f * Screen.width);
        cooldown -= Time.deltaTime;
    }


    private void resetLevel() {
        PlayerPrefs.SetInt("deaths", deaths);
        SceneManager.LoadScene("Level 1");
    }
}