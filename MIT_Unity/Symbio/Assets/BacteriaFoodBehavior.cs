using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaFoodBehavior : MonoBehaviour {
	public static int bacteriaFoodId = 0;
    public float coolDown = .5f;
    private float timer = 0;
    private SocketHost socketHost;
	[SerializeField] private float foodSpeed = 1;
	Transform foodTransform;
	Rigidbody rb;

	Vector3 lastPos;

	void Start () {
		bacteriaFoodId++;
		rb = GetComponent<Rigidbody>();
		socketHost = Game.instance.socketHost;
	}

	void Update()
	{
		EmitPosition();
	}

	void EmitPosition()
	{
		timer += Time.deltaTime;
        if(timer >= coolDown)
        {
            timer = 0;
            Vector2 bacteriaFoodPos = new Vector2(this.transform.position.x * 10, this.transform.position.z * -10);
            socketHost.SendBacteriaFoodPos(bacteriaFoodPos, bacteriaFoodId);
            //Debug.Log("Send pos: "+enemyPos.x.ToString() + " " + enemyPos.y.ToString());
        }
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
		if(col.gameObject.CompareTag("Bacteria"))
		{
			Destroy(this.transform.gameObject);
			//spawn another after awhile
		}
	}
}
