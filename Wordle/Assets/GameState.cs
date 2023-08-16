using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
This class represents the state of the game, including the answerkey, attempts, and the line currently being inputted
*/
public class GameState : MonoBehaviour
{

    private readonly int MAXLENGTH = 5;
    private int attemptNum;
    public GameObject letter1;
    public GameObject letter2;
    public GameObject letter3;
    public GameObject letter4;
    public GameObject letter5;

    public List<char> currentAttempt;
    private List<List<char>> attempts;

    // Start is called before the first frame update
    void Start()
    {
        currentAttempt = new List<char>();
        attemptNum = 1;
        locateLetterBoxes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // MODIFIES: this
    // EFFECTS: adds the character into currentAttempts, and adds that character onto the board
    public void addLetter(char c){
        Debug.Log(currentAttempt.Count);
        int currentAttemptLength = currentAttempt.Count;
        if (currentAttemptLength < MAXLENGTH) {
            currentAttempt.Add(c);
            addToBoard(c);
        }
        
    }

    private void addToBoard(char c) {
        Text letter = findChild();
        letter.text = c.ToString().ToUpper();
    }

    private Text findChild() {
        switch(currentAttempt.Count) {
            case 1:
                return letter1.transform.Find("Letter").GetComponent<Text>();
            case 2: 
                return letter2.transform.Find("Letter").GetComponent<Text>();
            case 3:
                return letter3.transform.Find("Letter").GetComponent<Text>();
            case 4:
                return letter4.transform.Find("Letter").GetComponent<Text>();
            case 5: 
                return letter5.transform.Find("Letter").GetComponent<Text>();
        }

        return null;
    }


    // MODIFIES: this
    // EFFECTS: sets each letter to the correct GameObject
    private void locateLetterBoxes() {
        letter1 = GameObject.Find(attemptNum.ToString() + ".1");
        letter2 = GameObject.Find(attemptNum.ToString() + ".2");
        letter3 = GameObject.Find(attemptNum.ToString() + ".3");
        letter4 = GameObject.Find(attemptNum.ToString() + ".4");
        letter5 = GameObject.Find(attemptNum.ToString() + ".5");
    }

    
}
