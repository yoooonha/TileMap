using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    // Start is called before the first frame update
  public void OnButtonToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void OnButtonReGame()
    {
        SceneManager.LoadScene("Main");
    }
}
