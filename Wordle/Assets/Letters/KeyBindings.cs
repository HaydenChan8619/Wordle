using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindings : MonoBehaviour
{
    public GameState game;
    private Dictionary<KeyCode, char> keyCodeDictionary = new Dictionary<KeyCode, char>();

    // MODIFIES: this
    // EFFECTS: initializes the keyCodeDictionary
    private void Awake()
    {
        InitializekeyCodeDictionary();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in keyCodeDictionary.Keys)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    char character = keyCodeDictionary[keyCode];
                    game.addLetter(character);
                }
            }
        }
    }

    // EFFECTS: initializes the keyCodeDictionary by looping through all alphabet KeyCodes and assigning their corresponding character
    private void InitializekeyCodeDictionary()
    {
        for (KeyCode keyCode = KeyCode.A; keyCode <= KeyCode.Z; keyCode++)
        {
            keyCodeDictionary[keyCode] = (char)keyCode;
        }
    }
}
