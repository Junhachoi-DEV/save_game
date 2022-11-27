using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class select : MonoBehaviour
{
    public GameObject creat;
    public Text[] slot_text;
    public Text new_player_name;

    bool[] save_file = new bool[3];


    private void Start()
    {
        //���Ժ��� ����� �����Ͱ� �����ϴ��� �Ǵ�.
        for(int i=0; i<3; i++)
        {
            if(File.Exists(data_manager.instance.path + $"{i}"))
            {
                save_file[i] = true;
                data_manager.instance.now_slot = i;
                data_manager.instance.load_data();
                slot_text[i].text =
                    data_manager.instance.now_player_data.name + "  /  "
                    + data_manager.instance.now_player_data.stage + "  /  "
                    + data_manager.instance.now_player_data.times;
                    
            }
            else
            {
                slot_text[i].text = " ������� ";
            }
        }
        data_manager.instance.data_clear();
    }

    public void slot(int num)
    {
        data_manager.instance.now_slot = num;

        // 1.����� �����Ͱ� ������
        if (save_file[num])
        {
            // 2.����� �����Ͱ� ������ => ����� ���� ������ �Ѿ
            data_manager.instance.load_data();
            go_game();
        }
        else
        {
            creat_slots();
        }
    }
    public void creat_slots()
    {
        creat.gameObject.SetActive(true);
    }

    public void go_game()
    {
        if (!save_file[data_manager.instance.now_slot])
        {
            data_manager.instance.now_player_data.name = new_player_name.text;

            data_manager.instance.save_data();
        }
        SceneManager.LoadScene(1);
    }
}
