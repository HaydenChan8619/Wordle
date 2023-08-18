using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public GameState game;
    public AnswerKey answer;

    // EFFECTS: starts a new game
    public void newGame() {
        answer.setAnswerKey();
        game.resetAllBackgrounds();
    }
}
