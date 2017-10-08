using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public static Game instance;

	public List<GameObject> foodInScene = new List<GameObject>();

	SpawnBacteriaFood spawnBacteriaFood;

	void Awake()
	{
		spawnBacteriaFood = GetComponent<SpawnBacteriaFood>();
		//Check if instance already exists
		if (instance == null)
			
			//if not, set instance to this
			instance = this;
		
		//If instance already exists and it's not this:
		else if (instance != this)
			
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    
		
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
		
		//Call the InitGame function to initialize the first level 
		InitGame();
	}
	
	//Initializes the game for each level.
	void InitGame()
	{
		foodInScene = spawnBacteriaFood.SpawnFood();
		Debug.Log(foodInScene.Count);
	}
}
