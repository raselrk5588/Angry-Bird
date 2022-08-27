using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public bool isMouseClick = false;

    public Rigidbody2D rb;
    public Rigidbody2D hook;

    public GameObject NextBall;

    public float waitTime = 0.15f;

    public float maxDragDistance = 2f;


    void Update()
    {

        if (isMouseClick)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;

            else
            {
                rb.position = mousePos;
            }

        }
    }
    private void OnMouseDown()
    {
        isMouseClick = true;
        rb.isKinematic = true;
    }
    private void OnMouseUp()
    {
        isMouseClick = false;
        rb.isKinematic = false;
        StartCoroutine(Relase());
    }

    IEnumerator Relase()
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(2f);
        if (NextBall != null)
        {
            NextBall.SetActive(true);
        }
        else
        {
            Enemy.EnemyIsAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Losser");
        }

    }
}
