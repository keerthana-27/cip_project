using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    private Animator anim;

    float lengthinZaxis = 7.6f;
    Vector3 lastposition;
    [SerializeField]
    Text scoreUI;
    [SerializeField]
    GameObject platform;
    [SerializeField]
    Transform firstobject;
    float _score = 0f;
    // Use this for initialization
    int score = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f, 0f, speed);
        lastposition = firstobject.transform.position;
        InvokeRepeating("Spawning", 0f, 0.3f);

    }
    private void ScoreUpdate()
    {

        _score += (5f * Time.deltaTime);
        score = Mathf.RoundToInt(_score);
        scoreUI.text = score.ToString();
    }
    private void Spawning()
    {
        GameObject _object = Instantiate(platform) as GameObject;
        int _random = Random.Range(0, 7);
        if (_random <= 3)
        {
            _object.transform.position = lastposition + new Vector3(0f, 0f, lengthinZaxis);
        }
        else
        {
            _object.transform.position = lastposition + new Vector3(0f, 0f, 9f);
        }
        lastposition = _object.transform.position;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(0f, 5f, 0f, ForceMode.Impulse);
            anim.Play("Jumping");
        }
        ScoreUpdate();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "water")
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        Debug.Log("Game is over");

    }
}
