using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    MonsterControler _mc;
    Transform _hero;
    GameObject _ghero;
    float _speed;
    [SerializeField]int _hp;
    Animator _ani;

    bool isLive = false;
    SpriteRenderer _render;
    bool isHitted=false;
    float _timer = 0f;
    
    bool isRun = false;
    float _runTimer = 0f;
    // Start is called before the first frame update


    void Start()
    {

        _render= GetComponent<SpriteRenderer>();
        //Debug.Log("monster load and start");
        _ani = GetComponent<Animator>();
        //_hero.position
        //transform.position
       // _render.color = Color.red;
       // _render.color = new Color(0, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        colorChange();
        runCheck();
        move();
       


    }

    void runCheck()
    {
        
        if(isRun)
        {
            _runTimer= Time.time;
            if(_runTimer>0.5f)
            {

            _runTimer = 0f;
                isRun= false;

            }


        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {// Debug.Log("영웅을 잡았다!");

            //int attack = collision.gameObject.GetComponent<CharacterController>().getAttack();
            //onHitted(attack);
            collision.gameObject.GetComponent<CharacterController>().hitted();
        }

        if (collision.gameObject.GetComponent<Damage>() !=null)
        {
            int damage = collision.gameObject.GetComponent<Damage>().getDamage();
            collision.gameObject.GetComponent<BulletRemove>().Remove();
            onHitted(damage);
        }
        //gameObject.SetActive(false); 충돌했을 때 사라짐
    }

    void onHitted(int hitPower) 
    {
        _hp -= hitPower;

        //_render.color = Color.red;
        isHitted= true;
        if(_hp < 0)
        {
            _mc.heroExpup();     
            _ani.SetTrigger("dead");
            isLive = false;

        }

    }

    void deadEnd()
    {
        //Debug.Log("dead end Input?");
         gameObject.SetActive(false);
        _mc.newMonster();



        

    }

    void colorChange()
    {
        if (isHitted == true)
        {
            _timer += Time.deltaTime;
            _render.color = Color.red;
            if (_timer > 0.5f)
            {
                //초기화
                isHitted = false;
                _render.color = Color.white;
                _timer = 0f;
            }
        }

    }
        void move()
        {
      
            //if (isRun)
            //    transform.position += (transform.position - _hero.position).normalized * Time.deltaTime * _speed;
            //else
            //    transform.position -= (transform.position - _hero.position).normalized * Time.deltaTime * _speed;

            transform.Translate((_hero.position-transform.position).normalized * Time.deltaTime * _speed); //normalized  대각선 이동
           // transform.position-= (transform.position - _hero.position).normalized * Time.deltaTime * _speed;// +=도망침 / -=가까워짐

        }
        
           // Vector2 direction = _hero.position - transform.position; //타겟-내위치 (몬스터-영웅)



        
        
       
        


    public int getHP()
    {
        return _hp;
    }
    public void Init(MonsterControler mc,Transform hero)
    {
        gameObject.SetActive(true);
        _hero = hero;
        _mc = mc;
        _hp = 20;
        _speed = 1.5f;
        Vector3 ranPos = _hero.position + new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f)).normalized * 6;
        transform.position = ranPos;
        isLive = true;
       // Debug.Log("몬스터 초기화를 호출합니다.");
    }


}








