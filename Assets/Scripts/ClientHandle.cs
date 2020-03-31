using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;


public class ClientHandle : MonoBehaviour
{
    // Start is called before the first frame update
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();

        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuanternion();

        Debug.Log("Player spawning");
        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _change = _packet.ReadVector3();
        Vector3 _position = _packet.ReadVector3();

        Debug.Log(_change.x);
        GameManager.players[_id].animator.SetBool("moving", true);
        GameManager.players[_id].animator.SetFloat("moveX", _change.x);
        GameManager.players[_id].animator.SetFloat("moveY", _change.y);
        GameManager.players[_id].transform.position = _position;

    }
}
