using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type {ScoreUp = 0, ScoreDown, Jump}
    public Type type;


    private void Update()
    {
        transform.Rotate(5*Time.deltaTime,25*Time.deltaTime,0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(type ==Type.ScoreUp || type ==Type.ScoreDown)
            {
                GameManager.instance.Score((int)type);
                
            }
            else if(type ==Type.Jump)
            {
                Player player = other.GetComponent<Player>();
                player.JumpUp();
            }



            Destroy(gameObject);
        }
    }


}
