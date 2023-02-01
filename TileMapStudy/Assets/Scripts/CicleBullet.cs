using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CicleBullet : MonoBehaviour
{
    [SerializeField] float _speed;
    Vector3 _target;
    float _lifetimer = 0f;

    public void Init(Vector3 target)
    {
        _target = target;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_target * Time.deltaTime * _speed);
        if (_lifetimer > 5)
        {
            Remove();
        }


    }
        public void Remove()
        { Destroy(gameObject); }
}
