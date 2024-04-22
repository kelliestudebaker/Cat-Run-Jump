using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Text level1;
    public Text level2;
    public Text level3;
    public Text level4;
    public Text level5;

    private int numberOfOptions = 5;
    private int selectedOption;

    public AudioSource source;
    public AudioClip clickSound;

    public Text[] lvlButtons;

    void Start()
    {
        source.clip = clickSound;
        source.Play();
        selectedOption = 1;
        level1.color = new Color32(255, 218, 0, 255);
        level2.color = new Color32(0, 0, 0, 255);
        level3.color = new Color32(0, 0, 0, 255);
        level4.color = new Color32(0, 0, 0, 255);
        level5.color = new Color32(0, 0, 0, 255);

        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                lvlButtons[i].enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && level2.enabled == true)
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > numberOfOptions) //If at end of list go back to top.
            {
                selectedOption = 1;
            }

            level1.color = new Color32(0, 0, 0, 255);
            level2.color = new Color32(0, 0, 0, 255);
            level3.color = new Color32(0, 0, 0, 255);
            level4.color = new Color32(0, 0, 0, 255);
            level5.color = new Color32(0, 0, 0, 255);

            switch (selectedOption) //Set the color to yellow to indicate which option you are on.
            {
                case 1:
                    level1.color = new Color32(255, 218, 0, 255);
                    break;
                case 2:
                    level2.color = new Color32(255, 218, 0, 255);
                    break;
                case 3:
                    level3.color = new Color32(255, 218, 0, 255);
                    break;
                case 4:
                    level4.color = new Color32(255, 218, 0, 255);
                    break;
                case 5:
                    level5.color = new Color32(255, 218, 0, 255);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && level2.enabled == true)
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 1) //If at end of list go back to top.
            {
                selectedOption = numberOfOptions;
            }

            level1.color = new Color32(0, 0, 0, 255);
            level2.color = new Color32(0, 0, 0, 255);
            level3.color = new Color32(0, 0, 0, 255);
            level4.color = new Color32(0, 0, 0, 255);
            level5.color = new Color32(0, 0, 0, 255);

            switch (selectedOption) //Set the color to yellow to indicate which option you are on.
            {
                case 1:
                    level1.color = new Color32(255, 218, 0, 255);
                    break;
                case 2:
                    level2.color = new Color32(255, 218, 0, 255);
                    break;
                case 3:
                    level3.color = new Color32(255, 218, 0, 255);
                    break;
                case 4:
                    level4.color = new Color32(255, 218, 0, 255);
                    break;
                case 5:
                    level5.color = new Color32(255, 218, 0, 255);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("Selected option: " + selectedOption);

            switch (selectedOption) //Set the color to yellow to indicate which option you are on.
            {
                case 1:
                    source.clip = clickSound;
                    source.Play();
                    SceneManager.LoadScene("03LEVEL1"); //Start Level 1.
                    break;
                case 2:
                    if (level2.enabled == true)
                    {
                        source.clip = clickSound;
                        source.Play();
                        SceneManager.LoadScene("04LEVEL2"); //Start Level 2.
                    }
                    break;
                case 3:
                    if (level3.enabled == true)
                    {
                        source.clip = clickSound;
                        source.Play();
                        SceneManager.LoadScene("05LEVEL3"); //Start Level 3.
                    }
                    break;
                case 4:
                    if (level4.enabled == true)
                    {
                        source.clip = clickSound;
                        source.Play();
                        SceneManager.LoadScene("06LEVEL4"); //Start Level 4.
                    }
                    break;
                case 5:
                    if (level5.enabled == true)
                    {
                        source.clip = clickSound;
                        source.Play();
                        SceneManager.LoadScene("07LEVEL5"); //Start Level 5.
                    }
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 0")) //If the esc button is pressed...
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //...go back to the previous scene.
        }
    }
}
