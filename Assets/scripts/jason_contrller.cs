using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 참고 = https://youtu.be/-Myy_fRljo0
// 1. 데이터(코드 = 클라스) 를 만들어야 함. -> 저장할 데이터 생성
// 2. 그 데이터를 json으로 변환.(택배 상자 포장)
// =======
// 1. json 를 다시 원래의 코드로 바꾸는 방법
// 제이슨(택배) -> 조립도 -> 클라스(코드)

class data
{
    public string nickname;
    public int level;
    public int coin;
    public bool skill_1;
    //기타 등등...
}

public class jason_contrller : MonoBehaviour
{
    // 새로운 객체를 생성
    //data player = new data();
    data player = new data() { nickname = "wnsgk7654", level = 1, coin = 200, skill_1 = false };
    

    // Start is called before the first frame update
    void Start()
    {
        // 이런 방법도 있다.
        //player.nickname = "wnsgk7654";

        // 2. json 변환
        string json_data =  JsonUtility.ToJson(player);

        print(json_data);

        // 문자열이 다시 json으로 바꿈
        data player2 = JsonUtility.FromJson<data>(json_data);
        print(player2.nickname);
        print(player2.level);
        print(player2.coin);
        print(player2.skill_1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
