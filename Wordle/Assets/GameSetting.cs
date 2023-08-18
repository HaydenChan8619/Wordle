using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public GameState game;
    public AnswerKey answer;
    public GameObject gameplayCanvas;

    // EFFECTS: starts a new game
    public void newGame() {
        answer.setAnswerKey();
        game.resetAllBackgrounds();
        gameplayCanvas.SetActive(true);
    }
}
