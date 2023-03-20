using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using static CsvController;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float _speed; //SerializeField 
    [SerializeField] int _attack;
    [SerializeField] int _hp;
    [SerializeField] GameObject _uiPanel;
    [SerializeField] MonsterControler _monCon;
    [SerializeField] GameUi _gameUI;
    [SerializeField] SetSkillItems _skillPanel;
    [SerializeField] CsvController _levelData;

    Animator _ani; //Animator��ü�� ������ ��� ���
    bool _isGameOver=false;
    GameObject _bullet;
    
    GameObject _cicleBullet;
    int _cicleBulletCount = 0;

    GameObject _rotateBullet;


    public Dictionary<ESkillType,int> dicSkills = new Dictionary<ESkillType, int>();

   

    int _heroexp = 0;
    int _needexp = 100;

    int _heroLv = 1;

    int _heroSumExp;

    int moveDirection = 0;//1������ 2���� 3�� 4�Ʒ�

    string _heroName;


    public void SetHeroName(string _name)
    {
        _heroName = _name;
        _gameUI.setChangeName(_heroName);


    } 

    public void hitted()
    {
        if (_hp < 0) return;
        _hp -= 5;
        if(_hp<0)
        {
            
            //Game Over On
            _isGameOver = true;
            _uiPanel.SetActive(true);
            
        }
    }
    
    
    public int getAttack() { return _attack; }

    public void heroExpUp() 
    {
        _heroexp += 60;
        _heroSumExp+= 60;
        if (_heroexp >= _needexp) 
        {
            setLevelUpExp();
            _skillPanel.ShowSkillPanel();
        }
        _gameUI.ExpChange(_heroexp,_needexp);
    }
   void setLevelUpExp()
    {
        //���緹��+1�� ����ġ�� �����ͼ� needexp ����
        //(�������ġ - ���緹���� �ʿ����ġ) / (���緹��+1 ����ġ - ���緹���� �ʿ����ġ)

        int nowNeedExp=0;
        int nextNeedExp=0;

        foreach (stLevelData data in _levelData.IstLevelData)
        {
            if(data.LEVELE==_heroLv)
            {
                nowNeedExp = data.SUMEXP;
            } 
            if(data.LEVELE==_heroLv+1)
            {
                nextNeedExp = data.SUMEXP;
            }
        }
        _heroLv++;
        _needexp = nextNeedExp - nowNeedExp;
        _heroexp = _heroSumExp - nowNeedExp;
    }

    private void Start()
    {


        _ani = gameObject.GetComponent<Animator>();
        
        
      
        _rotateBullet = Resources.Load("Prefabs/RotateBullet") as GameObject;

        gameObject.AddComponent<BaseFire>().Init(_monCon);
       
        _gameUI.ExpChange(_heroexp,_needexp);

        //float sign = Mathf.Sin(30);
        //float radSign = 30 * Mathf.Deg2Rad;
        //float resultSign = Mathf.Sin(radSign);
        //Debug.Log("sign Value : " + sign + ", " + resultSign + ", rad vaule : " + radSign);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            heroExpUp();

        }

        if (_isGameOver) return;

        move();
       

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Transform target = _monCon.selectMonster();
        //    GameObject temp = Instantiate(_bullet);
        //    temp.transform.position = transform.position;
        //    temp.transform.position = transform.position;
        //    temp.name = "Bullet";
        //    temp.GetComponent<Bullet>().Init(target);
        //}

       

       

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    if(gameObject.GetComponent<DaggerFire>()==null)
        //    {
        //        DaggerFire df = gameObject.AddComponent<DaggerFire>();

        //        df.Init(10);

        //    }


        //}

        //if(Input.GetKeyDown(KeyCode.G)) 
        //{
        //    Transform target = _monCon.selectMonster();
        //    GameObject bullet = Instantiate(_rotateBullet);
        //    bullet.transform.position = transform.position;
        //    bullet.GetComponent<RotateBullet>().Init(target.position);
           
        //}

        //if(Input.GetKeyDown(KeyCode.T)) 
        //{
        //    if (gameObject.GetComponent<BibleFire>() == null)
        //    {
        //        BibleFire bf = gameObject.AddComponent<BibleFire>();
        //        bf.Init(1);
        //    }
        //}       
    }

    public void getSkill(stskillData data )
    {
        //Debug.Log("input skill type is : " + data.ETYPE);

        if(dicSkills.ContainsKey(data.ETYPE)==false)
        {
            dicSkills.Add(data.ETYPE, data.LV);
            switch(data.ETYPE)
            {
                case ESkillType.dagger:
                    {
                        gameObject.AddComponent<DaggerFire>().Init(data.LV);break;
                    }
                case ESkillType.bibleShot:
                    {
                        gameObject.AddComponent<BibleFire>().Init(data.LV);break;
                    }
                case ESkillType.homingShot:
                    { 
                        gameObject.AddComponent<HomingFire>().Init(data.LV);break;
                    }
            }
        }
        else
        {
            dicSkills[data.ETYPE] = data.LV;
            switch(data.ETYPE)
            {
                case ESkillType.dagger:
                    {
                        gameObject.GetComponent<DaggerFire>().Init(data.LV); break;
                    }
                case ESkillType.bibleShot:
                    {
                        gameObject.GetComponent<BibleFire>().Init(data.LV); break;
                    }
                case ESkillType.homingShot:
                    {
                        gameObject.GetComponent<HomingFire>().Init(data.LV); break;
                    }
            }
        }



        foreach(ESkillType type in dicSkills.Keys )
        {
            Debug.Log("key :" + type+", value :" + dicSkills[type]);
        }



    }

    void move()
    {

        Vector2 v2 = Vector2.zero;
        bool isidle = true; // �ƹ��͵� �ȴ������� idle ����
        if (Input.GetKey("d")) // d �������� �ִϸ��̼� ���
        {
            //v2 += Vector2.right * Time.deltaTime * _speed;
            _ani.SetInteger("moveDirection", 1);
            transform.Translate(Vector2.right * Time.deltaTime * _speed); ///Vector2(x,y) Time.deltaTime(1�ʵ���) 1�ʵ��� 0.5��ŭ x�� �̵�
            isidle = false;

        }
        //else
        //{
        //    _ani.SetInteger("moveDirection", 0);
        //}

        if (Input.GetKey("a"))
        {
            _ani.SetInteger("moveDirection", 2);
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
            isidle = false;
        }
        //else
        //{
        //    _ani.SetInteger("moveDirection", 0);
        //}
        if (Input.GetKey("w"))
        {
            _ani.SetInteger("moveDirection", 3);
            transform.Translate(Vector2.up * Time.deltaTime * _speed);
            isidle = false;
        }
        //else
        //{
        //    _ani.SetInteger("moveDirection", 0);
        //}
        if (Input.GetKey("s"))
        {
            _ani.SetInteger("moveDirection", 4);
            transform.Translate(Vector2.down * Time.deltaTime * _speed);
            isidle = false;

        }
        if (isidle)
        {
            _ani.SetInteger("moveDirection", 0);


        }

    }

        private void OnCollisionEnter2D(Collision2D collision) // �浹 �� reset
        {
            if(collision.gameObject.tag=="Door")
            {
            Door door= collision.gameObject.GetComponent<Door>();
            if (door != null) door.Rest();
            }
        }


        private void ResetPosition()
        {
                transform.position = Vector3.zero;
        }
    }







