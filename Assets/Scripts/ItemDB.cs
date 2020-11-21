using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DatabaseItem
{
    public string displayName;
    public string Engine_Name;
    public string Description;
    public Sprite displaySprite;
    public string Action;
}
[System.Serializable]
public class StatRaise {
    public int HP, BP, JMP_POW,HAMMER_POW,HAND_POW, DEF, SPD, MUSTACHE;
}
[System.Serializable]
public class DatabaseEquip
{
    public string displayName;
    public string Engine_Name;
    public string Description;
    public Sprite displaySprite;
    public string Action;
    public StatRaise Raise;
}
[System.Serializable]
public class ItemDatabase
{
    public DatabaseItem[] Database;
    public DatabaseEquip[] EDatabase;
}
public class ItemDB : MonoBehaviour
{
    public ItemDatabase originalItemDatabase;
}
