using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameplayTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] private float duration = 60f;
    public UnityEvent OnTimesUp;

    private void Start()
    {
        timerText.text = "Timer: " + Mathf.FloorToInt(duration).ToString();
    }

    void Update()
    {
        duration -= Time.deltaTime;
        timerText.text = "Timer: " + Mathf.FloorToInt(duration).ToString();

        if (duration <= .0f)
        {
            OnTimesUp.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
