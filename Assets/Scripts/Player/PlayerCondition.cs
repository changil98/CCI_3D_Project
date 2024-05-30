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
        Debug.Log("ü���� ȸ���ǰ� �̵��ӵ��� 5�� ���� �����մϴ�.");
        yield return new WaitForSecondsRealtime(5f);
        controller.moveSpeed = 5f;
    }
}
