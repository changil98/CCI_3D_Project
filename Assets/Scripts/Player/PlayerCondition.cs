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
        Debug.Log("ü���� ȸ���ǰ� �̵��ӵ��� 5�� ���� �����մϴ�.");
        yield return new WaitForSecondsRealtime(5f);
        controller.moveSpeed = 5f;
    }
}
