using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    bool active = false;

    void Start(){

        int ID =  PlayerPrefs.GetInt("LocalKey", 0);
        ChangeLocale(ID);
    }

    public void ChangeLocale(int localID){

        if(active == true)
            return;
        StartCoroutine(SetLocale(localID));
    }

    IEnumerator SetLocale(int localID)
    {
        
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = 
            LocalizationSettings.AvailableLocales.Locales[localID];
        
        PlayerPrefs.SetInt("LocalKey", localID);
        active = false;
    }
}
