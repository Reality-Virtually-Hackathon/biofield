using System.Collections;
using UnityEngine;
using SocketIO;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

public class SocketHost : MonoBehaviour {

	private SocketIOComponent socket;

	public void Start() {
        socket = GetComponent<SocketIOComponent>();
        socket.On("MOVE_BACTERIA", MoveBacteria);
	}
    public void MoveBacteria(SocketIOEvent evt)
    {
        Debug.Log("called");
    }

	public void SendBacteriaPos(Vector2 bacteriaPos, int bacteriaId)
    {
        Dictionary<string, string> enemyPosData = new Dictionary<string, string>();
        enemyPosData["posx"] = bacteriaPos.x.ToString();
        enemyPosData["posy"] = bacteriaPos.y.ToString();
        enemyPosData["id"] = bacteriaId.ToString();
        socket.Emit("BACTERIA_POS", new JSONObject(enemyPosData));
    }
	public void SendLymphocitePos(Vector2 lymphocitePos, int lymphociteId)
    {
        Dictionary<string, string> lymphocitePosData = new Dictionary<string, string>();
        lymphocitePosData["posx"] = lymphocitePos.x.ToString();
        lymphocitePosData["posy"] = lymphocitePos.y.ToString();
        lymphocitePosData["id"] = lymphociteId.ToString();
        socket.Emit("LYMPHOCITE_POS", new JSONObject(lymphocitePosData));
    }
	public void SendBacteriaFoodPos(Vector2 bacteriaFoodPos, int bacteriaFoodId)
    {
        Dictionary<string, string> bacteriaFoodPosData = new Dictionary<string, string>();
        bacteriaFoodPosData["posx"] = bacteriaFoodPos.x.ToString();
        bacteriaFoodPosData["posy"] = bacteriaFoodPos.y.ToString();
        bacteriaFoodPosData["id"] = bacteriaFoodId.ToString();
        socket.Emit("BACTERIAFOOD_POS", new JSONObject(bacteriaFoodPosData));
    }
	public void SendAntibodyPos(Vector2 AntiBodyPos, int AntiBodyId)
    {
        Dictionary<string, string> AntiBodyPosData = new Dictionary<string, string>();
        AntiBodyPosData["posx"] = AntiBodyPos.x.ToString();
        AntiBodyPosData["posy"] = AntiBodyPos.y.ToString();
        AntiBodyPosData["id"] = AntiBodyId.ToString();
        socket.Emit("ANTIBODY_POS", new JSONObject(AntiBodyPosData));
    }
}
