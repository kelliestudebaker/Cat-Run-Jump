using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text option1;
    public Text option2;
    private int numberOfOptions = 2;
    private int selectedOption;

    void Start()
    {
        selectedOption = 1;
        option1.color = new Color32(255, 218, 0, 255);
        option2.color = new Color32(0, 0, 0, 255);
        Lives.numLives = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > numberOfOptions) //If at end of list go back to top.
            {
                selectedOption = 1;
            }

            option1.color = new Color32(0, 0, 0, 255);
            option2.color = new Color32(0, 0, 0, 255);

            switch (selectedOption) //Set the color to yellow to indicate which option you are on.
            {
                case 1:
                    option1.color = new Color32(255, 218, 0, 255);
                    break;
                case 2:
                    option2.color = new Color32(255, 218, 0, 255);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 1) //If at end of list go back to top.
            {
                selectedOption = numberOfOptions;
            }

            option1.color = new Color32(0, 0, 0, 255);
            option2.color = new Color32(0, 0, 0, 255);

            switch (selectedOption) //Set the color to yellow to indicate which option you are on.
            {
                case 1:
                    option1.color = new Color32(255, 218, 0, 255);
                    break;
                case 2:
                    option2.color = new Color32(255, 218, 0, 255);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("Option: " + selectedOption);

            switch (selectedOption) //Set the color to yellow to indicate which option you are on.
            {
                case 1:
                    SceneManager.LoadScene("01TitleScreen"); //Return to title screen.
                    break;
                case 2:
                    //Quit the game.
                    //UnityEditor.EditorApplication.isPlaying = false;
                    Application.Quit();
                    break;
            }
        }
    }
}
