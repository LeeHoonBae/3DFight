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
        if (!isAtk) // ���ݻ��°� �ƴϸ�
        {
            charge_input(); // �Է��� �޴´�
        }
        else
        {
            attack();   // �ƴϸ� ������ �Ѵ�
        }

        Timer();    // ���� �ð� ����
    }

    void Timer()    // Ÿ�̸�
    {

    }

    void charge_input()   // ��¡ �Է� �ޱ�
    {
        if (Input.GetMouseButtonDown(0))
        {
            P_Move.enabled = false; // ��¡�� �̵� �Ұ�

        }

        if (Input.GetMouseButton(0))    // ���⸦ ��¡�ϴ� �ð�
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

        if (Input.GetMouseButtonUp(0))  // ��¡�� ������ ����
        {
            isAtk = true;
            P_Move.enabled = true;
        }
    }

    void attack()   // ����
    {
        if (Charge_Now > 0)
        {
            x = Quaternion.AngleAxis(attack_Speed * Time.deltaTime, Vector3.down);
            transform.rotation = transform.rotation * x;
            Charge_Now -= Time.deltaTime;
        }
        else    // ���� ��
        {
            isAtk = false;
            Charge_Now = 0;

        }
    }

    private void OnCollisionEnter(Collision collision)  // ������ ����
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("������");
            collision.gameObject.GetComponent<dummi>().Damage(Damage);
        }
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("������");
            collision.gameObject.GetComponent<dummi>().Damage(Damage);
        }
    }   // ������

    /*private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other);
        var target = other.gameObject.GetComponentInParent<dummi>();
        if (target.gameObject.layer == 6)
        {
            Debug.Log("������");
            target.gameObject.GetComponent<dummi>().Damage(Damage);
        }
        if (target.gameObject.layer == 8)
        {
            Debug.Log("������");
            target.gameObject.GetComponent<dummi>().Damage(Damage);
        }
    }*/
}
