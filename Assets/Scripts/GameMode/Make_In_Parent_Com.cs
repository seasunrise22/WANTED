using UnityEngine;
using System.Collections;

public class Make_In_Parent_Com : MonoBehaviour{
    void Start(){
		if(GameObject.Find("Com_SlotA").transform.childCount == 0)
			transform.parent = GameObject.Find("Com_SlotA").transform;
		else if(GameObject.Find("Com_SlotB").transform.childCount == 0)
			transform.parent = GameObject.Find("Com_SlotB").transform;
		else if(GameObject.Find("Com_SlotC").transform.childCount == 0)
			transform.parent = GameObject.Find("Com_SlotC").transform;
		else if(GameObject.Find("Com_SlotD").transform.childCount == 0)
			transform.parent = GameObject.Find("Com_SlotD").transform;
    }
}