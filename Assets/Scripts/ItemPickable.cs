using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickable : MonoBehaviour, IPickable
{
    public ItemSO itemScriptableObject;

    public void PickItem()
    {
        Destroy(gameObject);
    }
}
