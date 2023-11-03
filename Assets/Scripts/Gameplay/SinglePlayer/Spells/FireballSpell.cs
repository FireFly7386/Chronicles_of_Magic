using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : MonoBehaviour
{
    float speed = 20f;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
