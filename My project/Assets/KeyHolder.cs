using NUnit.Framework;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public event EventHandler OnKeysChanged;

    private List<Key.KeyType> keyList;

    private void Awake()
    {
        keyList =  new List<Key.KeyType>();
    }

    public List<Key.KeyType> GetKeyList()
    {
        return keyList();
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        GetKeyList().Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        GetKeyList().Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Key key = collider.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null) {
            if (ContainsKey(keyDoor.GetKeyType())) { 
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
            } else {
                keyDoor.PlayOpenFailAnim();
            }

            
            }
    }

    
    

}
