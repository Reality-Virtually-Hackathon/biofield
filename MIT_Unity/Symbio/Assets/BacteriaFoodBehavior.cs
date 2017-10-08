using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaFoodBehavior : MonoBehaviour {

	[SerializeField] private float foodSpeed = 1;

	Transform foodTransform;
	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.CompareTag("Bacteria"))
		{
			MoveTowards(col.transform);
		}
	}

	void MoveTowards(Transform t)
	{
		Vector3 direction = t.position - transform.position;
		rb.AddRelativeForce(direction.normalized * foodSpeed, ForceMode.Force);
	}

	void OnCollisionEnter(Collision col)
	{
		Debug.Log("Collided with bacteria");
		if(col.gameObject.CompareTag("Bacteria"))
		{
			Debug.Log("Collided with bacteria");
			Destroy(this.transform.gameObject);
			//spawn another after awhile
		}
	}
}
