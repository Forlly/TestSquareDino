using System;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] currentHP;

    public void UpdateSpriteHP(int _countHP, int _startHP)
    {
        float percentCurrentHp = 100f * _countHP / _startHP;
        float percentSpriteHp = percentCurrentHp * currentHP.Length / 100f;
        int indexSprite = (int)Math.Floor(percentSpriteHp);

        for (int i = 0; i < currentHP.Length; i++)
        {
            currentHP[i].enabled = i < indexSprite;
            Debug.Log(indexSprite);
        }
    }
}
