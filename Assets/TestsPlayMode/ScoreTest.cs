using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class ScoreTesting
{

    [Test]
    public void Test_de_l_environnement()
    {
        //context

        int value1 = 42;
        int value2 = 41;

        //action
        value2 ++;


        //assert
        Assert.AreEqual(value1, value2);

    }


    private ScoreManager scoreManager;


    [Test]
    public void Test_si_le_score_s_incremente()
    {

        //context
        GameObject gameObject = new GameObject();
        scoreManager = gameObject.AddComponent<ScoreManager>();

        UIManager uiManager = new UIManager();
        TextMeshProUGUI scoreField = new TextMeshProUGUI();
        uiManager.Initialize(scoreField);
        scoreManager.Initialize(uiManager);

        //action
        scoreManager.AddScore(41);
        scoreManager.AddScore(1);

        //assert
        Assert.AreEqual(42, scoreManager.GlobalScore);

    }

   
}
