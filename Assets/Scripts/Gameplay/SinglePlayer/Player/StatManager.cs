using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public int MaxHealth;
    public float HealthMultiplier;
    public float Health;

    public int MaxMana;
    public float ManaMultiplier;
    public float Mana;

    void Update()
    {
        StartCoroutine(regenHealth());
        StartCoroutine(regenMana());
    }

    IEnumerator regenHealth()
    {
        Health += HealthMultiplier * Time.deltaTime;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        yield return null;
    }
    IEnumerator regenMana()
    {
        Mana += ManaMultiplier * Time.deltaTime;
        Mana = Mathf.Clamp(Mana, 0, MaxMana);
        yield return null;
    }
    
}
