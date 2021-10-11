using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript : MonoBehaviour
{
    //for speed
    public float speed;

    //score
    public int scoreCount;
    public int totalScore;
    public Text scoreText;

    //time
    public Text timerText;
    public float elapsedGameTime;

    //audio
    private AudioSource audioSource;
    public AudioClip collectSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {

        // call the time function
        elapsedGameTime -= Time.deltaTime;
        SetTimeText(elapsedGameTime);

        float horizontalInput = Input.GetAxis("Horizontal");

      transform.position = 
            transform.position + new Vector3
            (horizontalInput * speed * Time.deltaTime, 0, 0);

        
       

    }

    public void SetTimeText(float time)
    {
        timerText.text = "Time Left: " + FormatTime(time);
    }

    private string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = System.String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        return timeText;
    }

    public void OnCollisionEnter(Collision collision)
    {
        //collision with healthy food
        if (collision.gameObject.tag.Equals("Healthy"))
        {

            Destroy(collision.gameObject);
            audioSource.PlayOneShot(collectSound);
            scoreCount += 10;
            scoreText.text = "Score: " + scoreCount.ToString();

            if (scoreCount == totalScore)
            {

                SceneManager.LoadScene("WinScene");
            }

        }

        //collision with unhealthy food
        if (collision.gameObject.tag == "Unhealthy")
        {
            
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(collectSound);
            SceneManager.LoadScene("LoseScene");

        }

    }



}
