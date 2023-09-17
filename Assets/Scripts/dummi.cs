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
        if (HP_Now < HP_Max)    // 풀피가 아닐 때 회복 타이머
        {
            Heal_Time();
        }
    }

    void Heal_Time()
    {
        Timer += Time.deltaTime;
        if (Regeneration_Time < Timer)  // 회복 타이머가 되면 체력 회복 후 타이머 초기화
        {
            HP_Now = HP_Max;
            Timer = 0;
        }
    }

    public void Damage(int dam) // 공격 적용 후 회복 타이머 초기화
    {
        HP_Now -= dam;
        slider_set();
        Timer = 0;
    }

    void slider_set()
    {
        HP_Bar.value = HP_Now / HP_Max;
    }
}
