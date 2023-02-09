using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] InputField _text;
    [SerializeField] CharacterController _heroData;

   void OnReGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main");

    }

    public void OnEndGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Lobby");
    }

    public void OnExit()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;

    }

    public void OnChangeValue()
    {

        _heroData.SetHeroName(_text.text);

    }





}
