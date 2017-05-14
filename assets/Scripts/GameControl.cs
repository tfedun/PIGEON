using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public Rigidbody2D Bird;
    public GUIText StartText;
    public GUIText Scoretext;
    public GUIText overs;
    int a;
    public int score;
    private int record = 0;
    public bool over = false;
    public bool start;
    public bool restart;
    public GameObject Car;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int scoreremember;
    public GUIText finalScore;
    public GUIText RecordText;

    void Start()
    {
        RecordText.text = "Record: " + record;
        a = 0;
        restart = false;
        finalScore.text = "";
        score = 0;
        UpdateScore();
        if (over == false)
        {
            start = false;
            over = true;
            gameover();
        }
        else
        {
            start = true;
            StartCoroutine(SpawnWaves());
        }
        }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
            while (Bird.gameObject.active)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Car, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
        }
    }

    private void Update()
    {
        if (!Bird.gameObject.active)
        {
            scoreremember = score;
            overs.gameObject.SetActive(true);
            finalScore.text = "Your score: " + scoreremember;
            //StartText.text = "Touch to Play again";
            Bird.gameObject.SetActive(false);
            gameover();
            
        }
        if (restart && Input.GetMouseButtonDown(0))
        {
            Bird.gameObject.SetActive(true);
            Bird.transform.position = new Vector2(-12, -8);
            StartText.text = "";
            overs.gameObject.SetActive(false);
            Start();
        }
        else if (start && Bird.gameObject.active)
        {
            if (a >= 50)
            {
                a = 0;
                score++;
            }
            a++;
            UpdateScore();
        }

        if(score > record)
        {
            PlayerPrefs.SetInt("Highest", score);
            PlayerPrefs.Save();
        }

        record = PlayerPrefs.GetInt("Highest");

    }

    public void gameover()
    {
        StartText.text = "Touch to start";
        restart = true;
    }

    public void UpdateScore()
    {
        Scoretext.text = "Score: " + score;
    }

}
