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
        //새로운 게임오브젝트 유니티 실행 중 배치
        _monster= Resources.Load("Prefabs/Slime") as GameObject; //as GameObject 형변환
        //GameObject mon = Instantiate(_monster);
        makeMonster();
          
        //_monster.SetActive(false);
        //makeInit();

    }


   

    void makeInit()
    {
        List<int> IsInits = new List<int>();
        Debug.Log("ints의 길이 : "+IsInits.Count);
        IsInits.Add(5);
        Debug.Log("ints의 길이 : "+IsInits.Count);
        IsInits.Remove(0);
        Debug.Log("ints의 길이 : "+IsInits.Count);

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
        //신규 몬스터를 생성합시다.
        //GameObject mon = Instantiate(_monster, transform);
        //mon.GetComponent<Monster>().Init(this, _hero);
        //꺼진(active false) 오브젝트가 있는지 검색
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
            if (distance > Vector3.Distance(mon.transform.position, _hero.position)||target==null) //(몬스터위치,캐릭터위치)
            {
                distance = Vector3.Distance(mon.transform.position, _hero.position);
                target = mon.transform;
            }
        }
        return target;
    }
    // Debug.Log("Ist count: " + mons.Count);
    // //Monster[] mons = GetComponentsInChildren<Monster>(); // GetComponenetsInChildren
    //// Debug.Log("몬스터의 갯수 : " + mons.Length);
    // for (int i = 0; i < mons.Count; i++) //.Length 배열의 길이 index 순서
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
    
