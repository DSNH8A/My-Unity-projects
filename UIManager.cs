using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private ScorePointer pointer;

    void Update()
    {
        ScoreTextUpdate();
    }

    private void ScoreTextUpdate()
    {
        scoreText.text = ("Score: " + pointer.score);
    }
}
