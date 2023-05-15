using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrientationTest : MonoBehaviour
{

    [SerializeField] TMP_Text systemInfoText;
    [SerializeField] Mode mode;

    enum Mode
    {
        gravity,
        acceleration,
        userAcceleration,
        rotationRate,
        rotationRateUnbiased,
        attitude,
    }

    // Start is called before the first frame update
    void Start()
    {
        systemInfoText.text = "Sensors";
        if (SystemInfo.supportsAccelerometer)
        {
            systemInfoText.text = "Accelerometer";
        }

        if (SystemInfo.supportsGyroscope)
        {
            systemInfoText.text = "Gyroscope";
            Input.gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case Mode.gravity:
                this.transform.up = -Input.gyro.gravity;
                break;
            case Mode.acceleration:
                this.transform.up = -Input.acceleration;
                break;
            case Mode.userAcceleration:
                this.transform.up = -Input.gyro.userAcceleration;

                break;
            case Mode.rotationRate:
                this.transform.Rotate(Input.gyro.rotationRate);

                break;
            case Mode.rotationRateUnbiased:
                this.transform.Rotate(Input.gyro.rotationRateUnbiased);
                break;
            case Mode.attitude:
                this.transform.rotation = Quaternion.Euler(90, 0, 0) * Input.gyro.attitude * new Quaternion(0, 0, -1,0);
                break;
        }
    }
}