using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthSlider : MonoBehaviour
{
    public Slider bossHealthBarSlider;

    public void SetMaxBossHealth(float BossHealth){
        bossHealthBarSlider.maxValue = BossHealth;
        bossHealthBarSlider.value = BossHealth;
    }

    public void SetBossHealth(int BossHealth){
        bossHealthBarSlider.value = BossHealth;
    }
}
