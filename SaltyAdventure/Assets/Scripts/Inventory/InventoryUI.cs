using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region Singleton

    public static InventoryUI instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject PauseMenu;

    InventoryManager inventory;

    InventorySlot[] slots;

    public GameObject MedicineBag;
    public GameObject PokeballBag;

    public static bool InvIsActive;

    void Start()
    {
        inventory = InventoryManager.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            if (inventoryUI.activeSelf)
            {
                PauseMenu.GetComponent<TimeController>().FreezeTime();
                InvIsActive = true;
                
                //Test
                InventoryManager.instance.SwitchActiveBag(MedicineBag, "");
            }
            else if (!inventoryUI.activeSelf)
            {
                PauseMenu.GetComponent<TimeController>().ResumeTime();
                InvIsActive = true;
            }
        }
    }

    void UpdateUI() {
        Debug.Log("Updating UI");
        SwitchToActiveBag();
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        //Debug.Log("Slot Count: " + slots.Length);
        //Debug.Log("Items Count: " + InventoryManager.activeItemList.Count);

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < InventoryManager.activeItemList.Count)
            {
                slots[i].AddItem(InventoryManager.activeItemList[i]);
                Debug.Log(InventoryManager.activeItemList[i].name + " got added");
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }

    void SwitchToActiveBag()
    {
        itemsParent = InventoryManager.activeBag.transform;
    }
}
