using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelLocker : MonoBehaviour
{
    //Not the most efficient, but it works.
    public GameObject level1; //Level buttons
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public GameObject level6;
    public GameObject level7;
    public GameObject level8;

    private Text level1txt; //Level button's text components
    private Text level2txt;
    private Text level3txt;
    private Text level4txt;
    private Text level5txt;
    private Text level6txt;
    private Text level7txt;
    private Text level8txt;

    // Start is called before the first frame update
    void Start()
    {
        level1txt = level1.gameObject.transform.GetChild(0).GetComponent<Text>(); //Get the button's texts
        level2txt = level2.gameObject.transform.GetChild(0).GetComponent<Text>();
        level3txt = level3.gameObject.transform.GetChild(0).GetComponent<Text>();
        level4txt = level4.gameObject.transform.GetChild(0).GetComponent<Text>();
        level5txt = level5.gameObject.transform.GetChild(0).GetComponent<Text>();
        level6txt = level6.gameObject.transform.GetChild(0).GetComponent<Text>();
        level7txt = level7.gameObject.transform.GetChild(0).GetComponent<Text>();
        level8txt = level8.gameObject.transform.GetChild(0).GetComponent<Text>();

        level2.SetActive(PlayerPrefs.GetInt("1Complete", 0) > 0); //Set whether levels should be visible
        level3.SetActive(PlayerPrefs.GetInt("2Complete", 0) > 0);
        level4.SetActive(PlayerPrefs.GetInt("3Complete", 0) > 0);
        level5.SetActive(PlayerPrefs.GetInt("4Complete", 0) > 0);
        level6.SetActive(PlayerPrefs.GetInt("5Complete", 0) > 0);
        level7.SetActive(PlayerPrefs.GetInt("6Complete", 0) > 0);
        level8.SetActive(PlayerPrefs.GetInt("7Complete", 0) > 0);

        level1txt.text = "Level 1       Best Time: " + PlayerPrefs.GetFloat("lvl1T", 0f).ToString(); //Set level button's text to the level number and best time
        level2txt.text = "Level 2       Best Time: " + PlayerPrefs.GetFloat("lvl2T", 0f).ToString();
        level3txt.text = "Level 3       Best Time: " + PlayerPrefs.GetFloat("lvl3T", 0f).ToString();
        level4txt.text = "Level 4       Best Time: " + PlayerPrefs.GetFloat("lvl4T", 0f).ToString();
        level5txt.text = "Level 5       Best Time: " + PlayerPrefs.GetFloat("lvl5T", 0f).ToString();
        level6txt.text = "Level 6       Best Time: " + PlayerPrefs.GetFloat("lvl6T", 0f).ToString();
        level7txt.text = "Level 7       Best Time: " + PlayerPrefs.GetFloat("lvl7T", 0f).ToString();
        level8txt.text = "Level 8       Best Time: " + PlayerPrefs.GetFloat("lvl8T", 0f).ToString();
    }
}
