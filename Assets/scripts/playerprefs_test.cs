using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerprefs_test : MonoBehaviour
{
    public InputField input_name;
    public InputField input_age;
    public InputField input_height;


    public void _save()
    {
        PlayerPrefs.SetString("name", input_name.text);
        PlayerPrefs.SetInt("age", int.Parse(input_age.text));
        PlayerPrefs.SetFloat("height", float.Parse(input_height.text));
    }
    public void _load()
    {
        if (PlayerPrefs.HasKey("name"))
        {
            input_name.text = PlayerPrefs.GetString("name");
            input_age.text = PlayerPrefs.GetInt("age").ToString();
            input_height.text = PlayerPrefs.GetFloat("height").ToString();
        }
    }
}
