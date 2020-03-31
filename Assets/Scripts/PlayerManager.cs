using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public string username;
    public Animator animator;
    public Rigidbody2D my_rigidbody;
    void Start()
    {
        animator = GetComponent<Animator>();
        my_rigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }
}
