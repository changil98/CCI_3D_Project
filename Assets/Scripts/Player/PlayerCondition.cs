using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    PlayerController controller;
    Interaction interaction;

    float healing = 10f;
    float jumping = 5;

    Condition health { get { return uiCondition.health; } }
    Condition stamina {  get { return uiCondition.stamina; } }

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        interaction = GetComponent<Interaction>();
    }

    void Update()
    {
        if (controller.Jump() == true)
        {
            stamina.Subtract(jumping);
        }
        else if (controller.IsMove() == true)
        {
            stamina.Add(stamina.addValue * Time.deltaTime);
        }
        else if (stamina.nowValue <= 0f)
        {
            health.Subtract(health.subtractValue * Time.deltaTime);
        }
        else
        {
            stamina.Subtract(stamina.subtractValue * Time.deltaTime);
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
        controller.moveSpeed = 7f;
        health.nowValue += healing;
        Debug.Log("체력이 회복되고 이동속도가 5초 동안 증가합니다.");
        yield return new WaitForSecondsRealtime(5f);
        controller.moveSpeed = 5f;
    }
}
