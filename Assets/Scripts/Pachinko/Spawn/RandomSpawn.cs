using UnityEngine;
using System.IO.Ports;

public class RandomSpawn : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxX = 2.6f;
    public float minX = -2.6f;
    public float xPos = 0f;
    public float yPosition = 6.3f;
    public bool isBallRelease = false;

    Vector2 spawnPosition;

    SerialPort controlSerial = new SerialPort("COM11", 115200); // Ganti COM5 sesuai port ESP32 kamu

    void Start()
    {
        if(!controlSerial.IsOpen)
        {
            try
            {
                controlSerial.Open();
                Debug.Log("Serial port opened successfully.");
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to open serial port: " + e.Message);
            }
        }
        spawnPosition = new Vector2(xPos, yPosition);
        transform.position = spawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.velocity);

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    xPos -= 0.05f;
        //}

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    xPos += 0.05f;
        //}

        if (controlSerial.IsOpen && controlSerial.BytesToRead > 0)
        {
            try
            {
                string data = controlSerial.ReadLine().Trim();

                if (data == "LEFT")
                {
                    xPos -= 0.1f;
                }
                else if (data == "RIGHT") 
                { 
                    xPos += 0.1f; 
                }

            }
            catch (System.Exception e)
            {
                Debug.LogError("Error reading from serial port: " + e.Message);
            }
        }

        xPos = Mathf.Clamp(xPos, minX, maxX); // Ensure xPos stays within bounds

        if (isBallRelease == false)
        {
            spawnPosition = new Vector2(xPos, yPosition);
            transform.position = spawnPosition;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isBallRelease = true;
            rb.velocity = Vector2.zero;
            Debug.Log("Spawned at: " + spawnPosition);
        }
    }

    void OnApplicationQuit()
    {
        if (controlSerial != null && controlSerial.IsOpen)
        {
            controlSerial.Close();
            Debug.Log("Serial port closed.");
        }
    }
}
