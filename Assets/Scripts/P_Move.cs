using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Move : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    Transform tr;

    [SerializeField]
    float Speed;
    [SerializeField]
    float Sprint;

    [SerializeField]
    GameObject Player;

    [SerializeField]
    GameObject[] Weapon_list;
    [SerializeField]
    GameObject Weapon_now;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        tr = this.GetComponent<Transform>();
        Weapon_now = Weapon_list[0];
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        InputElse();
    }

    void InputElse()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))   // 무기 변경 입력
        {
            Weapon_Change(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Weapon_Change(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))   // 무기변경 입력
        {
            Weapon_Change(2);
        }
    }

    void Weapon_Change(int ch_num)  // 무기 변경
    {
        if (Weapon_list.Length > ch_num)
        {
            Weapon_now.SetActive(false);
            Weapon_list[ch_num].SetActive(true);
            Weapon_now = Weapon_list[ch_num];
        }
        else
        {
            Debug.Log("무기 없음");
        }
    }

    void Move() // 이동
    {
        if (Input.GetKey(KeyCode.W))
        {
            tr.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            tr.Translate(Vector3.left * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            tr.Translate(Vector3.back * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            tr.Translate(Vector3.right * Speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed += Sprint;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed -= Sprint;
        }
    }
}
