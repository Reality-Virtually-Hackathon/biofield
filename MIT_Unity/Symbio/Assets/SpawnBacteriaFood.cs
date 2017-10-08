using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBacteriaFood : MonoBehaviour {
	[SerializeField] private GameObject bacteriaFoodPrefab;

	[SerializeField] private int amountOfFood = 100;
	[SerializeField] private float spacing = 1;
	[SerializeField] private float ySpacing = 4;
	void Start () 
	{
		SpawnFood();
	}
	
	void SpawnFood()
	{
		for(int x = 0; x < Mathf.Sqrt(amountOfFood); x++)
		{
			for(int z = 0; z < Mathf.Sqrt(amountOfFood); z++)
			{
				GameObject foodClone = GameObject.Instantiate(bacteriaFoodPrefab, new Vector3((x - Mathf.Sqrt(amountOfFood) / 2 )* spacing, Random.Range(-ySpacing, ySpacing), (z - Mathf.Sqrt(amountOfFood) / 2 )* spacing), Quaternion.identity);
				RotateAroundY food = foodClone.GetComponentInChildren<RotateAroundY>();
				food.transform.rotation = Random.rotation;
			}
		}
	}

	void Update () {
		
	}
}
