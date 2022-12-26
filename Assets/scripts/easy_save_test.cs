using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class easy_save_test : MonoBehaviour
{
    //https://docs.moodkie.com/easy-save-3/getting-started/ �������̺� ����Ʈ

    public InputField input_f;

    public Text test_text;
    

    public void _save()
    {
        var value = int.Parse(input_f.text); //parse �� �Ľ��̴�.(���ڿ���)
        ES3.Save("my_int", value);
    }
    public void _load()
    {
        var value = ES3.Load("my_int", 0);
        test_text.text = value.ToString();
    }
}
