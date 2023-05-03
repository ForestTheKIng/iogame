using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class  ItemHandler: NetworkBehaviour
{
    public Item[] items;
    public int itemIndex;
    private int _previousItemIndex = -1;

    public Rigidbody2D rb;
    public Camera cam;
    
    private Vector2 _move;
    private Vector2 _mousePos;   

    public Animator animator;
    private float _moveSpeed;
    
    
    private void OnTriggerEnter2D(Collider2D other) {
        // attack code
    }
    
    private void EquipItem(int index){

        if (index == _previousItemIndex){
            return;
        }

        itemIndex = index;

        items[itemIndex].itemGameObject.SetActive(true);
        if (_previousItemIndex != -1){
            items[_previousItemIndex].itemGameObject.SetActive(false);
        }
        _previousItemIndex = itemIndex;
        
        // if (pv.IsMine){
        //     Hashtable hash = new Hashtable();
        //
        //     hash.Add("itemIndex", itemIndex);
        //     PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        // }
    }
    
    // Update is called once per frame
    private void Update()
    {
        _move.x = Input.GetAxisRaw("Horizontal");
        _move.y = Input.GetAxisRaw("Vertical");
    
        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        for (int i = 0; i < items.Length; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString())){
                EquipItem(i);
                break;
            }
        }
        
        if (Input.GetMouseButtonDown(0)){
            items[itemIndex].Use();
        }
    
    }
    
    

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _move * ((MeleeInfo)items[itemIndex].itemInfo).moveSpeed * Time.fixedDeltaTime);
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxisRaw("Horizontal") * ((MeleeInfo)items[itemIndex].
            itemInfo).moveSpeed) + Mathf.Abs(Input.GetAxisRaw("Vertical") *((MeleeInfo)items[itemIndex].itemInfo)
            .moveSpeed));

        Vector2 lookDir = _mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y ,lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}