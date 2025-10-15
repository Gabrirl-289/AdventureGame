using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;

    public enum KeyType
    {
        One,
        Two
    }

    public KeyType GetKeyType()
    { 
        return keyType;
    }

    public static Color GetColor(KeyType keyType)
    {
        switch (keyType)
        {
            default:
            case KeyType.One:   return Color.red;
            case KeyType.Two:   return Color.blue;
            
        }
    }

}
