using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


// �����ϴ� ���
// 1. ������ �����Ͱ� ����
// 2. �����͸� ���̽����� ��ȯ
// 3. ���̽��� �ܺο� ����

// �ҷ����� ���
// 1. �ܺο� ����� ���̽��� ������
// 2. ���̽��� ������ ���·� ��ȯ
// 3. �ҷ��� �����͸� ���

// using System.IO  -> �̰ɷ� ������ ��ǲ �ƿ�ǲ �Ѵ�.


[SerializeField]
public class player_data
{
    // �̸�, ����, ����, �������� ����
    public string name;
    public int level = 1;
    public int coin  = 100;
    public int item  =-1;

    public string times = "00/00/00";
    public int hour;
    public int min;
    public int second;
    public string stage = "���ʸ���";

    //public Transform player_pos;
    // json�� ��Ʈ �� �÷�Ʈ ��Ʈ�� �����͸� �����Ѵ�...
    // ��� �׳� ��Ʈ�� ������ �ҷ��ͼ� ���߿� �ν����̽� �����ŷ� �ٲ�����Ѵ�.

    // ���ڿ��� ��� ����� ���߿� Ŭ��(db�����ͺ��̽�)���� �񱳸� ���ָ� �ȴ�.

    public float pos_x ; // vector 3�� ����� ���� (0,0,0)  �̷��� ���ʿ����
    public float pos_y;
    public float pos_z;

    public string pos = "0/0/0";
    public string rotation ="0/0/0"; //�̷���
    public string inventory_item_list="1/2/3" ; //1/2/3
    public string job_type; 
    
    //split�� �ɰ��� ������ �ȴ�.
    /*
    public p_data(string _pos, string _rotation , string _inventory_item_list, string _job_type)
    {
        pos = _pos;
        rotation = _rotation;
        inventory_item_list = _inventory_item_list;
        job_type = _job_type;
    }*/
}
//public class items


public class data_manager : MonoBehaviour
{
    // �׻� �־���ϴϱ� �̱�������..
    //static�� ���� ����..
    public static data_manager instance;

    public player_data now_player_data = new player_data() ;

    public string path;
    //string file_name = "save";
    public int now_slot;


    

    public GameObject player;
    

    private void Awake()
    {
        #region �̱���
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        #endregion// �̷��� �ϸ� �ڵ��ٿ� ���� ������ ����.


        // ����Ƽ�� �˾Ƽ� ������ �������ش�. (������̰� �ǽô� ���� ������..)
        path = Application.persistentDataPath + "/" ;
        
    }
    private void Start()
    {
        print(path);
       
    }
    
    public void save_data()
    {
        // true�� ������ �� ������ �ȴ�.
        string data = JsonUtility.ToJson(now_player_data ,true);
        File.WriteAllText(path+ now_slot.ToString(), data);
    }
    public void load_data()
    {
        string data = File.ReadAllText(path + now_slot.ToString());
        now_player_data = JsonUtility.FromJson<player_data>(data);
    }

    public void data_clear()
    {
        now_slot = -1;
        now_player_data = new player_data();
    }

    
    public void creat_player()
    {
        string[] tmp_pos_array = now_player_data.pos.Split('/');
        //string[] tmp_ro_attay = now_player_data.rotation.Split("/");

        Vector3 tem_pos = new Vector3(float.Parse(tmp_pos_array[0]), float.Parse(tmp_pos_array[1]), float.Parse(tmp_pos_array[2]));
        //Vector3 tem_ro = new Vector3(float.Parse(tmp_ro_attay[0]), float.Parse(tmp_ro_attay[1]), float.Parse(tmp_ro_attay[2]));

        Instantiate(player, tem_pos, Quaternion.identity);
        player.GetComponent<player_move>();
    }

}
