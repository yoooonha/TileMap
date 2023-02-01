using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int _damage;

    // Update is called once per frame
    void Update()
    {
        


    }

    public int getDamage()
    { return _damage; }
}
