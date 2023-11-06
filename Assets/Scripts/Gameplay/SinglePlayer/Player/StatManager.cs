using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatManager : MonoBehaviour
{
    public TMP_Text healthText;
    public Slider healthSlider;
    
    public TMP_Text manaText;
    public Slider manaSlider;

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

        healthSlider.maxValue = MaxHealth;
        healthSlider.minValue = 0;
        healthSlider.value = Health;
        healthText.text = "Health: " + Mathf.RoundToInt(Health).ToString();
        
        manaSlider.maxValue = MaxMana;
        manaSlider.minValue = 0;
        manaSlider.value = Mana;
        manaText.text = "Mana: " + Mathf.RoundToInt(Mana).ToString();
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
