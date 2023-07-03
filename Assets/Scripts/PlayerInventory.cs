using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerInventory : MonoBehaviour
{

    [Header("General")]
    public List<itemType> inventoryList;
    public int selectedItem;
    public float playerReach;
    [SerializeField] GameObject throwItem_gameobject;

    [Space(20)]
    [Header("Keys")]
    [SerializeField] KeyCode throwItemKey;
     [SerializeField] float throwForce;
    [SerializeField] KeyCode pickItemKey;

    [Space(20)]
    [Header("Item gameobjects")]
    [SerializeField] GameObject hammer_item;
    [SerializeField] GameObject axe_item;
    [SerializeField] GameObject pickaxe_item;
    [SerializeField] GameObject hoe_item;

    [Space(20)]
    [Header("Item prefabs")]
    [SerializeField] GameObject hammer_prefab;
    [SerializeField] GameObject axe_prefab;
    [SerializeField] GameObject pickaxe_prefab;
    [SerializeField] GameObject hoe_prefab;

    [Space(20)]
    [Header("UI")]
    [SerializeField] Image[] inventorySlotImage = new Image[9];
    [SerializeField] Image[] inventoryBackgroundImage = new Image[9];
    [SerializeField] Sprite emptySlotSprite;

    [SerializeField] Camera cam;
    [SerializeField] GameObject pickUpItem_gameobject;

    private Dictionary<itemType, GameObject> itemSetActive = new Dictionary<itemType, GameObject>() { };
    private Dictionary<itemType, GameObject> itemInstantiate = new Dictionary<itemType, GameObject>() { };

    public ProgressBar progressBar;

    void Start()
    {
        itemSetActive.Add(itemType.Hammer, hammer_item);
        itemSetActive.Add(itemType.Axe, axe_item);
        itemSetActive.Add(itemType.PickAxe, pickaxe_item);
        itemSetActive.Add(itemType.Hoe, hoe_item);

        itemInstantiate.Add(itemType.Hammer, hammer_prefab);
        itemInstantiate.Add(itemType.Axe, axe_prefab);
        itemInstantiate.Add(itemType.PickAxe, pickaxe_prefab);
        itemInstantiate.Add(itemType.Hoe, hoe_prefab);


        NewItemSelected();

        pickUpItem_gameobject.SetActive(false);
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, playerReach);
        bool hasItemCollider = false;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Item"))
            {
                hasItemCollider = true;
                break;
            }
        }

        if (hasItemCollider)
        {
            pickUpItem_gameobject.SetActive(true);

            if (Input.GetKeyDown(pickItemKey))
            {
                Collider itemCollider = colliders.FirstOrDefault(c => c.CompareTag("Item"));
                ItemPickable item = itemCollider.GetComponent<ItemPickable>();

                if (item != null)
                {
                    item.tag = "NaMao";
                    inventoryList.Add(item.itemScriptableObject.item_type);
                    item.PickItem();
                }
            }
        }
        else
        {
            pickUpItem_gameobject.SetActive(false);
        }

        if (Input.GetKeyDown(throwItemKey) && inventoryList.Count > 1)
	    {
            GameObject thrownItem = Instantiate(itemInstantiate[inventoryList[selectedItem]], position: throwItem_gameobject.transform.position, new Quaternion());
            Rigidbody thrownItemRigidbody = thrownItem.GetComponent<Rigidbody>();

            if (thrownItemRigidbody != null)
            {
                thrownItem.tag = "Item";
                thrownItemRigidbody.AddForce(cam.transform.forward * throwForce, ForceMode.Impulse); // Adiciona uma força de lançamento ao objeto
            }

            inventoryList.RemoveAt(selectedItem);

            if (selectedItem != 0)
            {
                selectedItem -= 1;
            }

            NewItemSelected();
	    }

		for (int i = 0; i < 8; i++)
        {
            if (i < inventoryList.Count)
            {
                inventorySlotImage[i].sprite = itemSetActive[inventoryList[i]].GetComponent<Item>().itemScriptableObject.item_sprite;
            } else {
                inventorySlotImage[i].sprite = emptySlotSprite;
            }
        }

        if (selectedItem != null)
        {
            progressBar.currentValue = itemSetActive[inventoryList[selectedItem]].GetComponent<Item>().itemScriptableObject.item_damage;
        } else {
            progressBar.currentValue = 0;
        }

        int a = 0;
        foreach(Image image in inventoryBackgroundImage)
        {
            if (a == selectedItem)
            {
                image.color = new Color(0.0f, 1f, 1f, 1);
            } else {
                image.color = new Color(1f, 1f, 1f, 1);
            }
            a++;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && inventoryList.Count > 0)
        {
            selectedItem = 0;
            NewItemSelected();
        } else if (Input.GetKeyDown(KeyCode.Alpha2) && inventoryList.Count > 1)
        {
            selectedItem = 1;
            NewItemSelected();
        } else if (Input.GetKeyDown(KeyCode.Alpha3) && inventoryList.Count > 2)
        {
            selectedItem = 2;
            NewItemSelected();
        } else if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryList.Count > 3)
        {
            selectedItem = 3;
            NewItemSelected();
        } else if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryList.Count > 4)
        {
            selectedItem = 4;
            NewItemSelected();
        } else if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryList.Count > 5)
        {
            selectedItem = 5;
            NewItemSelected();
        } else if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryList.Count > 6)
        {
            selectedItem = 6;
            NewItemSelected();
        } else if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryList.Count > 7)
        {
            selectedItem = 7;
            NewItemSelected();
        } else if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryList.Count > 8)
        {
            selectedItem = 8;
            NewItemSelected();
        }
    }

    private void NewItemSelected()
    {
        hammer_item.SetActive(false);
        axe_item.SetActive(false);
        pickaxe_item.SetActive(false);
        hoe_item.SetActive(false);

        if (inventoryList.Count > 0 && selectedItem < inventoryList.Count)
        {
            GameObject selectedItemGameobject = itemSetActive[inventoryList[selectedItem]];
            if (selectedItemGameobject != null)
            {
                selectedItemGameobject.SetActive(true);
            }
        }
    }
}

public interface IPickable
{
    void PickItem();
}
