using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public float speed;

    float x;
    float z;

    

    Rigidbody rigid;
    void Start()
    {
        
        rigid = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        Vector3 move_x = transform.right * x;
        Vector3 move_z = transform.forward * z;

        Vector3 _velocity = (move_x + move_z).normalized * speed * Time.deltaTime;
        rigid.MovePosition(transform.position + _velocity);

       
        
    }

    public void write_p_pos()
    {
        data_manager.instance.now_player_data.pos =
            (gameObject.transform.position.x + "/" +
            gameObject.transform.position.y + "/" +
            gameObject.transform.position.z).ToString();
    }
    
   
}
