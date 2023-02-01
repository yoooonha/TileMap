using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setskillitems : MonoBehaviour
{
    [SerializeField] CsvController _controller;
    [SerializeField] GameObject _item;
    [SerializeField] Transform _content;
public void ShowSkillPanel()
    {
        gameObject.SetActive(true);
        //foreach(stskillData data in _controller.isSKillData)
        {
            GameObject temp = Instantiate(_item, _content);
           // temp.GetComponent<Skillitem>().Init(data);
        }
    }

    private void Start()
    {
        for(int i=0; i<5;i++)
        {
            Instantiate(_item, _content);
        }
    }
}
