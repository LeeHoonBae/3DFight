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
        // Weapon_transform = this.transform.GetChild(0);  // �ڽ� ������Ʈ �ҷ�����
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAtk)
        {

            charge_input();
        }
        else
        {
            attack();
        }

        Timer();
    }

    void Timer()
    {
        if (linkTimer > 0)
        {
            linkTimer -= Time.deltaTime;
        }
    }

    void charge_input()
    {
        if (Input.GetMouseButtonDown(0))
        {
            P_Move.enabled = false; // ��¡�� �̵� �Ұ�

            if (linkTimer < 0)  // �ð� �ʰ��� ������� �ʱ�ȭ
            {
                linkTime = 1;
            }
        }
        if (Input.GetMouseButton(0))    // ���⸦ ��¡�ϴ� �ð�
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
        if (Input.GetMouseButtonUp(0))  // ��¡�� ������ ����
        {
            isAtk = true;
        }
    }   // ���� �غ�

    void attack()   // ����
    {
        if (linkTime == 1)  // ù��° ��¡
        {
            transform.Rotate(Vector3.up * Time.deltaTime * attack_Speed);
        }
        else if (linkTime == 2)  // �ι�° ��¡
        {
            transform.Rotate(Vector3.left * Time.deltaTime * attack_Speed);
        }
        else  // ����° ��¡
        {
            transform.Rotate(Vector3.up * Time.deltaTime * attack_Speed);
        }

        if (Charge_Now > 0)
        {
            Charge_Now -= Time.deltaTime;
        }
        else    // ���� ��
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("������");
            // collision.gameObject.GetComponent<dummi>().Damage(Damage);
        }
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("������");
            collision.gameObject.GetComponent<dummi>().Damage(Damage);
        }
    }   // ������
}
