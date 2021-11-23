using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField Input;
    public void NewPlayerName(TMP_InputField Input)
    {
        string PlayerName = Input.text;
        PlayerManager.Instance.PlayerName = PlayerName;
        SceneManager.LoadScene(1);
    }

    public void Start()
    {
        if(PlayerManager.Instance.PlayerName != null)
        {
            Input.text = PlayerManager.Instance.PlayerName;
        }
    }

}
