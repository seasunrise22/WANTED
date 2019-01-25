using UnityEngine;
using System.Collections;

public class Make_In_Parent : MonoBehaviour{
    void Start(){
        if(GameObject.Find("SlotA").transform.childCount == 0)
            transform.parent = GameObject.Find("SlotA").transform;
        else if(GameObject.Find("SlotB").transform.childCount == 0)
            transform.parent = GameObject.Find("SlotB").transform;
        else if(GameObject.Find("SlotC").transform.childCount == 0)
            transform.parent = GameObject.Find("SlotC").transform;
        else if(GameObject.Find("SlotD").transform.childCount == 0)
            transform.parent = GameObject.Find("SlotD").transform;
    }
}