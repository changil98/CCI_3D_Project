using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject InteractGameObject;
    private IInteractable interactable;

    public TextMeshProUGUI prompText;
    private Camera camera;

    public bool IsEat = false;

    PlayerCondition condition;

    private void Awake()
    {
        condition = GetComponent<PlayerCondition>();
    }

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if(Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != InteractGameObject)
                {
                    InteractGameObject = hit.collider.gameObject;
                    interactable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                InteractGameObject = null;
                interactable = null;
                prompText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        prompText.gameObject.SetActive(true);
        prompText.text = interactable.GetInteractPrompt();
    }

    public void OnEat(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && interactable != null)
        {
            if(InteractGameObject.gameObject.tag == "Food")
            {
                IsEat = true;
                condition.Eat();
                Destroy(InteractGameObject.gameObject);
                InteractGameObject = null;
                interactable = null;
                prompText.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("음식이 아닙니다.");
            }
        }
    }
}
