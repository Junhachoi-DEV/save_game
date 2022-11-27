using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class game : MonoBehaviour
{

    public Text Name;
    public Text level;
    public Text coin;

    public GameObject[] items;

    float _seconds;
    int _min;
    int _hour;
    string str_ttttt;

    string stages;


    void Start()
    {
        Name.text += data_manager.instance.now_player_data.name;
        level.text += data_manager.instance.now_player_data.level.ToString();
        coin.text += data_manager.instance.now_player_data.coin;
        item_setting(data_manager.instance.now_player_data.item);
        //data_manager.instance.now_player_data.time = DateTime.Now.ToString("HH:mm:ss"); 현재시간
        _hour += data_manager.instance.now_player_data.hour;
        _min += data_manager.instance.now_player_data.min;
        _seconds += data_manager.instance.now_player_data.second;
        data_manager.instance.creat_player();
    }
    void Update()
    {
        _seconds += Time.deltaTime;
        str_ttttt = string.Format("{0:D2}:{1:D2}:{2:D2}", _hour, _min, (int)_seconds);
        if((int)_seconds > 59)
        {
            _seconds = 0;
            _min++;
        }
        if(_min > 59)
        {
            _min = 0;
            _hour++;
        }
        //print((int)_seconds);
        print(str_ttttt);
    }
    
    

    public void Level_up()
    {
        data_manager.instance.now_player_data.level++;
        level.text ="레벨:" + data_manager.instance.now_player_data.level.ToString();
    }
    public void Coin_up()
    {
        data_manager.instance.now_player_data.coin += 100;
        coin.text ="코인:" + data_manager.instance.now_player_data.coin;
    }
    public void Save()
    {
        data_manager.instance.now_player_data.hour += _hour;
        data_manager.instance.now_player_data.min += _min;
        data_manager.instance.now_player_data.second += (int)_seconds;
        data_manager.instance.now_player_data.times = str_ttttt;

        player_move p_Move = FindObjectOfType<player_move>();
        p_Move.write_p_pos();
        data_manager.instance.save_data();
    }

    public void item_setting(int number)
    {
        for(int i =0; i<items.Length; i++)
        {
            if(number == i)
            {
                items[i].SetActive(true);
                data_manager.instance.now_player_data.item = number;
            }
            else
            {
                items[i].SetActive(false);
            }
        }
    }
    
}
