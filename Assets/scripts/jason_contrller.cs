using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���� = https://youtu.be/-Myy_fRljo0
// 1. ������(�ڵ� = Ŭ��) �� ������ ��. -> ������ ������ ����
// 2. �� �����͸� json���� ��ȯ.(�ù� ���� ����)
// =======
// 1. json �� �ٽ� ������ �ڵ�� �ٲٴ� ���
// ���̽�(�ù�) -> ������ -> Ŭ��(�ڵ�)

class data
{
    public string nickname;
    public int level;
    public int coin;
    public bool skill_1;
    //��Ÿ ���...
}

public class jason_contrller : MonoBehaviour
{
    // ���ο� ��ü�� ����
    //data player = new data();
    data player = new data() { nickname = "wnsgk7654", level = 1, coin = 200, skill_1 = false };
    

    // Start is called before the first frame update
    void Start()
    {
        // �̷� ����� �ִ�.
        //player.nickname = "wnsgk7654";

        // 2. json ��ȯ
        string json_data =  JsonUtility.ToJson(player);

        print(json_data);

        // ���ڿ��� �ٽ� json���� �ٲ�
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
