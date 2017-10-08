using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bacteriaFoodMesh : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		Debug.Log("Collided with bacteria");
		if(col.gameObject.CompareTag("Bacteria"))
		{
			Debug.Log("Collided with bacteria");
			Destroy(this.transform.parent.gameObject);
			//spawn another after awhile
		}
	}
}
