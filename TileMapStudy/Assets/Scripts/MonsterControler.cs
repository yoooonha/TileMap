using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MonsterControler : MonoBehaviour
{
    [SerializeField] Transform _hero;
    [SerializeField] Transform _monCon;
    GameObject _monster;
    List<Monster> mons = new List<Monster>();

    // Start is called before the first frame update
    void Start()
    {
        //���ο� ���ӿ�����Ʈ ����Ƽ ���� �� ��ġ
        _monster= Resources.Load("Prefabs/Slime") as GameObject; //as GameObject ����ȯ
        //GameObject mon = Instantiate(_monster);
        makeMonster();
          
        //_monster.SetActive(false);
        //makeInit();

    }


   

    void makeInit()
    {
        List<int> IsInits = new List<int>();
        Debug.Log("ints�� ���� : "+IsInits.Count);
        IsInits.Add(5);
        Debug.Log("ints�� ���� : "+IsInits.Count);
        IsInits.Remove(0);
        Debug.Log("ints�� ���� : "+IsInits.Count);

    }
    void makeMonster()
    {
          
        for (int i = 0; i < 10; i++)
        {
            GameObject mon = Instantiate(_monster, transform);
            mons.Add(mon.GetComponent<Monster>());
            //Instantiate(_monster, transform);
            //GameObject mon= Instantiate(_monster);
            //mon.SetActive(false);
            foreach (Monster _mon in mons)
            {
                _mon.Init(this,_hero);
            }
        }

    }

    public void heroExpup()
    {
        _hero.gameObject.GetComponent<CharacterController>().heroExpUp();
    }
   
        public void newMonster()
        {
        //�ű� ���͸� �����սô�.
        //GameObject mon = Instantiate(_monster, transform);
        //mon.GetComponent<Monster>().Init(this, _hero);
        //����(active false) ������Ʈ�� �ִ��� �˻�
        foreach (Monster _mon in mons)
            {
                if (_mon.gameObject.activeSelf == false)
                {
                _mon.Init(this, _hero);
                //isNew = false;
                
                break;
                }
            }
        }

    public Transform selectMonster()
    {
        float distance = 0f;
        Transform target = null;
        foreach (Monster mon in mons)
        {
            if (distance > Vector3.Distance(mon.transform.position, _hero.position)||target==null) //(������ġ,ĳ������ġ)
            {
                distance = Vector3.Distance(mon.transform.position, _hero.position);
                target = mon.transform;
            }
        }
        return target;
    }
    // Debug.Log("Ist count: " + mons.Count);
    // //Monster[] mons = GetComponentsInChildren<Monster>(); // GetComponenetsInChildren
    //// Debug.Log("������ ���� : " + mons.Length);
    // for (int i = 0; i < mons.Count; i++) //.Length �迭�� ���� index ����
    // {
    //     mons[i].Init();
    // }
    // //int j = 0;
    // //while (j < mons.Length)
    // //{
    // //    mons[j].Init();
    // //    j++;
    // //}



    // Update is called once per frame
    void Update()
    {
        
    }
}
    
