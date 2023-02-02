using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float _speed; //SerializeField 
    [SerializeField] int _attack;
    [SerializeField] int _hp;
    [SerializeField] GameObject _uiPanel;
    [SerializeField] MonsterControler _monCon;
    [SerializeField] GameUi _gameUI;
    [SerializeField] SetSkillItems _skillPanel;
    [SerializeField] Image _image;
    Animator _ani; //Animator객체를 변수에 담아 사용
    bool _isGameOver=false;
    GameObject _bullet;
    GameObject _bible;
    GameObject _cicleBullet;
    GameObject _rotateBullet;

    int _heroexp = 0;
    int _needexp = 1000;

    int _herohp = 0;
    int currnthp;


    public void heroExpUp()
    {
        _heroexp += 500;
        if (_heroexp >= _needexp) _skillPanel.ShowSkillPanel();
        _gameUI.ExpChange((float)_heroexp / _needexp);
    }

    public void heroHp()
    {

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
    
    int moveDirection = 0;//1오른쪽 2왼쪽 3위 4아래
    
    public int getAttack() { return _attack; }

    int _cicleBulletCount = 0;

    private void Start()
    {
        _ani = gameObject.GetComponent<Animator>();  
        _bullet = Resources.Load("Prefabs/Bullet") as GameObject;
        _bible = Resources.Load("Prefabs/Bible") as GameObject;
        _cicleBullet = Resources.Load("Prefabs/CircleBullet") as GameObject;
        _rotateBullet = Resources.Load("Prefabs/RotateBullet") as GameObject;
        
        

        //float sign = Mathf.Sin(30);
        //float radSign = 30 * Mathf.Deg2Rad;
        //float resultSign = Mathf.Sin(radSign);
        //Debug.Log("sign Value : " + sign + ", " + resultSign + ", rad vaule : " + radSign);
    }


    // Update is called once per frame
    void Update()
    {
        if (_isGameOver) return;
        move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform target = _monCon.selectMonster();
            GameObject temp = Instantiate(_bullet);
            temp.transform.position = transform.position;
            temp.name = "Bullet";
            temp.GetComponent<Bullet>().Init(target);
        }

        Vector2 v2 = Vector2.zero;
        bool isidle = true; // 아무것도 안눌렀을때 idle 실행
        if (Input.GetKey("d")) // d 눌렀을때 애니메이션 사용
        {
            ///v2 += Vector2.right * Time.deltaTime * _speed;
             _ani.SetInteger("moveDirection", 1);
            transform.Translate(Vector2.right * Time.deltaTime * _speed); ///Vector2(x,y) Time.deltaTime(1초동안) 1초동안 0.5만큼 x축 이동
            isidle = false;

        }
        //else
        //{
        //    _ani.SetInteger("moveDirection", 0);
        //}

        if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(_bible,transform);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            float deg = 30f * _cicleBulletCount;
            float y = Mathf.Sin(deg * Mathf.Deg2Rad);
            float x = Mathf.Cos(deg * Mathf.Deg2Rad);
            GameObject bullet = Instantiate(_cicleBullet);
            bullet.transform.position = transform.position + new Vector3(x, y, 0) * 2;
            bullet.GetComponent<CicleBullet>().Init(new Vector3(x,y, 0));
            _cicleBulletCount++;


        }

        if(Input.GetKeyDown(KeyCode.G)) 
        {
            Transform target = _monCon.selectMonster();
            GameObject bullet = Instantiate(_rotateBullet);
            bullet.transform.position = transform.position;
            bullet.GetComponent<RotateBullet>().Init(target.position);
           
        }

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
    void move()
    {

        Vector2 v2 = Vector2.zero;
        bool isidle = true; // 아무것도 안눌렀을때 idle 실행
        if (Input.GetKey("d")) // d 눌렀을때 애니메이션 사용
        {
            //v2 += Vector2.right * Time.deltaTime * _speed;
            _ani.SetInteger("moveDirection", 1);
            transform.Translate(Vector2.right * Time.deltaTime * _speed); ///Vector2(x,y) Time.deltaTime(1초동안) 1초동안 0.5만큼 x축 이동
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

        private void OnCollisionEnter2D(Collision2D collision) // 충돌 시 reset
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







