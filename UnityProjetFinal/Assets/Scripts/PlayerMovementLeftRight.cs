using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLeftRight : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Change le personnage de gauche selon la gauche ou la droite
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.75f, 0.75f, 0.75f);

        anim.SetBool("run", horizontalInput != 0);
        
    }

}




