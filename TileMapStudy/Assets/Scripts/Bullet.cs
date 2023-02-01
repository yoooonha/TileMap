using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //target
    [SerializeField] float _speed;
    Transform _target = null;
    Vector3 _dir;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(Transform target)
    {
        _target= target;
        _dir=(_target.position-transform.position).normalized;

    }

    public void Init(Vector3 dir)
    {
        _dir=dir;
    }

    // Update is called once per frame
    void Update()
    {
        //target 이동
        //transform.Translate((_target.position-transform.position).normalized*Time.deltaTime*_speed);
                               //대상위치-내위치=얼만큼이동
    transform.Translate(_dir*Time.deltaTime*_speed);

 
    }

 
}
