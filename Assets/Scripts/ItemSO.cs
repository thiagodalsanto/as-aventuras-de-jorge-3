using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject
{
    [Header("Properties")]
    public float cooldown;
    public itemType item_type;
    public Sprite item_sprite;
    public int item_damage;
}

public enum itemType { Hammer, Axe, PickAxe }