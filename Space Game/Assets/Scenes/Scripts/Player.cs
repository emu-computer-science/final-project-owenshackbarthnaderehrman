using System.Collections;
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
	
	 string sceneName;
	 Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        GameObject scoreGO = GameObject.Find("Deaths");
        deathsGT = scoreGO.GetComponent<Text>();
        scoreGO = GameObject.Find("Distance");
        distanceGT = scoreGO.GetComponent<Text>();
        
        deaths = PlayerPrefs.GetInt("deaths");
        deathsGT.text = "Lives: " + deaths;
        cooldown = 0f;
		
		scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
		
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
        if (collidedWith.tag == "Finish"){
			if(sceneName.Equals("Level 1"))
				SceneManager.LoadScene("Level 2");
			if(sceneName.Equals("Level 2"))
				SceneManager.LoadScene("Level 3");
			if(sceneName.Equals("Level 3"))
				SceneManager.LoadScene("Winner");
            deathsGT.text = "WINNER";
		}
        if (collidedWith.tag == "Planet" || collidedWith.tag == "Bullet" || collidedWith.tag == "Shooter")
        {
            p = Vector2.zero;
            v = Vector2.zero;
            deaths--;
            deathsGT.text = "LIVES: " + deaths;
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
		if(deaths > 0){
			PlayerPrefs.SetInt("deaths", deaths);
			if(sceneName.Equals("Level 1"))
				SceneManager.LoadScene("Level 1");
			else if(sceneName.Equals("Level 2"))
				SceneManager.LoadScene("Level 2");
			else if(sceneName.Equals("Level 3"))
				SceneManager.LoadScene("Level 3");
		}
		else{
			PlayerPrefs.SetInt("deaths", 3);
			SceneManager.LoadScene("Level 1");
		}
		
    }
}
