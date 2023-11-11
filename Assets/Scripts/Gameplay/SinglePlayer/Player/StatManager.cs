using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StatManager : MonoBehaviour
{
    public GameObject DeathUI;

    public GameObject SpawnPoint;

    public GameObject PlayUI;

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

    public void damage(float dmg)
    {
        Health -= dmg;
        if (Health <= 0)
        {
            PlayUI.SetActive(false);
            GetComponent<Movement>().canMove = false;
            ManaMultiplier = 0f;
            Mana = 0f;
            StartCoroutine(die());
        }
    }

    public bool hasEnoughMana(float cost)
    {
        bool isEnough = Mana >= cost;
        return isEnough;
    }

    public void costMana(float cost)
    {
        Mana -= cost;
    }

    void Awake()
    {
        transform.position = SpawnPoint.transform.position;
    }

    void Update()
    {
        StartCoroutine(regenHealth());
        StartCoroutine(regenMana());

        healthSlider.maxValue = MaxHealth;
        healthSlider.minValue = 0;
        healthSlider.value = Mathf.Clamp(Health, 0, MaxHealth);
        healthText.text = "Health: " + Mathf.Clamp(Mathf.RoundToInt(Health), 0, MaxHealth).ToString();
        
        manaSlider.maxValue = MaxMana;
        manaSlider.minValue = 0;
        manaSlider.value = Mana;
        manaText.text = "Mana: " + Mathf.RoundToInt(Mana).ToString();
    }

    IEnumerator die()
    {
        GameObject deahtUI = Instantiate(DeathUI);
        deahtUI.GetComponent<CanvasGroup>().alpha = 0;
        for(int i = 0; i <= 100; i++)
        {
            deahtUI.GetComponent<CanvasGroup>().alpha = Mathf.Clamp(deahtUI.GetComponent<CanvasGroup>().alpha + 0.01f, 0, 1); 
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene(1);
    }

    IEnumerator regenHealth()
    {
        Health += HealthMultiplier * Time.deltaTime;
        Health = Mathf.Clamp(Health, -1000, MaxHealth);
        yield return null;
    }
    IEnumerator regenMana()
    {
        Mana += ManaMultiplier * Time.deltaTime;
        Mana = Mathf.Clamp(Mana, 0, MaxMana);
        yield return null;
    }
    
}
