using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAntibody : MonoBehaviour {

	[SerializeField] private GameObject antibodyPrefab;
	[SerializeField] private GameObject rhand;
	[SerializeField] private GameObject lhand;
	[SerializeField] private float force = 100;

	// Update is called once per frame
	void Update () {
		if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0))
		{
			if(antibodyPrefab != null)
			{
				GameObject spawnedAntibody = GameObject.Instantiate(antibodyPrefab, lhand.transform.position, Quaternion.identity);
				Rigidbody rb = spawnedAntibody.GetComponent<Rigidbody>();
				rb.isKinematic = false;
				rb.AddForce(spawnedAntibody.transform.forward * force);
			}	
		}
		if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetMouseButtonDown(1))
		{
			if(antibodyPrefab != null)
			{
				GameObject spawnedAntibody = GameObject.Instantiate(antibodyPrefab, rhand.transform.position, Quaternion.identity);
				Rigidbody rb = spawnedAntibody.GetComponent<Rigidbody>();
				rb.isKinematic = false;
				rb.AddForce(spawnedAntibody.transform.forward * force);
			}	
		}
	}
}
