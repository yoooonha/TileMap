using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibleFire : MonoBehaviour //성서
{
    GameObject _bible;
    int _level;
    // Start is called before the first frame update
    void Awake()
    {

        _bible = Resources.Load("Prefabs/Bible") as GameObject;

    }

    // Update is called once per frame
    void Update()
    {

       
        {
            Instantiate(_bible, transform);
        }



    }

   public void Init(int level) 
    {
        _level = level;

        //기존 투사체 전부 삭제
        StartCoroutine(CoMakeBible());

    }


    IEnumerator CoMakeBible()
    {
        int count = 0;
        if (Input.GetKeyDown(KeyCode.T))
        {

            while (count<_level) //
        {
            Instantiate(_bible, transform);
            yield return new WaitForSeconds(0.5f); //0.5초씩 만큼 기다렸다가 넘어감
            count++;

        }
        }
    }


}
