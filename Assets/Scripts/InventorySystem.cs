using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InventoryItem {
    public string Name;
    public int ID;
    public int count;
}
[System.Serializable]
public class Inventory
{
    public InventoryItem[] EquipItems;
    public InventoryItem[] Items;
    public int[] E;
}

[System.Serializable]
public class InventorySystem : MonoBehaviour
{
    public Inventory inv;
    public void Dbg_show() {
        Debug.Log("Showing All");
        Debug.Log("Inventory Items : " + inv.Items.ToString());
        Debug.Log("Equipment : " + inv.EquipItems.ToString());
        Debug.Log("Equipment E : " + inv.E.ToString());
    }
}
