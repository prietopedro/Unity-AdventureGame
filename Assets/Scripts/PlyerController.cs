using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerController : MonoBehaviour
{
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        SendInputToServer();
    }

    // Update is called once per frame
    private void SendInputToServer()
    {
        Vector3 change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        bool attack = Input.GetButtonDown("attack");

        ClientSend.PlayerMovement(change,attack);
    }
}
