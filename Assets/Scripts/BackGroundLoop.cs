using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    float width; // 배경의 가로 길이

    // Start is called before the first frame update
    void Awake(){

        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
        
    }

    // Update is called once per frame
    void Update(){

        if(transform.position.x <= -width) {

            Reposition();
        
        }
        
    }

    private void Reposition() {
        
        Vector2 offset = new Vector2 (width * 2f, 0);
        transform.position = (Vector2) transform.position + offset;

    }

}
