using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
public class LymphociteBehaviour : MonoBehaviour {

	public int lymphociteId;
    public float coolDown = .5f;
    private float timer = 0;
    private SocketHost socketHost;
	private SocketIOComponent socket;

	void Start()
	{
		socketHost = Game.instance.socketHost;
	}

	void Update () {
		EmitPosition();
	}

	void EmitPosition()
	{
		timer += Time.deltaTime;
        if(timer >= coolDown)
        {
            timer = 0;
            Vector2 lymphocitePos = new Vector2(this.transform.position.x * 10, this.transform.position.z * -10);
            socketHost.SendLymphocitePos(lymphocitePos, lymphociteId);
            //Debug.Log("Send pos: "+enemyPos.x.ToString() + " " + enemyPos.y.ToString());
        }
	}
}
