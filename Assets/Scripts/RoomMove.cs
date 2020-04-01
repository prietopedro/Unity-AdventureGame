using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector3 playerChange;
    public Vector2 camMaxDif;
    public Vector2 camMinDif;
    private CameraMovement cam;
    public int room;
    //public bool needText;
    //public string placeName;
    //public GameObject text;
    //public Text placeText;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.smoothing = 0.1f;
            ClientSend.MoveRoom(room);
            ClientSend.PlayerMovement(playerChange, false);
            cam.minPosition = camMinDif;
            cam.maxPosition = camMaxDif;
            StartCoroutine(changeCamSmoothing());
            //other.transform.position += playerChange;
            //if (needText)
            //{
            //    StartCoroutine(placeNameCo());
            //}
        }
    }

    private IEnumerator changeCamSmoothing()
    {
        yield return new WaitForSeconds(1f);
        cam.smoothing = 1.0f;
    }

    //private IEnumerator placeNameCo()
    //{
    //    text.SetActive(true);
    //    placeText.text = placeName;
    //    yield return new WaitForSeconds(4f);
    //    text.SetActive(false);
    //}
}
