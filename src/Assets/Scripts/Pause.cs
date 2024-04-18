using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;
    public static bool isPaused = false;

    public Text option1;
    public Text option2;
    public Text option3;
    private int numberOfOptions = 3;
    private int selectedOption;

    public GameObject audioIsOn;
    public GameObject audioIsOff;

    void Start()
    {
        selectedOption = 1;
        option1.color = new Color32(255, 218, 0, 255);
        option2.color = new Color32(0, 0, 0, 255);
        option3.color = new Color32(0, 0, 0, 255);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); //If the game is paused and the escape key is pressed, then resume the game.
            }
            else
            {
                PauseGame(); //Pause the game if the escape key is pressed.
            }
        }

        if (isPaused)
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
                option3.color = new Color32(0, 0, 0, 255);

                switch (selectedOption) //Set the color to yellow to indicate which option you are on.
                {
                    case 1:
                        option1.color = new Color32(255, 218, 0, 255);
                        break;
                    case 2:
                        option2.color = new Color32(255, 218, 0, 255);
                        break;
                    case 3:
                        option3.color = new Color32(255, 218, 0, 255);
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
                option3.color = new Color32(0, 0, 0, 255);

                switch (selectedOption) //Set the color to yellow to indicate which option you are on.
                {
                    case 1:
                        option1.color = new Color32(255, 218, 0, 255);
                        break;
                    case 2:
                        option2.color = new Color32(255, 218, 0, 255);
                        break;
                    case 3:
                        option3.color = new Color32(255, 218, 0, 255);
                        break;
                }
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
            {
                Debug.Log("Option: " + selectedOption);

                switch (selectedOption) //Set the color to yellow to indicate which option you are on.
                {
                    case 1: //Resume Game
                        ResumeGame(); //Resume the game.
                        break;
                    case 2: //Return to Menu
                        ResumeGame(); //Make sure to unpause the game when returning to menu.
                        CatController.health = 3; //Reset the health back to 3.
                        SceneManager.LoadScene("01TitleScreen"); //Go to the title screen.
                        break;
                    case 3:
                        if (AudioListener.volume == 0) //If the audio is off and this option is selected,
                        {
                            AudioListener.volume = 1; //turn the audio on.
                            audioIsOn.SetActive(true); //Show the word "On",
                            audioIsOff.SetActive(false); //and hide the word "Off".
                        }
                        else if (AudioListener.volume == 1) //If the audio is on and this option is selected,
                        {
                            AudioListener.volume = 0; //turn the audio off.
                            audioIsOff.SetActive(true); //Show the word "Off",
                            audioIsOn.SetActive(false); //and hide the word "On".
                        }
                        break;
                }
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        PausePanel.SetActive(true); //Show the pause panel if the game is paused.
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        PausePanel.SetActive(false); //Hide the pause panel if the game is resumed.
    }
}
