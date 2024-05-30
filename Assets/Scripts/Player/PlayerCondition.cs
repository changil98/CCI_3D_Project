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
    float poisondamage = 10f;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

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
            StartCoroutine(EatFood());
        }
    }


    IEnumerator EatFood()
    {
        switch (interaction.InteractGameObject.gameObject.name)
        {
            case "Mushroom1":
                stamina.Add(10f);
                Debug.Log("스태미나가 회복 됬습니다.");
                yield return null;
                break;
            case "Mushroom2":
                health.Add(healing);
                Debug.Log("체력이 회복됬습니다.");
                yield return null;
                break;
            case "Mushroom3":
                health.Subtract(poisondamage);
                Debug.Log("독 버섯을 먹었습니다.");
                yield return null;
                break;
            case "MushroomLarge":
                controller.moveSpeed = 10f;
                Debug.Log("이동속도가 5초 동안 매우 빨라집니다.");
                yield return new WaitForSecondsRealtime(5f);
                controller.moveSpeed = 5f;
                break;
        }
    }
}
