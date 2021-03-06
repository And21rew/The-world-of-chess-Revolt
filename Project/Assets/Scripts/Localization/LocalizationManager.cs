using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public void Ru()
    {
        string language = "Ru";
        PlayerPrefs.SetString("Language", language);
        gameObject.GetComponent<MainMenu>().CheckLocalization();
    }

    public void Eng()
    {
        string language = "Eng";
        PlayerPrefs.SetString("Language", language);
        gameObject.GetComponent<MainMenu>().CheckLocalization();
    }
}
