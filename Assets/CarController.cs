using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const float SPEED_MULTIPLIER = 10f;
    public Rigidbody rb;
    public Transform visual;
    [SerializeField] private float forwardAccel;
    [SerializeField] private float reverseAccel;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float turnStrength;
    private float gravityForce = 10f;
    private float liftForce = 25f;
    public bool grounded;

    [SerializeField] public GameObject back;

    private float dragOnGround = 3f;

    private float speedInput, turnInput;
    // Start is called before the first frame update
    void Start()
    {
        rb.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0f;
        if(Input.GetAxis(VERTICAL) > 0){
            speedInput = Input.GetAxis(VERTICAL) * forwardAccel * SPEED_MULTIPLIER;
        }else if(Input.GetAxis(VERTICAL) < 0){
            speedInput = Input.GetAxis(VERTICAL) * reverseAccel * SPEED_MULTIPLIER;
        }

        turnInput = Input.GetAxis(HORIZONTAL);
        // if(grounded){
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0f));
        // }

        visual.position = rb.transform.position;
    }

    private void FixedUpdate(){
        

        if(grounded){
            rb.drag = dragOnGround;
        }else{
            rb.drag = 0.1f;
            speedInput /= 20f;
            rb.AddForce(Vector3.up * -gravityForce);
        }

        if(Mathf.Abs(speedInput) > 0){
            rb.AddForce(transform.forward * speedInput);
        }

        if (Input.GetKey(KeyCode.Space)){
            rb.AddForce(Vector3.up * liftForce);
        }

        if (Input.GetKey(KeyCode.LeftShift)){
            rb.AddForce(Vector3.up * -liftForce);
        }
        
        
    }

}
