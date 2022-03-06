using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float moveSpeed = 1f;
    float targetMoveSpeed = 3f;   
    private Rigidbody2D rigid2d;
    public Animator anim;
    private bool isAiming = false;
    private bool aimed = false;
    private Vector2 mousePosition = new Vector2();
    private Vector2 targetPosition = new Vector2(0, -3f);
    private Vector3 meteorDir;
    void Start()
    {
        // Cursor.visible = false;
        rigid2d = this.GetComponent<Rigidbody2D>();
        rigid2d.velocity = new Vector2(0, -moveSpeed);
        Animator anim = GetComponent<Animator>();
    }

    private void Update() {

        if (Input.GetButtonDown("Interact")){
            isAiming = !isAiming;
        }
        if (isAiming) {
            aimed = true;
            rigid2d.velocity = new Vector2(0,0);

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector2(mousePosition.x, targetPosition.y);
            meteorDir = new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y, 0).normalized;
            transform.eulerAngles = new Vector3(0,0, GetAngleFromVectorFloat(meteorDir));
            transform.position += meteorDir * targetMoveSpeed * Time.deltaTime;
        } else {
            if (aimed){
                transform.position += meteorDir * targetMoveSpeed * Time.deltaTime;
            }
        }

            
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        
        anim.SetTrigger("Explode");
        rigid2d.gravityScale = 0f;
        rigid2d.velocity = new Vector2(0,0);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
    public static float GetAngleFromVectorFloat(Vector3 dir){
        dir=dir.normalized;
        float n = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90;
        if (n < 0) {
            n += 360;
        }
        return n;
    }

}
