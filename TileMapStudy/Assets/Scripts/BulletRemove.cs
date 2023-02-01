using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemove : MonoBehaviour
{
    float _timer = 0f;
    // Start is called before the first frame update
   public void Remove()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer>5f)
        {
            Remove();
        }
    }
}
