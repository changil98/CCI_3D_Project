using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "new Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string name;
    public string description;
    public GameObject[] dropPrefab;
}
