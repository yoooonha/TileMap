using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SetSkillItems : MonoBehaviour
{
    [SerializeField] CsvController _controller;
    [SerializeField] GameObject _item;
    [SerializeField] Transform _content;
    [SerializeField] CharacterController _hero;

    

    List<GameObject> IstItems = new List<GameObject>();
    public void ShowSkillPanel()
    {
        //Time.timeScale = 0;
        gameObject.SetActive(true);

        for (int i = 1; i < (int)ESkillType.multiShot; i++)
        {
         
            foreach (stskillData data in _controller.IstSkillData)
            {
                if (data.ETYPE != (ESkillType)i) continue;
                if (_hero.dicSkills.ContainsKey(data.ETYPE)==true)
                {
                    if (data.LV == _hero.dicSkills[data.ETYPE] + 1)
                    {
                        GameObject temp = Instantiate(_item, _content);
                        temp.GetComponent<Skillitem>().Init(data, this);

                    }

                }
                else
                {
                    if (data.LV == 1)
                    {
                        GameObject temp = Instantiate(_item, _content);
                        temp.GetComponent<Skillitem>().Init(data, this);
                        IstItems.Add(temp);
                        
                    }
                }
            }
        }
    }

    public void characterLvup(stskillData data)
    {
        _hero.getSkill(data);

        gameObject.SetActive(false);

        foreach (GameObject temp in IstItems)
        {
            Destroy(temp);
        }
        IstItems.Clear();
      
    }
    private void Start()
    {
    }


}
