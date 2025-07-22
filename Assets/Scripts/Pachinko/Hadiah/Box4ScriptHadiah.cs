using UnityEngine;

public class Box4ScriptHadiah : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Selamat Kamu Dapat Chiki Balls");
            WinPanelManager panel = FindAnyObjectByType<WinPanelManager>();
            if (panel != null)
            {
                panel.ShowWinPanel("Selamat Kamu Dapat Chiki Balls");
            }
        }
    }
}
