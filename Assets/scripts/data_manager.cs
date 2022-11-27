using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


// 저장하는 방법
// 1. 저장할 데이터가 존재
// 2. 데이터를 제이슨으로 변환
// 3. 제이슨을 외부에 저장

// 불러오는 방법
// 1. 외부에 저장된 제이슨을 가져옴
// 2. 제이슨을 데이터 형태로 변환
// 3. 불러온 데이터를 사용

// using System.IO  -> 이걸로 파일을 인풋 아웃풋 한다.


[SerializeField]
public class player_data
{
    // 이름, 레벨, 코인, 착용중인 무기
    public string name;
    public int level = 1;
    public int coin  = 100;
    public int item  =-1;

    public string times = "00/00/00";
    public int hour;
    public int min;
    public int second;
    public string stage = "태초마을";

    //public Transform player_pos;
    // json은 인트 불 플로트 스트링 같은것만 지원한다...
    // 모두 그냥 스트링 값으로 불러와서 나중에 인스테이스 같은거로 바꿔줘야한다.

    // 문자열로 모두 만들고 나중에 클라스(db데이터베이스)에서 비교만 해주면 된다.

    public float pos_x ; // vector 3개 값모두 저장 (0,0,0)  이렇게 할필요없이
    public float pos_y;
    public float pos_z;

    public string pos = "0/0/0";
    public string rotation ="0/0/0"; //이렇게
    public string inventory_item_list="1/2/3" ; //1/2/3
    public string job_type; 
    
    //split로 쪼개서 넣으면 된다.
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
    // 항상 있어야하니까 싱글톤으로..
    //static은 정적 변수..
    public static data_manager instance;

    public player_data now_player_data = new player_data() ;

    public string path;
    //string file_name = "save";
    public int now_slot;


    

    public GameObject player;
    

    private void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        #endregion// 이렇게 하면 코드줄에 제목 넣을수 있음.


        // 유니티가 알아서 폴더를 생성해준다. (모바일이건 피시던 간에 ㅎㄷㄷ..)
        path = Application.persistentDataPath + "/" ;
        
    }
    private void Start()
    {
        print(path);
       
    }
    
    public void save_data()
    {
        // true를 넣으면 글 정렬이 된다.
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
