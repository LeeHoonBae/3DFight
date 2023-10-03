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

    W_B_staff W_B_Staff;    // 마탄 컴포넌트

    [SerializeField]
    float Timer;
    [SerializeField]
    float shootspd;

    [SerializeField]
    int damm;     // 대미지

    [SerializeField]
    float makeTime; // 마탄 생성 시간

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
                        // 투사체 생성
                        summonPos = this.transform.position + transform.forward * 3;
                        summonPos.y = 1;
                        
                        sumbul = Instantiate(Bullet, summonPos, transform.rotation);    // 마탄 소환
                        W_B_Staff = sumbul.GetComponent<W_B_staff>();                  // 마탄 컴포넌트 저장
                        sumbul.transform.parent = this.transform;               // 자식 컴포넌트로 배치
                        W_B_Staff.WBspeed = shootspd;                           // 마탄 속도

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
                        W_B_Staff.Damage = damm + (int)Timer;    // 추가로 차징한 시간만큼 대미지 상승
                        magic = Magic.shoot;
                    }

                    // Debug.Log(magic);
                    break;
                }
            case Magic.shoot:
                {
                    // 투사체 발사
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
