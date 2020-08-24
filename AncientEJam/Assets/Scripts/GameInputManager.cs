using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

// Taken from a forum post and modified to suit the game

public static class GameInputManager
{
    static Dictionary<string, KeyCode> keyMapping;
    static Dictionary<KeyCode, string> reverseKeyMapping;
    static string[] keyMaps = new string[6]
    {
        "Forward",
        "Backward",
        "Left",
        "Right",
        "Interact",
        "Cycle"
    };
    static KeyCode[] defaults = new KeyCode[6]
    {
        KeyCode.W,
        KeyCode.S,
        KeyCode.A,
        KeyCode.D,
        KeyCode.Space,
        KeyCode.Tab
    };

    static GameInputManager()
    {
        InitializeDictionary();
    }

    private static void InitializeDictionary()
    {
        keyMapping = new Dictionary<string, KeyCode>();
        reverseKeyMapping = new Dictionary<KeyCode, string>();
        for (int i = 0; i < keyMaps.Length; ++i)
        {
            keyMapping.Add(keyMaps[i], defaults[i]);
            reverseKeyMapping.Add(defaults[i], keyMaps[i]);
        }
    }

    public static void SetKeyMap(string keyMap, KeyCode key)
    {
        if (!keyMapping.ContainsKey(keyMap))
            throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);
        keyMapping[keyMap] = key;
        reverseKeyMapping[key] = keyMap;
    }

    public static bool GetKey(string keyMap) 
    {
        return Input.GetKey(keyMapping[keyMap]);
    }

    public static bool GetKeyDown(string keyMap)
    {
        return Input.GetKeyDown(keyMapping[keyMap]);
    }
    
    public static string[] GetKeyMaps()
    {
        return keyMaps;
    }
    
    public static KeyCode GetKeyCode(string keyMap)
    {
        if (keyMapping.ContainsKey(keyMap))
            return keyMapping[keyMap];
        return KeyCode.None;
    }
    
    public static string GetKeyMapName(KeyCode key)
    {
        if (!reverseKeyMapping.ContainsKey(key))
            throw new Exception("KeyCode " + key + " does not exist in reverseKeyMapping");
        return reverseKeyMapping[key];
    }
    
    public static bool ContainsKeyCode(KeyCode key)
    {
        return reverseKeyMapping.ContainsKey(key);
    }
    
    public static bool CheckForNoKeyCode()
    {
        return keyMapping.ContainsValue(KeyCode.None);
    }
    
    public static void ResetAllKeys()
    {
        for (int i = 0; i < keyMaps.Length; ++i)
        {
            keyMapping[keyMaps[i]] = defaults[i];
        }
    }
}