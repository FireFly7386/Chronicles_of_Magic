using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 20;
    public float dmg = 5;
    public float dmgCooldown = 0.3f;
    public GameObject player;

    bool canAttack = true;

    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) < 2)
        {
            if (canAttack) {
                attack();
            }
        }
    }

    public void damage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void attack()
    {
        player.GetComponent<StatManager>().damage(dmg);
        canAttack = false;
        StartCoroutine(dmgCooldownReset());
    }

    IEnumerator dmgCooldownReset()
    {
        yield return new WaitForSeconds(dmgCooldown);
        canAttack = true;
    }
}
