using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFire : MonoBehaviour
{
    MonsterControler _monCon;
    GameObject _bullet;

    // Start is called before the first frame update
    void Awake()
    {
        _bullet = Resources.Load("Prefabs/Bullet") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Init(MonsterControler monCon)
    {
        _monCon = monCon;
        StartCoroutine(CoFire());
    }

    IEnumerator CoFire()
    {
        while (true)
        {
            Transform target = _monCon.selectMonster();
            if (target == null)
            {
                yield return new WaitForSeconds(1f);
                continue;
            }
            GameObject temp = Instantiate(_bullet);
            temp.transform.position = transform.position;
            temp.name = "Bullet";
            temp.GetComponent<Bullet>().Init(target);
            yield return new WaitForSeconds(1f);
        }
    }
}
