using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class represents what happens when a key on the keyboard gets clicked
*/

public class LetterKey : MonoBehaviour
{
    public char letter = 'a';
    public GameState game;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // EFFECTS: adds the letter to the currentAttempt
    public void click() {
        game.addLetter(letter);
        Debug.Log("yes");
    }

    public void enter() {

    }

    public void undo() {

    }
}
