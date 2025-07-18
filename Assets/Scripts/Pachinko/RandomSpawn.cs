using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RandomSpawn : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxX = 2.6f;
    public float minX = -2.6f;
    public float yPosition = 6.3f;
    Vector2 spawnPosition;
    public bool isBallRelease = false;

    public float xPos = 0f; // This variable is not used in the current code, but can be used for future modifications.


    // Start is called before the first frame update
    void Start()
    {
        //float xPosition = Random.Range(minX, maxX);
        //spawnPosition = new Vector2(xPosition, yPosition);
        //transform.position = spawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xPos -= 0.05f;
        }
        
        if(Input.GetKey(KeyCode.RightArrow))
        {
            xPos += 0.05f;
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
            //SceneManager.LoadScene("Pachinko Game");
            Debug.Log("Space key pressed, loading Pachinko Game scene.");
            Debug.Log("Spawned at: " + spawnPosition);
            rb.velocity = Vector2.zero;
        }
    }
}
