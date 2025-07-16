using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    float speed = 20f; // Nesnenin hareket hızı.

    [SerializeField]
    float leftTarget, rightTarget;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if(gameManager.gameOver)
        {
            return;
        }

        // Hareket verildi.
        float h = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * h * speed * Time.deltaTime);

        // Sınırlandırma yapıldı.
        Vector2 temp = transform.position;
        temp.x = Mathf.Clamp(temp.x, leftTarget, rightTarget); // Minimum ve maksimum değerleri sınırlamak için kullandım.
        transform.position = temp;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "LiveUpBall")
        {
            gameManager.UpdateLives(1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "scoreUpBall")
        {
            gameManager.UpdateScore(20);
            Destroy(other.gameObject);
        }
    }

    
}
