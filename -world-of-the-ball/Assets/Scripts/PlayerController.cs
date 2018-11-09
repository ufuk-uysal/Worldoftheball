using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
       
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (count >= 13)
        {
            winText.text = " Win!";

        }
    }
	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
            {
            other.gameObject.SetActive(false);
            count = count + 1;
            countText.text = "Count :" + count.ToString();
        }
    }
    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();
       
    }
}

