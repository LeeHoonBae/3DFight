using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_UI : MonoBehaviour
{
    [SerializeField]
    float P_HP;
    [SerializeField]
    float P_MaxHP;

    [SerializeField]
    Slider HPgauge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int dam)
    {
        P_HP -= dam;
        slider_set();
    }

    void slider_set()
    {
        HPgauge.value = P_HP / P_MaxHP;
    }
}
