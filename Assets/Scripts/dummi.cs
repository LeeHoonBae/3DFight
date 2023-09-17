using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dummi : MonoBehaviour
{
    [SerializeField]
    float HP_Now;
    [SerializeField]
    float HP_Max;
    [SerializeField]
    Slider HP_Bar;

    [SerializeField]
    float Regeneration_Time;    // 재생 시간
    [SerializeField]
    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        HP_Now = HP_Max;
        slider_set();
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
        slider_set();
    }

    void slider_set()
    {
        HP_Bar.value = HP_Now / HP_Max;
    }
}
