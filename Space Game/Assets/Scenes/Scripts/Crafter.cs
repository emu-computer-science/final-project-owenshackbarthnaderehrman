using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : MonoBehaviour
{
    [Header("Set in Inspector")]
	public int numStars;
	
	public GameObject starPrefab;
	public Vector3 starPosMin = new Vector3(-50,-5);
	public Vector3 starPosMax = new Vector3(150,100);
	public float starScaleMin = 1;
	public float starScaleMax = 3;
	
	private GameObject[] starInstances;
	
	void Awake(){
		starInstances = new GameObject[numStars];
		GameObject anchor = GameObject.Find("StarAnchor");
		GameObject star;
		for(int i=0; i<numStars; i++){
			star = Instantiate<GameObject>(starPrefab);
			
			Vector3 cPos = Vector3.zero;
			cPos.x = Random.Range(starPosMin.x, starPosMax.x);
			cPos.y = Random.Range(starPosMin.y, starPosMax.y);
            cPos.z = 10;
			
			float scaleU = Random.value;
			float scaleVal = Mathf.Lerp(starScaleMin, starScaleMax, scaleU);
			
			cPos.y = Mathf.Lerp(starPosMin.y, cPos.y, scaleU);
			
			star.transform.position = cPos;
			star.transform.localScale = Vector3.one * scaleVal;
			
			star.transform.SetParent(anchor.transform);
			
			starInstances[i] = star;
		}

	}
}
