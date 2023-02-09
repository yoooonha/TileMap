using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerFire : MonoBehaviour
{
    GameObject _cicleBullet;
    int _cicleBulletCount = 0;
    int _level;


    void Awake()
    {
        _cicleBullet = Resources.Load("Prefabs/CircleBullet") as GameObject;


    }

    // Update is called once per frame
    void Update()
    {
      

    }



    public void Init(int level)
    {
       
        _level= level;
        StartCoroutine(CoMakeDagger());

    }


    IEnumerator CoMakeDagger()
    {

        int count = 0;

        while (true) //
        {
            //Instantiate(_cicleBullet);

            float deg = 30f * _cicleBulletCount;
            float y = Mathf.Sin(deg * Mathf.Deg2Rad);
            float x = Mathf.Cos(deg * Mathf.Deg2Rad);

            GameObject bullet = Instantiate(_cicleBullet);

            bullet.transform.position = transform.position + new Vector3(x, y, 0) * 2;
            bullet.GetComponent<CicleBullet>().Init(new Vector3(x, y, 0));
            _cicleBulletCount++;
            yield return new WaitForSeconds(0.5f);
            count++;

        }
    }


}
