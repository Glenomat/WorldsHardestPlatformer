using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    private BoxCollider2D boxCollider;
    private PlayerMovement_2D playerMvmt;
    public ParticleSystem particalSys;
    public BoxCollider2D deathCollider;

    public ScoreScreen scoreScreen;

    public static int deaths = 0;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenue")
            deaths = 0;
        spriteRender = GetComponent<SpriteRenderer>();
        playerMvmt = GetComponent<PlayerMovement_2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        scoreScreen.deathTxt.text = "Deaths: " + deaths;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            deaths++;
            scoreScreen.deathTxt.text = "Deaths: " + deaths;

            spriteRender.enabled = false;
            playerMvmt.enabled = false;
            boxCollider.enabled = false;
            deathCollider.enabled = false;
            particalSys.Play();
            StartCoroutine(Countdown());
        }
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StopCoroutine(Countdown());
    }
}
