using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class LoadSettings : MonoBehaviour
{
    bool isMovingToSettings = false;
    bool isMovingToMainMenu = false;

    public int ChangeOverSpeed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingToSettings)
        {
            // Check if the camera has reached the target position
            if (Camera.main.transform.position.x >= 14)
            {
                isMovingToSettings = false; // Stop moving the camera
            }
            else
            {
                // Move the camera towards the target position
                Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(14, 0, -10), Time.deltaTime * ChangeOverSpeed);
            }
        }
        if (isMovingToMainMenu)
        {
            // Check if the camera has reached the target position
            if (Camera.main.transform.position.x <= 0)
            {
                isMovingToMainMenu = false; // Stop moving the camera
            }
            else
            {
                // Move the camera towards the target position
                Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(0, 0, -10), Time.deltaTime * ChangeOverSpeed);
            }
        }

    }
    public void MoveCameraToSettings()
    {
        isMovingToSettings = true;
    }
        public void MoveCameraToMain()
    {
        isMovingToMainMenu = true;
    }
}
