using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    [SerializeField] Image _expGauge;
    [SerializeField] Image _hpbar;
    private void Update()
    {
        //_expGauge.transform.localScale += new Vector3(Time.deltaTime,0,0);
        //if (_expGauge.transform.localScale.x >= 1) _expGauge.transform.localScale = new Vector3(0, 1, 1);
    }
    
  public void OnButtonToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void OnButtonReGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExpChange(float value)
    {
        float min = 0;
        float max = 1;
        if (min > value) value = min;
        if (max < value) value = max;
        _expGauge.transform.localScale = new Vector3(value,1,1);

    }



}
