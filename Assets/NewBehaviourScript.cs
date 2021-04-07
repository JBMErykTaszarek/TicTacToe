using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Button button, regButton;
    public Sprite Mark_X;
    public Sprite Mark_0;
    public Sprite Background;
    public Sprite NONE;
    public Text WinText;
    public bool isBot = false;
    public string[] board = {"n","n","n",
                             "n","n","n",
                             "n","n","n"};
    public string turn = "X";
    
    

    public void UpdateGame(int number)
    {
     
        
            if (turn == "X")
            {
                //board[number] = "X";
                //turn = "O";
                if (!isBot)
                {
                board[number] = "X";
                turn = "O";
                }
                else
                {
                board[number] = "X";
                if (CheckWin() == "InGame")
                {
                    int index = Array.IndexOf(board, "n");
                    board[index] = "O";
                    button = GameObject.Find("Button" + index).GetComponent<Button>();
                    button.image.overrideSprite = Mark_0;
                }
                
                
                //turn = "X";
                }
            }
            else
            {
                if (!isBot)
                {
                board[number] = "O";
                turn = "X";
                }
                else
                {
                board[number] = "0";
                if (CheckWin() == "InGame")
                {
                    int index = Array.IndexOf(board, "n");
                    board[index] = "X";
                    button = GameObject.Find("Button" + index).GetComponent<Button>();
                    button.image.overrideSprite = Mark_X;
                }
                
                
                //turn = "O";
                }
                
            }

        WinText.text = turn + " on move";


        if (CheckWin() == "Win")
        {
            regButton = GameObject.Find("RegameButton").GetComponent<Button>();
            regButton.image.color = Color.white;
            Text regText = GameObject.Find("regText").GetComponent<Text>();
            regText.text = "Play Again";
            if (isBot)
            {
                WinText.text = turn + " Won";
            }
            else
            {
                if (turn == "X")
                {
                    WinText.text = "O Won";
                }
                else
                {
                    WinText.text = "X Won";
                }
            }
            
            //turn == "X" ? WinText.text = "O Won" : WinText.text = "X Won";
        }
        if (CheckWin() == "Draw")
        {
            regButton = GameObject.Find("RegameButton").GetComponent<Button>();
            regButton.image.color = Color.white;
            Text regText = GameObject.Find("regText").GetComponent<Text>();
            regText.text = "Play Again";

            WinText.text = "Draw";
        }
    }
  
    public void oc(string number)
    {
        button = GameObject.Find("Button"+number).GetComponent<Button>();
        if (turn == "X")
        {
            button.image.overrideSprite = Mark_X;
        }
        else
        {
            button.image.overrideSprite = Mark_0;
        }
        button.GetComponent<Image>().color = new Color(255, 255, 255);
        //button.interactable = false;
 
        
    }
    public string CheckWin()
    {
        
            if (board[0] == board[1] && board[1] == board[2] && board[0] != "n" ||
                board[0] == board[3] && board[3] == board[6] && board[0] != "n" ||
                board[6] == board[7] && board[7] == board[8] && board[8] != "n" ||
                board[2] == board[5] && board[5] == board[8] && board[8] != "n" ||
                board[1] == board[4] && board[4] == board[7] && board[7] != "n" ||
                board[3] == board[4] && board[4] == board[5] && board[5] != "n" ||
                board[2] == board[4] && board[4] == board[6] && board[6] != "n" ||
                board[0] == board[4] && board[4] == board[8] && board[8] != "n")
            {
                Debug.Log(turn + " Wins");
                return "Win";
            }

        if (board.Contains("n"))
        {
            Debug.Log("ingame");
            return "InGame";
        }
        else
        {
            Debug.Log("draw");
            return "Draw";
        }
    }
    public void Refresh()
    {
        for (int i = 0; i < 9; i++)
        {
            board[i] = "n";
            button = GameObject.Find("Button" + i).GetComponent<Button>();
            button.image.overrideSprite = NONE;
        }
        regButton = GameObject.Find("RegameButton").GetComponent<Button>();
        regButton.image.color = new Color32(13, 26, 87, 255);
        Text regText = GameObject.Find("regText").GetComponent<Text>();
        regText.text = "";
        WinText.text = turn + " on move";
    }

    public void ChangeBot()
    {
        Text BotText = GameObject.Find("BotText").GetComponent<Text>();
        Button BotButton = GameObject.Find("BotButton").GetComponent<Button>();
        if (isBot)
        {
            isBot = false;
            BotText.text = "Bot off";
            BotButton.image.color = new Color32(87, 87, 87, 255);
        }
        else
        {
            isBot = true;
            BotText.text = "Bot on";
            BotButton.image.color = Color.white;
        }
    }
    
}
