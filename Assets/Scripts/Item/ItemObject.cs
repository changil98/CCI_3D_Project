using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    public string GetInteractPrompt()
    {
        string str = $"{data.name}\n{data.description}";
        return str;
    }
}
