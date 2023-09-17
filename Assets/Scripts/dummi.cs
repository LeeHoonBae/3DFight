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
    float Regeneration_Time;    // ��� �ð�
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
        if (HP_Now < HP_Max)    // Ǯ�ǰ� �ƴ� �� ȸ�� Ÿ�̸�
        {
            Heal_Time();
        }
    }

    void Heal_Time()
    {
        Timer += Time.deltaTime;
        if (Regeneration_Time < Timer)  // ȸ�� Ÿ�̸Ӱ� �Ǹ� ü�� ȸ�� �� Ÿ�̸� �ʱ�ȭ
        {
            HP_Now = HP_Max;
            Timer = 0;
        }
    }

    public void Damage(int dam) // ���� ���� �� ȸ�� Ÿ�̸� �ʱ�ȭ
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
