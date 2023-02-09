using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CsvController;

public class Skillitem : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Text _name;
    [SerializeField] Text _descript;
    // Start is called before the first frame update
    SetSkillItems _parent;
    stskillData _data;

public void Init(stskillData data, SetSkillItems parent)
    {
        _data = data;
        _parent = parent;
        _name.text = data.ETYPE + ", LV." + data.LV;
        _descript.text = "DMG : " + data.DMG + ", RANGE : " + data.RANGE + ", BULLET" + data.BULLET;
    }

    public void OnSelected()
    {
        _parent.characterLvup(_data);

    }


}
