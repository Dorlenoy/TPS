using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Value = 100;
    public RectTransform ValueRectTransform;

    public GameObject GameplayUI;
    public GameObject GameOverScreen;

    private float _maxValue;
    private void Start()
    {
        _maxValue = Value;
        DrawHealthBar();
    }

    public void DealDamage(float Damage)
    {
        Value -= Damage;
        if (Value <= 0)
        {
            PlayerIsDead();
        }

        DrawHealthBar();
    }

    private void PlayerIsDead()
    {
        GameplayUI.SetActive(false);
        GameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
    }

    private void DrawHealthBar()
    {
        ValueRectTransform.anchorMax = new Vector2(Value / _maxValue, 1);
    }
}
