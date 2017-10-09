using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class BacteriaBehaviour : MonoBehaviour {

	public int bacteriaId;
    public float coolDown = .5f;
    private float timer = 0;
    private SocketHost socketHost;
	private SocketIOComponent socket;
	private Rigidbody rb;

	void Start()
	{
		socketHost = Game.instance.socketHost;
		socket = socketHost.GetComponent<SocketIOComponent>();
		socket.On("MOVE_BACTERIA", MoveBacteria);
		rb = GetComponent<Rigidbody>();
	}

	void MoveBacteria(SocketIOEvent evt)
	{
		Debug.Log("called from node");
		switch(evt.data.ToString())
		{
			case "up":
			rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime);
			break;
			case "down":
			rb.MovePosition(transform.position + -Vector3.forward * Time.deltaTime);
			break;
			case "left":
			rb.MovePosition(transform.position + Vector3.left * Time.deltaTime);
			break;
			case "right":
			rb.MovePosition(transform.position + Vector3.right * Time.deltaTime);
			break;
		}
	}

	void Update () {
		EmitPosition();

		if(Input.GetKey(KeyCode.UpArrow))
		{
			rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * 10);
			Debug.Log("up");
		}
		if(Input.GetKey(KeyCode.LeftArrow))
			rb.MovePosition(transform.position + -Vector3.forward * Time.deltaTime * 10);
		if(Input.GetKey(KeyCode.RightArrow))
			rb.MovePosition(transform.position + Vector3.left * Time.deltaTime * 10);	
		if(Input.GetKey(KeyCode.DownArrow))
			rb.MovePosition(transform.position + Vector3.right * Time.deltaTime * 10);
	}

	void EmitPosition()
	{
		timer += Time.deltaTime;
        if(timer >= coolDown)
        {
            timer = 0;
            Vector2 bacteriaPos = new Vector2(this.transform.position.x * 10, this.transform.position.z * -10);
            socketHost.SendBacteriaPos(bacteriaPos, bacteriaId);
            //Debug.Log("Send pos: "+enemyPos.x.ToString() + " " + enemyPos.y.ToString());
        }
	}
}
