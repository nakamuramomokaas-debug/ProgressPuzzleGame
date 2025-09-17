using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] PlayerSettings.Direction direction;
    [SerializeField] ColorSettings.ColorType colorType;
    Rigidbody2D rb;
    int speed = 100;
    bool isMove = false;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isMove) MoveDirection();
    }

    // クリックされたら進む
    public void OnPointerClick(PointerEventData eventData)
    {
        isMove = true;
    }

    void MoveDirection()
    {
        switch (direction)
        {
            case PlayerSettings.Direction.Down:
                rb.velocity = -transform.up*speed;
                break;
            case PlayerSettings.Direction.Left:
                rb.velocity = -transform.right*speed;
                break;
            default:
                break;
        }
    }

    //違う色のブロックに当たったら触れない位置まで戻る処理から。
    //プレイヤー同士が当たった時も同じ処理になる。
    void StopMove()
    {
        isMove = false;
        rb.velocity = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CubeItem"))
        {
            ColorSettings.ColorType oColor = other.GetComponent<CubeController>().ColorType();
            if(colorType == oColor) 
            {
                other.gameObject.SetActive(false);
            }
            else
            {
                StopMove();
                Debug.Log("違う色のブロックにあたった");
            } 
        }
    }
}
