using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    PlayerController controller;

    Condition health { get { return uiCondition.health; } }

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
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
}
