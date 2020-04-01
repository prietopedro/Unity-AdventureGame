using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public string username;
    public Animator animator;
    public Rigidbody2D rigidBody;
    public bool colliding;

    private void OnTriggerEnter2D(Collider2D other)
    {
        colliding = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        colliding = false;
    }
}
