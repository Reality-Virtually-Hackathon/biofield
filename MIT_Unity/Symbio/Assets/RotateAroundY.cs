using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundY : MonoBehaviour {

	[Range(10f, 50f)] [SerializeField] private float speed = 10f;

	void Update () 
	{
		transform.RotateAround(transform.position, transform.up, Time.deltaTime * speed);	
	}
}
