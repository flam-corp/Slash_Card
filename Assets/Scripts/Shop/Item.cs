using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Board", order = 51)]
public class Item : ScriptableObject
{
    public Color color;
    public byte id;
}