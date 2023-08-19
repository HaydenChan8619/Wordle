using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public GameState game;
    public AnswerKey answer;
    public GameObject gameplayCanvas;
    public GameObject startCanvas;

    // Start is called before the first frame update
    void Start()
    {
        gameplayCanvas.SetActive(false);
        startCanvas.SetActive(true);
        game.setIsGameActive(false);
    }

    // EFFECTS: starts a new game
    public void newGame() {
        answer.setAnswerKey();
        game.resetAllBackgrounds();
        canvasReset();
    }


    // EFFECTS: reset all the canvases as required
    private void canvasReset() {
        gameplayCanvas.SetActive(true);
        startCanvas.SetActive(false);
        game.keyboard.SetActive(true);
        game.endGamePopUp.SetActive(false);
        game.winGamePopUp.SetActive(false);
        game.setIsGameActive(true);
    }
}
