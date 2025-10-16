using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key");
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType) { 
        return keyList.Contains(keyType);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Key key = GetComponent<BoxCollider2D>().GetComponent<Key>();
        if (key != null) 
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }
    }
        
    
}
