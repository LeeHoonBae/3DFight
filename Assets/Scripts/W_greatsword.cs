using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class W_greatsword : MonoBehaviour
{
    [SerializeField]
    P_Move P_Move;

    [SerializeField]
    float charge_Speed;
    [SerializeField]
    float Charge_Now;
    [SerializeField]
    float Charge_Max;

    [SerializeField]
    float attack_Speed;
    [SerializeField]
    int Damage;

    [SerializeField]
    bool isAtk;

    Quaternion x;

    // Start is called before the first frame update
    void Start()
    {
        P_Move = GetComponentInParent<P_Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAtk) // 공격상태가 아니면
        {
            charge_input(); // 입력을 받는다
        }
        else
        {
            attack();   // 아니면 공격을 한다
        }

        Timer();    // 공격 시간 제어
    }

    void Timer()    // 타이머
    {

    }

    void charge_input()   // 차징 입력 받기
    {
        if (Input.GetMouseButtonDown(0))
        {
            P_Move.enabled = false; // 차징중 이동 불가

        }

        if (Input.GetMouseButton(0))    // 무기를 차징하는 시간
        {
            if (Charge_Now < Charge_Max)
            {
                x = Quaternion.AngleAxis(Charge_Now * charge_Speed * Time.deltaTime, Vector3.up);
                transform.rotation = transform.rotation * x;
                Charge_Now += Time.deltaTime;
            }
            else
            {
                Charge_Now = Charge_Max;
            }
        }

        if (Input.GetMouseButtonUp(0))  // 차징을 끝내고 공격
        {
            isAtk = true;
            P_Move.enabled = true;
        }
    }

    void attack()   // 공격
    {
        if (Charge_Now > 0)
        {
            x = Quaternion.AngleAxis(attack_Speed * Time.deltaTime, Vector3.down);
            transform.rotation = transform.rotation * x;
            Charge_Now -= Time.deltaTime;
        }
        else    // 공격 끝
        {
            isAtk = false;
            Charge_Now = 0;

        }
    }

    private void OnCollisionEnter(Collision collision)  // 데미지 적용
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("데미지");
            collision.gameObject.GetComponent<dummi>().Damage(Damage);
        }
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("데미지");
            collision.gameObject.GetComponent<dummi>().Damage(Damage);
        }
    }   // 데미지

    /*private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other);
        var target = other.gameObject.GetComponentInParent<dummi>();
        if (target.gameObject.layer == 6)
        {
            Debug.Log("데미지");
            target.gameObject.GetComponent<dummi>().Damage(Damage);
        }
        if (target.gameObject.layer == 8)
        {
            Debug.Log("데미지");
            target.gameObject.GetComponent<dummi>().Damage(Damage);
        }
    }*/
}
