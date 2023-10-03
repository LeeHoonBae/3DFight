using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_B_staff : MonoBehaviour
{
    public
    int Damage;

    public
    bool isCharge;
    public
    float WBspeed;

    [SerializeField]
    float Timer;


    // Start is called before the first frame update
    void Start()
    {
        isCharge = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCharge)
        {
            //Debug.Log("charge!");
        }
        else
        {
            //Debug.Log("shooting!");
            transform.position += transform.forward * WBspeed * Time.deltaTime;
            Timer += Time.deltaTime;
        }

        if (Timer > 5)
        {
            del();
        }
    }

    void del()
    {
        Destroy(this.gameObject);
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
        del();
    }
}