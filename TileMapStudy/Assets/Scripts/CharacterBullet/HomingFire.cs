using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingFire : MonoBehaviour
{
    GameObject _bullet;
    MonsterControler _monCon;
    int _level;

    // Start is called before the first frame update
    void Awake()
    {

        _bullet = Resources.Load("Prefabs/Bullet") as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Init(int level)
    {
        _level = level;

        //기존 투사체 전부 삭제
        StartCoroutine(CoMakehoming());

    }


    IEnumerator CoMakehoming()
    {
        int count = 0;
        while (true) //
        {
           if (Input.GetKeyDown(KeyCode.Space))
            {
                Transform target = _monCon.selectMonster();
                GameObject temp = Instantiate(_bullet);
                temp.transform.position = transform.position;
                temp.transform.position = transform.position;
                temp.name = "Bullet";
                temp.GetComponent<Bullet>().Init(target);
            }

            yield return new WaitForSeconds(0.5f); //0.5초씩 만큼 기다렸다가 넘어감
            count++;

        }
    }


}
