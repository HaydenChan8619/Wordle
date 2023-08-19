using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerKey : MonoBehaviour
{
    private List<char> answerKey;
    public GameState game;

    private Color green = new Color(0.7f, 0.95f, 0.5f);
    private Color yellow = new Color(0.94f, 0.94f, 0.5f);
    private Color grey = new Color(0.5f, 0.5f, 0.5f);

    public string GetRandomFiveLetterWords()
    {
        Array values = Enum.GetValues(typeof(FiveLetterWordList));
        int randomIndex = UnityEngine.Random.Range(0, values.Length);
        return values.GetValue(randomIndex).ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        setAnswerKey();
    }

    public string getAnswerKey() {
        return string.Join("",answerKey);
    }

    // MODIFIES: this
    // EFFECTS: sets a new answerKey
    public void setAnswerKey() {
        string baseString = GetRandomFiveLetterWords();
        answerKey = new List<char>(baseString);
    }

    // EFFECTS: checks the validity of the input
    public void checkAnswer(List<char> inputList) {
        List<int> usedAnswerkeyPositions = new List<int>();
        List<int> usedInputListPositions = new List<int>();
        
        for (int inputListIndex = 0; inputListIndex < 5; inputListIndex++) {
            bool isSameCharacterSamePosition = inputList[inputListIndex].Equals(answerKey[inputListIndex]);

            if (isSameCharacterSamePosition) {

                game.changeColour(inputListIndex,green);
                usedAnswerkeyPositions.Add(inputListIndex);
                usedInputListPositions.Add(inputListIndex);

            }
        }

        for (int inputListIndex = 0; inputListIndex < 5; inputListIndex++) {
            for (int answerKeyIndex = 0; answerKeyIndex < 5; answerKeyIndex++) {

                bool isSameCharacterDifferentPosition = inputList[inputListIndex].Equals(answerKey[answerKeyIndex]);
                bool isNotDuplicate = !(usedAnswerkeyPositions.Contains(answerKeyIndex) || usedInputListPositions.Contains(inputListIndex));;

                if (isSameCharacterDifferentPosition && isNotDuplicate) {
                    game.changeColour(inputListIndex, yellow);
                    usedAnswerkeyPositions.Add(answerKeyIndex);
                    usedInputListPositions.Add(inputListIndex);
                }
            }

            if (!usedInputListPositions.Contains(inputListIndex)) {
                game.changeColour(inputListIndex, grey);
            }
        }

    }



    

}
