using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] PlayerSettings.Direction direction;
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

    //ブロックとの当たり判定から作る
    //当たって自分と同じ色だったらとって進む。違うなら少し戻る。
}
