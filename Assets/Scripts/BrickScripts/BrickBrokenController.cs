using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBrokenController : MonoBehaviour
{
    [SerializeField]
    private Sprite brokenImage;
    
    [SerializeField]
    GameObject brickBrokenEffect;

    [SerializeField]
    GameObject scoreUpPrefab;

    int count = 0;

    private void Start()
    {
        count = 0;
    }

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Ball")
        {
            count++;

            if (count == 1)
            {
                GetComponent<SpriteRenderer>().sprite = brokenImage;

                gameManager.UpdateScore(5);
            }
            else if (count == 2)
            {
                Instantiate(brickBrokenEffect, transform.position, transform.rotation);
                gameManager.UpdateScore(10);

                int randomChaince = Random.Range(1, 101);

                if (randomChaince > 70)
                {
                    Instantiate(scoreUpPrefab, transform.position, transform.rotation);
                }

                Destroy(gameObject);
            }
        }
        
    }
}
