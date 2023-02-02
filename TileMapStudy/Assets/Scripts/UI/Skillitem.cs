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
public void Init(stskillData data)
    {
        _name.text = data.NAME + ", LV." + data.LV;
        _descript.text = "DMG : " + data.DMG + ", RANGE : " + data.RANGE + ", BULLET" + data.BULLET;
    }
}
