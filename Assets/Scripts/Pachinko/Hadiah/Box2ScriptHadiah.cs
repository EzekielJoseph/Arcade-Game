using UnityEngine;

public class Box2ScriptHadiah : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Selamat Kamu Menang Lima Puluh Ribu USD!!!");
        }
    }
}
