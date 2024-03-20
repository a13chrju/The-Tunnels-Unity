using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public bool activePlayer = false;
    private List<string> items;
    void Start()
    {
        items = new List<string>();
    }

    public void AddItem (string item)
    {
        if (!items.Exists(x => x.Contains(item)))
        {
            items.Add(item);
        }
        items.ForEach(x => Debug.Log(x));
 
    }

    public void removeItem(string item)
    {
        if (items.Exists(x => x.Contains(item)))
        {
            items.Remove(item);
        }
        Debug.Log(items.Count);

    }

    public bool hasItem(string item)
    {
        if (items.Exists(x => x.Contains(item)))
        {
            return true;
        }
        return false;
    }
}
