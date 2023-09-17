using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class W_greatsword : MonoBehaviour
{
    [SerializeField]
    P_Move P_Move;

    [SerializeField]
    float Charge_Max;
    [SerializeField]
    float Charge_Now;

    [SerializeField]
    float attack_Speed;
    [SerializeField]
    int Damage;

    [SerializeField]
    bool isAtk;

    [SerializeField]
    int linkTime;
    [SerializeField]
    float linkTimer;
    [SerializeField]
    float linkTimer_Max;

    // Start is called before the first frame update
    void Start()
    {
        P_Move = GetComponentInParent<P_Move>();
        linkTime = 1;
        // Weapon_transform = this.transform.GetChild(0);  // 자식 오브젝트 불러오기
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

    void Timer()    // 공격 시간 제어
    {
        if (linkTimer > 0)
        {
            linkTimer -= Time.deltaTime;    // 연계공격 가능 시간 감소
        }
    }

    void charge_input()   // 차징 입력 받기
    {
        if (Input.GetMouseButtonDown(0))
        {
            P_Move.enabled = false; // 차징중 이동 불가

            if (linkTimer < 0)  // 시간 초과시 연계공격 초기화
            {
                linkTime = 1;
            }
        }

        if (Input.GetMouseButton(0))    // 무기를 차징하는 시간
        {
            if (Charge_Now < Charge_Max)
            {
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
        }
    }

    void attack()   // 공격
    {
        if (linkTime == 1)  // 첫번째 차징
        {
            // 대검 모션 넣기
            transform.Rotate(Vector3.up * Time.deltaTime * attack_Speed);
        }
        else if (linkTime == 2)  // 두번째 차징
        {
            transform.Rotate(Vector3.left * Time.deltaTime * attack_Speed);
        }
        else  // 세번째 차징
        {
            transform.Rotate(Vector3.up * Time.deltaTime * attack_Speed);
        }

        if (Charge_Now > 0)
        {
            Charge_Now -= Time.deltaTime;
        }
        else    // 공격 끝
        {
            isAtk = false;
            Charge_Now = 0;
            P_Move.enabled = true;
            linkTimer = linkTimer_Max;

            if (linkTime == 1)
            {
                linkTime = 2;
            }
            else if (linkTime == 2)
            {
                linkTime = 3;
            }
            else
            {
                linkTime = 1;
            }
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
}
