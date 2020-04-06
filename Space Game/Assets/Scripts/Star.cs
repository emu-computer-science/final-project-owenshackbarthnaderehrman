using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
	[Header("Set in Inspector")]
	public GameObject starSphere;
	
	public Vector3 sphereOffsetScale = new Vector3(0,0);
	public Vector2 sphereScaleRangeX = new Vector2(1,1);
	public Vector2 sphereScaleRangeY = new Vector2(1,1);
	
	private List<GameObject> spheres;
	
	void Start(){
		spheres = new List<GameObject>();
		

		GameObject sp = Instantiate<GameObject>(starSphere);
		spheres.Add(sp);
		Transform spTrans = sp.transform;
		spTrans.SetParent(this.transform);
			
		Vector3 offset = Random.insideUnitSphere;
		offset.x *= sphereOffsetScale.x;
		offset.y *= sphereOffsetScale.y;
		spTrans.localPosition = offset;
			
		Vector3 scale = Vector3.one;
		scale.x = Random.Range(sphereScaleRangeX.x, sphereScaleRangeX.y);
		scale.y = scale.x;
		
		//scale.y = Random.Range(sphereScaleRangeY.x, sphereScaleRangeY.y);
		//scale.y *= 1 - (Mathf.Abs(offset.x) / sphereOffsetScale.x);
		//scale.y = Mathf.Max(scale.y, scaleYMin);
			
		spTrans.localScale = scale;
		
	}
	
	void Restart(){
		foreach(GameObject sp in spheres){
			Destroy(sp);
		}
		
		Start();
	}
	
	
}
