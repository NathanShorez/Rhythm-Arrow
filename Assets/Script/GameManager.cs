using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource Music;

    public bool startMuisc;

    public BPM beatrate;

    public static GameManager instance;

    public int currentScore;
    public int scorePerHit = 100;
    public int scorePerGood = 150;
    public int scorePerPerfect = 200;

    public int currentMultiple;
    public int multipleTrack;
    public int[] multipleThreshold;

    public Text scoreText;
    public Text multipleText;

    public float totalNotes;
    public float hitsNormal;
    public float hitsGood;
    public float hitsPerfect;
    public float hitsMissed;

    public GameObject results;
    public Text percentHit, percentNormal, percentGood, percentPerfect, percentMiss, rank, finalScore;

    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiple = 1;

        totalNotes = FindObjectsOfType<Note>().Length;
    }

    void Update()
    {
        if (!startMuisc)
        {
            if (Input.anyKeyDown)
            {
                startMuisc = true;
                beatrate.Started = true;

                //Music.Play();
                //Starts Music when button is pressed
            }
        }
        else
        {
            if (!Music.isPlaying && !results.activeInHierarchy)
            {
                results.SetActive(true);

                percentNormal.text = "" + hitsNormal;
                percentGood.text = hitsGood.ToString();
                percentPerfect.text = hitsPerfect.ToString();
                percentMiss.text = "" + hitsMissed;

                float totalHit = hitsNormal + hitsGood + hitsPerfect;
                float scoreHit = (totalHit / totalNotes) * 100f;

                percentHit.text = scoreHit.ToString("F1") + "%";

                string rankno = "F";

                if (scoreHit > 30)
                {
                    rankno = "D";

                    if (scoreHit > 50)
                    {
                        rankno = "C";

                        if (scoreHit > 70)
                        {
                            rankno = "B";

                            if (scoreHit > 90)
                            {
                                rankno = "A";

                                if (scoreHit > 95)
                                {
                                    rankno = "S";

                                    if (scoreHit == 99)
                                    {
                                        rankno = "S+";

                                        if (scoreHit == 100)
                                        {
                                            rankno = "S++";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                rank.text = rankno;

                finalScore.text = currentScore.ToString();
            } 
        }
    }
    public void Hit()
    {
        Debug.Log("Hit");

        if (currentMultiple - 1 < multipleThreshold.Length)
        {
            multipleTrack++;

            if (multipleThreshold[currentMultiple - 1] <= multipleTrack)
            {
                multipleTrack = 0;
                currentMultiple++;
            }
        }

        multipleText.text = "Multiplier: x" + currentMultiple;

        scoreText.text = "Score: " + currentScore;
    }

    public void Normal()
    {
        currentScore += scorePerHit * currentMultiple;
        Hit();

        hitsNormal++;
    }
    public void Good()
    {
        currentScore += scorePerGood * currentMultiple;
        Hit();

        hitsGood++;
    }
    public void Perfect()
    {
        currentScore += scorePerPerfect * currentMultiple;
        Hit();

        hitsPerfect++;
    }
    public void Missed()
    {
        Debug.Log("Miss");

        currentMultiple = 1;
        multipleTrack = 0;

        multipleText.text = "Multiplier: x" + currentMultiple;

        hitsMissed++;
    }
}
