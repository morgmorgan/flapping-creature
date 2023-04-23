using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject replay_button;
    public GameObject menu_button;
    public TextMeshProUGUI score_tmp;

    public bool game_over = false;

    int score = 0;

    private void Awake()
    {
        replay_button.SetActive(false);
        menu_button.SetActive(false);
    }

    public void addPoint()
    {
        Debug.Log("Scored point");
        score++;
        score_tmp.text = IntToRoman(score);
    }

    public void gameOver()
    {
        replay_button.SetActive(true);
        menu_button.SetActive(true);
        game_over = true;
    }
    public void goToMenu()
    {
        SceneManager.LoadScene(sceneName: "startMenu");
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public string IntToRoman(int num)
    {
        return convertRoman(num / 1000, 4) + convertRoman((num % 1000) / 100, 3) + convertRoman((num % 100) / 10, 2) + convertRoman(num % 10, 1);
    }
    public string convertRoman(int digit, int placeValue)
    {
        var myDict = new Dictionary<int, String> {
                        { 1000,"m" }, { 900,"cm" }, { 500,"d" }, { 400,"cd" },
                        { 100,"c" }, { 90,"xc" }, { 50,"l" }, { 40,"xl" },
                        { 10,"x" }, { 9,"ix" }, { 5,"v" }, { 4,"iv" }, { 1,"i" }
                    };
        string res = "";
        switch (placeValue)
        {
            case 4:
                res = repeat(myDict[1000], digit);
                break;
            case 3:
                if (digit >= 1 && digit < 4) res += repeat(myDict[100], digit);
                else if (digit == 4) res += myDict[400];
                else if (digit >= 5 && digit < 9) res += myDict[500] + repeat(myDict[100], (digit - 5));
                else if (digit == 9) res += myDict[900];
                break;
            case 2:
                if (digit >= 1 && digit < 4) res += repeat(myDict[10], digit);
                else if (digit == 4) res += myDict[40];
                else if (digit >= 5 && digit < 9) res += myDict[50] + repeat(myDict[10], (digit - 5));
                else if (digit == 9) res += myDict[90];
                break;
            case 1:
                if (digit >= 1 && digit < 4) res += repeat(myDict[1], digit);
                else if (digit == 4) res += myDict[4];
                else if (digit >= 5 && digit < 9) res += myDict[5] + repeat(myDict[1], (digit - 5));
                else if (digit == 9) res += myDict[9];
                break;
        }
        return res;
    }
    public string repeat(String repeatVal, int num)
    {
        String ret = "";
        while (num-- > 0) ret += repeatVal;
        return ret;
    }
}
