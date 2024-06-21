using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //プレイヤーの移動する力
    [SerializeField] public float moveSpeed = 100f;
    Rigidbody2D m_rb = default;
    [SerializeField] Camera cam;
    [SerializeField] GameObject handgun;
    [SerializeField] GameObject crossbow;
    [SerializeField] GameObject player;
    GameObject obj;
    [SerializeField] GameObject[] weaponPos;


    int weaponCounter = 0;   
    Vector2 movement;
    Vector2 mousePos;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();    
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //武器の召喚
        if (Input.GetKeyDown(KeyCode.G))
        {

            if(weaponCounter == i && i < weaponPos.Length)
            {
                obj = (GameObject)Instantiate(handgun, weaponPos[i].transform.position, Quaternion.identity);
                obj.transform.parent = player.transform;
                weaponCounter++;
                i++;
            }

        }

        if (Input.GetKeyDown(KeyCode.H))
        {

            if (weaponCounter == i && i < weaponPos.Length)
            {
                obj = (GameObject)Instantiate(crossbow, weaponPos[i].transform.position, Quaternion.identity);
                obj.transform.parent = player.transform;
                weaponCounter++;
                i++;
            }
        }
        }

    private void FixedUpdate()
    {
        //プレイヤーの移動
        m_rb.MovePosition(m_rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }


}
