using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _deg;
    [SerializeField] int _count;
    [SerializeField] float _gap;
    [SerializeField] Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject temp = Instantiate(_bullet);
        //temp.transform.position=transform.position;
        //float deg = _deg;
        //Vector3 dir = new Vector3(Mathf.Cos(deg*Mathf.Deg2Rad),Mathf.Sin(deg*Mathf.Deg2Rad), 0);
        //temp.GetComponent<Bullet>().Init(dir.normalized); 

        //GameObject temp2=Instantiate(_bullet);
        //temp2.transform.position=transform.position;
        //float deg2 = _deg + -15;
        //Vector3 dir2=new Vector3(Mathf.Cos(deg2*Mathf.Deg2Rad),Mathf.Sin(deg2 * Mathf.Deg2Rad), 0);
        //temp2.GetComponent<Bullet>().Init(dir2.normalized);

        //for(int i=0; i<_count; i++)
        //{
        //    GameObject temp = Instantiate(_bullet);
        //    temp.transform.position=transform.position;
        //    float deg = (_deg / _count) * i; //+ 30; 
        //    Vector3 dir = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
        //    temp.GetComponent<Bullet>().Init(dir);

        //}

         StartCoroutine(CoinfiniteMultiShot());
    //    while(true)
    //    {

    //    Vector3 v3temp = _target.position - transform.position;
    //    float degTemp = Mathf.Atan(v3temp.y / v3temp.x);
    //    float radDeg = degTemp * Mathf.Rad2Deg;

    //    for (int i=0; i< _count; i++)
    //    {
    //        GameObject temp = Instantiate(_bullet);
    //        temp.transform.position=transform.position;
    //        float deg = i * (_deg / (_count-1)) + radDeg- _deg/2f;
    //        Vector3 dir = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
    //        temp.GetComponent<Bullet>().Init(dir);
    //    }
    //    }
    
    }

    IEnumerator CoShot()
    {

        while (true)
        {
        for (int i = 0; i < _count; i++)
            {
                GameObject temp = Instantiate(_bullet);
                temp.transform.position = transform.position;
                float deg = (_deg / _count) * i + 30;
                Vector3 dir = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
                temp.GetComponent<Bullet>().Init(dir);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(0.5f);
                  }

    }

    IEnumerator CoinfiniteShot()
    {
        int i = 0;

        while (true)
        {
            
            GameObject temp = Instantiate(_bullet);
            temp.transform.position = transform.position;
            Vector3 v3temp = _target.position-transform.position;
            float degTemp = Mathf.Atan(v3temp.y / v3temp.x);
            float deg = degTemp * Mathf.Rad2Deg + i * (_deg / _count);
            Vector3 dir = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
            temp.GetComponent<Bullet>().Init(dir);  
            i++;
            yield return new WaitForSeconds(0.2f);
        }


    }

    IEnumerator CoinfiniteMultiShot() 
    {
        while (true)
        {

            Vector3 v3temp = _target.position - transform.position;
            float degTemp = Mathf.Atan2(v3temp.y , v3temp.x);
            float radDeg = degTemp * Mathf.Rad2Deg;

            for (int i = 0; i < _count; i++)
            {
                GameObject temp = Instantiate(_bullet);
                temp.transform.position = transform.position;
                float deg = i * (_deg / (_count - 1)) + radDeg - _deg / 2f;
                Vector3 dir = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
                temp.GetComponent<Bullet>().Init(dir);
            }

            yield return new WaitForSeconds(0.2f);
        }

    }




    // Update is called once per frame
    void Update()
    {
        


    }

}
