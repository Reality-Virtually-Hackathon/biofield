using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibodyBehaviour : MonoBehaviour {

	public static int antibodyId;
    public float coolDown = .5f;
    private float timer = 0;
    private SocketHost socketHost;
	
	void Start()
	{
		antibodyId++;
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
            Vector2 antibodyPos = new Vector2(this.transform.position.x * 10, this.transform.position.z * -10);
            socketHost.SendAntibodyPos(antibodyPos, antibodyId);
            //Debug.Log("Send pos: "+enemyPos.x.ToString() + " " + enemyPos.y.ToString());
        }
	}
}
