using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
             Time.timeScale = 0;
        }
    }
}
