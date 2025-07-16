using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{

    [SerializeField]
    GameObject brickEffect;

    GameManager gameManager;

    [SerializeField]
    GameObject liveUpPrefab;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();   
    }

    // Nesne çarpışma ayarı
    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Ball")
        {
            Instantiate(brickEffect, transform.position, transform.rotation);

            gameManager.UpdateScore(5);

            int randomChaince = Random.Range(1, 101); // 1 - 100 arası değer döndürür.

            if(randomChaince > 70)
            {
                Instantiate(liveUpPrefab, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }
    }
}
