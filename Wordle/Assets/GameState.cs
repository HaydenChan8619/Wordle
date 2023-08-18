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
    public AnswerKey answer;
    public GameSetting settings;

    public List<char> currentAttempt;
    private List<List<char>> attempts;

    // Start is called before the first frame update
    void Start()
    {
        currentAttempt = new List<char>();
        attemptNum = 1;
        locateLetterBoxes();
    }

    // MODIFIES: this
    // EFFECTS: adds the character into currentAttempts, and adds that character onto the board
    public void addLetter(char c){
        int currentAttemptLength = currentAttempt.Count;
        if (currentAttemptLength < MAXLENGTH) {
            currentAttempt.Add(c);
            addToBoard(c);
        }
        
    }

    // EFFECTS: adds the character onto the board at the corresponding position
    private void addToBoard(char c) {
        Text letter = findChildText(currentAttempt.Count);
        letter.text = c.ToString().ToUpper();
    }

    // EFFECTS: return the corresponding text component based on the currentAttempt length
    private Text findChildText(int position) {
        switch(position) {
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

    // EFFECTS: return the image corresponding to the backgroundNumber
    private Image findChildTextBackground(int backgroundNumber) {
        switch(backgroundNumber) {
            case 1:
                return letter1.transform.Find("LetterBackground").GetComponent<Image>();
            case 2: 
                return letter2.transform.Find("LetterBackground").GetComponent<Image>();
            case 3:
                return letter3.transform.Find("LetterBackground").GetComponent<Image>();
            case 4:
                return letter4.transform.Find("LetterBackground").GetComponent<Image>();
            case 5: 
                return letter5.transform.Find("LetterBackground").GetComponent<Image>();
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


    // MODIFIES: this
    // EFFECTS: removes the last letter entered by the user from the board and the list
    public void removeLast() {
        if (!(currentAttempt.Count == 0)) {
            removeLastFromBoard();
            currentAttempt.RemoveAt(currentAttempt.Count - 1);
        }
    }

    // MODIFIES: this
    // EFFECTS: removes the last letter from the board
    private void removeLastFromBoard() {
        Text letter = findChildText(currentAttempt.Count);
        letter.text = "";
    }


    // MODIFIES: this
    // EFFECTS: increase attempt by one, and reveal the correctness of the guess
    public void confirmAnswer() {
        if (currentAttempt.Count == MAXLENGTH) {
            answer.checkAnswer(currentAttempt);

            if(attemptNum != 6) {
                attemptNum += 1;
                currentAttempt = new List<char>();
                locateLetterBoxes();
            } //else {
            //    endGame();
            //}
        }  
    }


    // EFFECTS: Changes the colour of the background according to the newColour
    public void changeColour(int position, Color newColour) {
        Image background = findChildTextBackground(position + 1);
        background.color = newColour;
    }

    // EFFECTS: exits the program
    public void exitGame() {
        Application.Quit();
    }

    // MODIFIES: this
    // EFFECTS: resets all the backgrounds on the board to white
    public void resetAllBackgrounds() {
        attemptNum = 1;
        while (attemptNum < 7) {
            for (int i = 0; i < 5; i++) {
                locateLetterBoxes();
                changeColour(i,new Color(1,1,1));
                Text letter = findChildText(i+1);
                letter.text = "";
            }
            attemptNum += 1;
        }
        Start();
    }




    
}
