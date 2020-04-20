using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Ship
{

    public Text deathsGT;
    public Text distanceGT;
    public Text timeGT;

    public float maxSpeed;

    public GameObject bulletPrefab;
    private GameObject goal;

    private int lives;
    private float cooldown, time, bestTime;

    public AudioSource death;
	
	 string sceneName;
	 Scene scene;

    // Start is called before the first frame update
    new void Start()
    {
        if (time < 0)
            time = 0;
        if (lives <= 0)
            lives = 3;
        base.Start();
        GameObject scoreGO = GameObject.Find("Lives");
        deathsGT = scoreGO.GetComponent<Text>();
        scoreGO = GameObject.Find("Distance");
        distanceGT = scoreGO.GetComponent<Text>();
        scoreGO = GameObject.Find("Time");
        timeGT = scoreGO.GetComponent<Text>();

        time = PlayerPrefs.GetInt("time");
        lives = PlayerPrefs.GetInt("lives");
        bestTime = PlayerPrefs.GetInt("best");

        deathsGT.text = "LIVES: " + lives;
        cooldown = 0f;
		
		scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        goal = GameObject.Find("Goal");
    }

    // Update is called once per frame
    new void Update()
    {
        controls();
        if (v.magnitude > maxSpeed)
        {
            v.Normalize();
            v *= maxSpeed;
        }
        base.Update();
        distanceGT.text = "GOAL DIST: " + (int) (transform.position - goal.transform.position).magnitude;
        time += Time.deltaTime;
        timeGT.text = "TIME: " + (int) time;
    }

    new protected void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Finish"){
            PlayerPrefs.SetInt("time", (int)time);
            if (sceneName.Equals("Level 1"))
				SceneManager.LoadScene("Level 2");
			if(sceneName.Equals("Level 2"))
				SceneManager.LoadScene("Level 3");
			if(sceneName.Equals("Level 3"))
            {
                PlayerPrefs.SetInt("lives", 3);
                if ((int) time < PlayerPrefs.GetInt("best") || PlayerPrefs.GetInt("best") == 0)
                    PlayerPrefs.SetInt("best", (int)time);
                PlayerPrefs.SetInt("time", (int) time);
                SceneManager.LoadScene("Winner");
            }
				
            deathsGT.text = "CLEAR";
		}
        if (collidedWith.tag == "Planet" || collidedWith.tag == "Bullet" || collidedWith.tag == "Shooter")
        {
          p = Vector2.zero;
          v = Vector2.zero;
          lives--;
          deathsGT.text = "LIVES: " + lives;
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
            Vector3 dx = 2f * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            GameObject B = Instantiate<GameObject>(bulletPrefab, transform.position + dx, Quaternion.AngleAxis(angle * 180.0f / 3.141592653f, new Vector3(0, 0, 1)));
            cooldown = 0.125f;
        }
        a *= mag;
        Vector3 pos = Input.mousePosition;
        angle = Mathf.Atan2(pos.y - 0.5f * Screen.height, pos.x - 0.5f * Screen.width);
        cooldown -= Time.deltaTime;
    }


    private void resetLevel() {
		if(lives > 0){
            PlayerPrefs.SetInt("time", (int) time);
            PlayerPrefs.SetInt("lives", lives);
			if(sceneName.Equals("Level 1"))
				SceneManager.LoadScene("Level 1");
			else if(sceneName.Equals("Level 2"))
				SceneManager.LoadScene("Level 2");
			else if(sceneName.Equals("Level 3"))
				SceneManager.LoadScene("Level 3");
		}
		else{
			PlayerPrefs.SetInt("lives", 3);
            SceneManager.LoadScene("Game Over");
		}
		
    }
}
