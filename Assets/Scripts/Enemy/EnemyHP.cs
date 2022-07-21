using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image hp;

    public void UpdateSpriteHP(int _countHP, int _startHP)
    {
        background.enabled = true;
        hp.enabled = true;
        
        if (_countHP <= 0)
        {
            background.enabled = false;
            hp.enabled = false;
        }
        float percentCurrentHp = 100f * _countHP / _startHP;
        
        hp.fillAmount = percentCurrentHp/100f;

    }
}
