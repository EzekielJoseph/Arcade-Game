using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    public TMP_InputField namaInput;
    public TMP_InputField emailInput;
    public TMP_InputField domisiliInput;
    public TMP_InputField umurInput;

    public void onRegister()
    {
        string nama = namaInput.text;
        string email = emailInput.text;
        string domisili = domisiliInput.text;
        int umur = int.Parse( umurInput.text );

        Data userData = new Data(nama, email, domisili, umur);

        userData.TampilkanDataDebug();

        UserDataManager.Instance.SetData(userData);

        SceneManager.LoadScene("Pachinko Game");
    }
}
