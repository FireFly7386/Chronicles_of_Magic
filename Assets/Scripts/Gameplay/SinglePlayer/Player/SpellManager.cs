using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    //Fireball
    [HideInInspector]
    public bool FireballIsOnCooldown;
    [HideInInspector]
    public float FireballCooldown;

    public float FireballManaCost;

    // Camera
    public Camera playerCam;

    // Spell Prefabs
    public GameObject FireballSpell;

    [HideInInspector]
    public int currentSpellID;

    private void Awake()
    {
        currentSpellID = 1;
        FireballIsOnCooldown = false;
    }

    void Update()
    {

        //Fireball
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!FireballIsOnCooldown && GetComponent<StatManager>().hasEnoughMana(FireballManaCost))
            {
                GetComponent<StatManager>().costMana(FireballManaCost);

                GameObject fireball = Instantiate(FireballSpell);
                fireball.transform.position = transform.position;

                Vector3 mousePosition = playerCam.ScreenToWorldPoint(Input.mousePosition);

                Vector2 direction = mousePosition - fireball.transform.position;
                float angle = Vector2.SignedAngle(Vector2.right, direction);
                fireball.transform.eulerAngles = new Vector3(0, 0, angle);
            }
        }
    }
}
