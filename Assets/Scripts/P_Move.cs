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
    float Speed_Limit;


    public
    float fMove;
    [SerializeField]
    float lMove;
    [SerializeField]
    float bMove;
    [SerializeField]
    float rMove;

    [SerializeField]
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        tr = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
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
    }
}
