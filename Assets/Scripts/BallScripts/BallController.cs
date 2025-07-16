using Packages.Rider.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    [SerializeField]
    float speed = 1000f;
    [SerializeField]
    bool inPlay;

    [SerializeField]
    Transform ballStartPos;

    GameManager gameManager;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        gameManager = Object.FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (gameManager.gameOver == true)
        {
            return;
        }
        if (!inPlay)
        {
            transform.position = ballStartPos.position;
        }

        if(Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rigidbody.AddForce(Vector2.up * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bottom")
        {
            rigidbody.velocity = Vector2.zero;

            gameManager.UpdateLives(-1); // Canı -1 azaltıyorum.

            inPlay = false;
        }
    }
}
