using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveUpController : MonoBehaviour
{
    public float speed = 3f;

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
