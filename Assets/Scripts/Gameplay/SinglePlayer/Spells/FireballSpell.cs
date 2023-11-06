using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : MonoBehaviour
{
    public GameObject fireballExplosion;
    public float maxLifetime;

    float speed = 20f;
    bool moving;

    private void Awake()
    {
        moving = true;
    }

    void Update()
    {
        if(moving) transform.Translate(Vector2.right * Time.deltaTime * speed);
        StartCoroutine(destroyAfterTime());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.NameToLayer("Walls") == collision.gameObject.layer)
        {
            moving = false;
            GameObject fireballExplosionObject = Instantiate(fireballExplosion);
            fireballExplosionObject.transform.position = transform.position;
            Destroy(fireballExplosionObject, 1f);
            Destroy(gameObject);
        }
    }

    IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(maxLifetime);
        moving = false;
        GameObject fireballExplosionObject = Instantiate(fireballExplosion);
        fireballExplosionObject.transform.position = transform.position;
        Destroy(fireballExplosionObject, 1f);
        Destroy(gameObject);
    }
}
