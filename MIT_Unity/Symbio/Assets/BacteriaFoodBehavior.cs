using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaFoodBehavior : MonoBehaviour {

	Transform foodTransform;

	void Start () {
		foodTransform = GetComponentInChildren<RotateAroundY>().transform;
	}

	void OnTrigger(Collider col)
	{
		if(col.gameObject.CompareTag("Bacteria"))
		{
			Debug.Log("triggered bacteria");
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.CompareTag("Bacteria"))
		{
			Debug.Log("Collided with bacteria");
			Destroy(this);
			//spawn another after awhile
		}
	}
}
