using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnding : MonoBehaviour
{
    public GameObject playUI;
    public GameObject GG_UI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<Movement>().canMove = false;
            playUI.SetActive(false);
            StartCoroutine(win());
        }
    }

    IEnumerator win()
    {
        GameObject deahtUI = Instantiate(GG_UI);
        deahtUI.GetComponent<CanvasGroup>().alpha = 0;
        for (int i = 0; i <= 100; i++)
        {
            deahtUI.GetComponent<CanvasGroup>().alpha = Mathf.Clamp(deahtUI.GetComponent<CanvasGroup>().alpha + 0.01f, 0, 1);
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene(1);
    }
}
