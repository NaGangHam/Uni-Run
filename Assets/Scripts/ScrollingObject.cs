using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; // 이동 속도

    // Update is called once per frame
    void Update(){

        if (!GameManager.Instance.isGameover) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
