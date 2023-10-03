using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class W_greatsword_Old : MonoBehaviour
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

    [SerializeField]
    Vector3[] charge_pos = { new Vector3(90, 0, 90), new Vector3(-85, 0, 90), new Vector3(310, 45, 210) };

    [SerializeField]
    Vector3[] attack_pos = { new Vector3(105, 0, 90), new Vector3(175, 0, 90), new Vector3(90, 0, -45) };

    Vector3 nPos;

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

    void Timer()    // ���� �ð� ����
    {
        if (linkTimer > 0)
        {
            linkTimer -= Time.deltaTime;    // ������� ���� �ð� ����
        }
    }

    void charge_input()   // ��¡ �Է� �ޱ�
    {
        if (Input.GetMouseButtonDown(0))
        {
            P_Move.enabled = false; // ��¡�� �̵� �Ұ�

            switch (linkTime)
            {
                case 1:
                    transform.localEulerAngles = new Vector3(90, -180, -90);
                    break;
                case 2:
                    transform.localEulerAngles = new Vector3(105, 360, 270);
                    Debug.Log("attack0");
                    break;
                case 3:
                    transform.localEulerAngles = new Vector3(75, -180, -90);
                    break;
            }

            if (linkTimer < 0)  // �ð� �ʰ��� ������� �ʱ�ȭ
            {
                linkTime = 1;
            }
        }

        if (Input.GetMouseButton(0))    // ���⸦ ��¡�ϴ� �ð�
        {
            nPos = transform.rotation.eulerAngles;
            if (linkTime == 1)  // ù��° ��¡
            {
                // transform.rotation = Quaternion.Euler(nPos + Vector3.up * 0.1f);
                transform.localEulerAngles = (charge_pos[0] + (charge_pos[1] - charge_pos[0]) * (Charge_Now / Charge_Max));
            }
            else if (linkTime == 2)  // �ι�° ��¡
            {
                // transform.rotation = Quaternion.Lerp(Quaternion.Euler(attack_pos[0]), Quaternion.Euler(charge_pos[2]), Charge_Now / Charge_Max);
                transform.localEulerAngles = (attack_pos[0] + (charge_pos[2] - attack_pos[0]) * (Charge_Now / Charge_Max));
            }
            else  // ����° ��¡
            {
                transform.localEulerAngles = (charge_pos[0] + (charge_pos[1] - charge_pos[0]) * (Charge_Now / Charge_Max));
            }

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
    }

    void attack()   // ����
    {
        if (linkTime == 1)  // ù��° ��¡
        {
            // transform.rotation = Quaternion.Euler(charge_pos[1] - (charge_pos[1] - attack_pos[0]) * (1 - Charge_Now / Charge_Max));
            transform.localEulerAngles = (charge_pos[1] - (charge_pos[1] - attack_pos[0]) * (1 - Charge_Now / Charge_Max));
        }
        else if (linkTime == 2)  // �ι�° ��¡
        {
            
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
}
