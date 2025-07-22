using UnityEngine;

public class Box3ScriptHadiah : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("NT Brok, Silahkan Coba Lagi");
            WinPanelManager panel = FindAnyObjectByType < WinPanelManager>();
            if (panel != null)
            {
                panel.ShowWinPanel("NT Brok, Silahkan Coba Lagi");
            }
        }
    }
}
