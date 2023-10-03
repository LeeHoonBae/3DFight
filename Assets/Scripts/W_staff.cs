using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class W_staff : MonoBehaviour
{
    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    GameObject sumbul;
    [SerializeField]
    Vector3 summonPos;

    W_B_staff W_B_Staff;    // ��ź ������Ʈ

    [SerializeField]
    float Timer;
    [SerializeField]
    float shootspd;

    [SerializeField]
    int damm;     // �����

    [SerializeField]
    float makeTime; // ��ź ���� �ð�

    enum Magic{
        none, make, charge, shoot
    }
    Magic magic = Magic.none;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (magic)
        {
            case Magic.none:
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        magic = Magic.make;
                    }

                    // Debug.Log(magic);
                    break;
                }
            case Magic.make:
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        resetmod();
                    }

                    Timer += Time.deltaTime;

                    if (Timer > makeTime)
                    {
                        // ����ü ����
                        summonPos = this.transform.position + transform.forward * 3;
                        summonPos.y = 1;
                        
                        sumbul = Instantiate(Bullet, summonPos, transform.rotation);    // ��ź ��ȯ
                        W_B_Staff = sumbul.GetComponent<W_B_staff>();                  // ��ź ������Ʈ ����
                        sumbul.transform.parent = this.transform;               // �ڽ� ������Ʈ�� ��ġ
                        W_B_Staff.WBspeed = shootspd;                           // ��ź �ӵ�

                        Timer = 0;

                        magic = Magic.charge;
                    }

                    //Debug.Log(magic);
                    break;
                }
            case Magic.charge:
                {
                    Timer += Time.deltaTime;

                    if (Input.GetMouseButtonUp(0))
                    {
                        W_B_Staff.Damage = damm + (int)Timer;    // �߰��� ��¡�� �ð���ŭ ����� ���
                        magic = Magic.shoot;
                    }

                    // Debug.Log(magic);
                    break;
                }
            case Magic.shoot:
                {
                    // ����ü �߻�
                    resetmod();

                    sumbul.GetComponent<W_B_staff>().isCharge = false;

                    //Debug.Log(magic);
                    break;
                }
        }
    }

    void resetmod()
    {
        magic = Magic.none;

        Timer = 0;
    }
}
