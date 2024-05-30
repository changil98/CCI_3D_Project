using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    PlayerController controller;
    Interaction interaction;

    Condition health { get { return uiCondition.health; } }

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        interaction = GetComponent<Interaction>();
    }

    void Update()
    {
        if (controller.IsMove() == true)
        {
            health.Add(health.addValue * Time.deltaTime);
        }
        else
        {
            health.Subtract(health.subtractValue * Time.deltaTime);
        }
    }

    public void Eat()
    {
        if (interaction.IsEat == true)
        {
            StartCoroutine(Healing());
        }
    }


    IEnumerator Healing()
    {
        float healing = 10f;
        controller.moveSpeed = 6f;
        health.nowValue += healing;
        Debug.Log("체력이 회복되고 이동속도가 5초 동안 증가합니다.");
        yield return new WaitForSecondsRealtime(5f);
        controller.moveSpeed = 5f;
    }
}
