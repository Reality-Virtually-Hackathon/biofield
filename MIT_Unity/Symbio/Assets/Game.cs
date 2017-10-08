using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public static Game instance;
	[HideInInspector] public List<GameObject> foodInScene = new List<GameObject>();
	[HideInInspector] public List<BacteriaBehaviour> bacteriaInScene = new List<BacteriaBehaviour>();
	[HideInInspector] public SocketHost socketHost;

	[Header("Spawnables")]
	[SerializeField] private GameObject bacteriaPrefab;
	[SerializeField] private GameObject neutroPrefab;

	SpawnBacteriaFood spawnBacteriaFood;
	int bacteriaId = 0;

	void Awake()
	{
		socketHost = GetComponent<SocketHost>();
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
		//host.Init();
		Debug.Log(foodInScene.Count);
	}

	public void SpawnBacteria (Vector3 location) 
	{
		GameObject bacteriaClone = Instantiate(bacteriaPrefab, location, Quaternion.identity);
		bacteriaInScene.Add(bacteriaClone.GetComponent<BacteriaBehaviour>());
		bacteriaClone.GetComponent<BacteriaBehaviour>().bacteriaId = bacteriaId;
		bacteriaId++;
	}
}
