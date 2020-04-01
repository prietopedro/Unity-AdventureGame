using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();
    public GameObject playerPrefab;
    public GameObject localPlayerPrefab;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object");
            Destroy(this);
        }
    }

    public void SpawnPlayer(int _id, string _username, Vector3 _position)
    {
        GameObject _player;
        if (_id != Client.instance.myId)
        {
            _player = Instantiate(playerPrefab, _position, Quaternion.identity);
        }
        else
        {
            _player = Instantiate(localPlayerPrefab, _position, Quaternion.identity);
            Camera.main.GetComponent<CameraMovement>().target = _player.GetComponent<PlayerManager>().transform;
        }
        

        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        _player.GetComponent<PlayerManager>().animator = _player.GetComponent<Animator>();
        _player.GetComponent<PlayerManager>().rigidBody = _player.GetComponent<Rigidbody2D>();
        _player.GetComponent<PlayerManager>().colliding = false;
        players.Add(_id, _player.GetComponent<PlayerManager>());
    }
}
