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

    SerialPort controlSerial = new SerialPort("COM11", 115200); // Ganti COM sesuai port kamu

    void Start()
    {
        if (!controlSerial.IsOpen)
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

        // Tahan bola di tempat dulu
        rb.isKinematic = true;
    }

    void Update()
    {
        if (controlSerial.IsOpen && controlSerial.BytesToRead > 0)
        {
            try
            {
                string data = controlSerial.ReadLine().Trim();

                if (!WinPanelManager.Instance.IsPanelActive())
                {
                    if (data == "LEFT")
                    {
                        xPos -= 0.1f;
                    }
                    else if (data == "RIGHT")
                    {
                        xPos += 0.1f;
                    }
                    else if (data == "SPACE" && !isBallRelease)
                    {
                        rb.isKinematic = false;
                        rb.velocity = Vector2.zero;
                        isBallRelease = true;
                        Debug.Log("Spawned at: " + spawnPosition);
                    }
                }

                // Jika panel sedang aktif dan tombol SPACE ditekan → skip countdown
                if (data == "SPACE" && WinPanelManager.Instance.IsPanelActive())
                {
                    WinPanelManager.Instance.SkipCountdown();
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error reading from serial port: " + e.Message);
            }
        }

        xPos = Mathf.Clamp(xPos, minX, maxX);

        if (!isBallRelease)
        {
            spawnPosition = new Vector2(xPos, yPosition);
            transform.position = spawnPosition;
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
