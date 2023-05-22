using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitCount : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public void UpdateText(int value)
    {
        text.text = "wait : " + value + "s";
    }

    public void UpdateCountdownGameplay(int value){
         text.text = value.ToString();
    }
}
