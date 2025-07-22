using UnityEngine;

public class Box1ScriptHadiah : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Selamat Kamu Menang NVDIA RTX 5090!!!");
            WinPanelManager panel = FindAnyObjectByType<WinPanelManager>();
            if (panel != null)
            {
                panel.ShowWinPanel("Selamat Kamu Menang NVDIA RTX 5090!!!");
            }
        }
    }
}
