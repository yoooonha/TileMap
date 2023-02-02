using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static CsvController;

public class SetSkillItems : MonoBehaviour
{
    [SerializeField] CsvController _controller;
    [SerializeField] GameObject _item;
    [SerializeField] Transform _content;
    public void ShowSkillPanel()
    {
        gameObject.SetActive(true);
        foreach(stskillData data in _controller.IstSkillData)
        {
            GameObject temp = Instantiate(_item,_content);
            temp.GetComponent<Skillitem>().Init(data);
        }
    }

    private void Start()
    {

    }
}
