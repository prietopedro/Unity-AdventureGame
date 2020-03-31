using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void FixedUpdate()
    {
        SendInputToServer();
    }

    // Update is called once per frame
    private void SendInputToServer()
    {
        float[] _inputs = new float[]
        {
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        };
        ClientSend.PlayerMovement(_inputs);
    }
}
