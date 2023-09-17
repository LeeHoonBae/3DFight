using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummi : MonoBehaviour
{
    [SerializeField]
    int HP_Now;
    [SerializeField]
    int HP_Max;
    [SerializeField]
    float Regeneration_Time;
    [SerializeField]
    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        HP_Now = HP_Max;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP_Now < HP_Max)
        {
            Heal_Time();
        }
    }

    void Heal_Time()
    {
        Timer += Time.deltaTime;
        if (Regeneration_Time < Timer)
        {
            HP_Now = HP_Max;
            Timer = 0;
        }
    }

    public void Damage(int dam)
    {
        HP_Now -= dam;
        Timer = 0;
    }
}
