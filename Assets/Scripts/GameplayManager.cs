using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayManager : MonoBehaviour
{
    public GameObject feedbackTrue, feedbackFalse;
    public int totalScore, valueScore;
    public TextMeshProUGUI sumScore;
    public float timer;

    private void Start()
    {
        sumScore.text = totalScore.ToString();
    }

    public void FeedbackTrue()
    {
        feedbackTrue.SetActive(true);
        StartCoroutine(timerFeedback(timer));
        feedbackTrue.SetActive(false);
        totalScore += valueScore;
        sumScore.text = totalScore.ToString();
        Debug.Log("Good Job, your score " + totalScore);
    }

    public void FeedbackFalse()
    {
        feedbackFalse.SetActive(true);
        StartCoroutine(timerFeedback(timer));
        feedbackFalse.SetActive(false);
        totalScore -= valueScore;
        sumScore.text = totalScore.ToString();
        Debug.Log("Wrong Pin, your score " + totalScore);
    }

    IEnumerator timerFeedback(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
