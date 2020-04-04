using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Racer : MonoBehaviour
{
    public AudioSource coin;
    public Text cumulativeText;
    public Slider healthBar;
    public AudioSource attack;
    public AudioSource goalSound;
    public AudioSource gruntSound;
    public Image fillBar;
    public GameObject endScreen;
    public Text endText;
    public GameObject spider;

    private bool died;
    private int currentReward = 0;
    private float health = 0.01f;
    private string gameOver = "You couldn't survive this. Better luck next time!";
    private bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        died = false;
        cumulativeText.text = "Score: " + currentReward;
        healthBar.value = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        cumulativeText.text = "Score: " + currentReward;
        healthBar.value = health;
        if (healthBar.value <= 0)
        {
            died = true;
            EndGame();
        }
        if (healthBar.value <= 0.3f)
        {
            fillBar.color = Color.red;
        }
        else
        {
            fillBar.color = Color.green;
        }
        if (end)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                #if UNITY_EDITOR
                                // Application.Quit() does not work in the editor so
                                // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                                UnityEditor.EditorApplication.isPlaying = false;
                #else
                                Application.Quit();
                #endif
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            currentReward += 1;
            if (health < 1)
            {
                health += 0.01f;
            }
            coin.Play();
            Destroy(other.gameObject);            
        }

        else if (other.gameObject.CompareTag("goal"))
        {
            currentReward += 10;
            if (health < 1)
            {
                health += 0.05f;
            }
            goalSound.Play();
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("blueGoal"))
        {
            currentReward += 20;
            if (health < 1)
            {
                health += 0.1f;
            }
            goalSound.Play();
            Destroy(other.gameObject);
        }
        
        else if (other.gameObject.CompareTag("spider"))
        {
            died = true;
            EndGame();
        }

        else if (other.gameObject.CompareTag("monster"))
        {
            currentReward -= 10;
            health -= 0.08f;
            gruntSound.Play();
        }

        else if (other.gameObject.CompareTag("light"))
        {
            currentReward -= 20;
            health -= 0.15f;
            gruntSound.Play();
        }

        else if (other.gameObject.CompareTag("endRace"))
        {
            goalSound.Play();
            EndGame();
        }


    }

    public void EndGame()
    {

        endScreen.SetActive(true);
        spider.SetActive(false);
        if (died)
        {
            endText.text = gameOver;
        }
        else
        {
            endText.text = "Max Score: " + currentReward;
        }
        endText.gameObject.SetActive(true);
        end = true;
    }
}
