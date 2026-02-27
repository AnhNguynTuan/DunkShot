using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallState
{
    Floating,
    Landing
}
public class Ball : MonoBehaviour
{
    public BallState currentState;
    public Rigidbody2D rb;
    public float shootPower = 0.5f;
    private Vector3 startDragPos;
    private Vector3 currentDragPos;
    private Vector3 endDragPos;
    private float maxDragDistance = 2f;
    private bool isDragging;
    public LineRenderer line;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
        isDragging = false;
        currentState = BallState.Landing;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if(currentState == BallState.Landing) DragAndShoot();
    }
    public void SetState(BallState newState)
    {
        currentState = newState;
    }
    public void DragAndShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            startDragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (isDragging)
        {
            currentDragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dragVector = currentDragPos - startDragPos;
            dragVector = Vector3.ClampMagnitude(dragVector, maxDragDistance);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position - dragVector);
            //Trong khi dragging thi net se dan ra theo huong ban
            //Ro se rotate
        }
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Shoot();
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, Vector3.zero);
            //Sau khi ban se chay Animation o chinh ball
            isDragging = false;
            currentState = BallState.Floating;
        }
    }
    public void Shoot()
    {
        endDragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shootDirection = startDragPos - endDragPos;
        shootDirection = Vector3.ClampMagnitude(shootDirection, maxDragDistance); // gioi han luc ban
        Vector3 force = shootDirection * shootPower;
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    //Force deadzone (neu luc qua nho thi se khong ban)
    //Khi vat cham vao cac do vat thi se bat len
    //Khi cham vat the thi se chay animation bat lai
}
