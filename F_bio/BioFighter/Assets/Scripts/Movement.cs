using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rigid;

    public float speed =1f;

    Ray ray;
    RaycastHit hit;

    public GameObject robot;

    float zAxe;
    public float timeTakenDuringLerp = 1f;
    public float rotationSpeed = 2.4f;
    private float journeyLength;
    private float startTime;
    private float timeStartedLerping;
    private float currentRotationAngle;
    private float z_rotationAngle;
    private bool isLerping;
    private bool flipLeft;
    private bool flipRight;
    private bool rotateUpRight;
    private bool rotateDownRight;
    private bool rotateUpLeft;
    private bool rotateDownLeft;
    
    Quaternion rotate;

    Vector3 currentRobotPosition;
    Vector3 finalPosition;



    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        ray = new Ray(transform.position, transform.right);
        zAxe = robot.transform.position.z;
        currentRobotPosition = robot.transform.position;
        currentRotationAngle = robot.transform.localEulerAngles.y;
        z_rotationAngle = robot.transform.localEulerAngles.z;
        print(currentRotationAngle);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {    
            Ray r2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;

            if (Physics.Raycast(r2, out hit))
            {
                Vector3 newPos = hit.point;
                finalPosition = new Vector3(newPos.x,newPos.y,zAxe);

                StartLerping();
            }         
        } 
    }

    private void StartLerping()
    {
        isLerping = true;
        timeStartedLerping = Time.time;
        currentRobotPosition = robot.transform.position;
        currentRotationAngle = robot.transform.localEulerAngles.y;
        float xFinalPosition = finalPosition.x;
        float xCurrentPosition = currentRobotPosition.x;
        float yFinalPosition = finalPosition.y;
        float yCurrentPosition = currentRobotPosition.y;
        if(xFinalPosition < xCurrentPosition)
        {
            if (currentRotationAngle > 170)
            {
                flipLeft = true;
                flipRight = false;

                if (yFinalPosition > yCurrentPosition)
                {
                    rotateUpLeft = true;
                    rotateDownLeft = false;
                    rotateDownRight = false;
                    rotateUpRight = false;
                }
                if (yFinalPosition < yCurrentPosition)
                {
                    rotateUpLeft = false;
                    rotateDownLeft = true;
                    rotateDownRight = false;
                    rotateUpRight = false;
                }
            }
            else
            {
                flipRight = false;
                flipLeft = false;
                if (yFinalPosition > yCurrentPosition)
                {
                    rotateUpLeft = true;
                    rotateDownLeft = false;
                    rotateDownRight = false;
                    rotateUpRight = false;
                }
                if (yFinalPosition < yCurrentPosition)
                {
                    rotateUpLeft = false;
                    rotateDownLeft = true;
                    rotateDownRight = false;
                    rotateUpRight = false;
                }
            }

        }   
        if(xFinalPosition > xCurrentPosition)
        {
            if (currentRotationAngle < 180)
            {
                flipRight = true;
                flipLeft = false;
                if (yFinalPosition > yCurrentPosition)
                {
                    rotateUpLeft = false;
                    rotateDownLeft = false;
                    rotateDownRight = false;
                    rotateUpRight = true;
                }
                if (yFinalPosition < yCurrentPosition)
                {
                    rotateUpLeft = false;
                    rotateDownLeft = false;
                    rotateDownRight = true;
                    rotateUpRight = false;
                }
            }
            else
            {
                flipRight = false;
                flipLeft = false;
                if (yFinalPosition > yCurrentPosition)
                {
                    rotateUpLeft = false;
                    rotateDownLeft = false;
                    rotateDownRight = false;
                    rotateUpRight = true;
                }
                if (yFinalPosition < yCurrentPosition)
                {
                    rotateUpLeft = false;
                    rotateDownLeft = false;
                    rotateDownRight = true;
                    rotateUpRight = false;
                }
            }
                
        }
        print("yFinalPosition " + yFinalPosition);
        print("yCurrentPosition" + yCurrentPosition);
        print("xFinalPosition " + xFinalPosition);
        print("xCurrentPosition" + xCurrentPosition);

    }

    private void FixedUpdate()
    {
        if (isLerping)
        {
            float timeSinceStarted = Time.time - timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
            robot.transform.position = Vector3.Lerp(currentRobotPosition, finalPosition, percentageComplete);
            if (percentageComplete >= 1f)
            {
                isLerping = false;
            }
            if (flipRight)
            {
                robot.transform.rotation = Quaternion.Slerp(Quaternion.Euler(new Vector3(0, 0, 0)), Quaternion.Euler(new Vector3(0, 180, 0)), percentageComplete);
            }
            if (flipLeft)
            {
                robot.transform.rotation = Quaternion.Slerp(Quaternion.Euler(new Vector3(0, 180, 0)), Quaternion.Euler(new Vector3(0, 0, 0)), percentageComplete);
            }
            if (rotateUpRight && flipLeft)
            {
                robot.transform.rotation = Quaternion.Slerp(Quaternion.Euler(new Vector3(0, 180, 0)), Quaternion.Euler(new Vector3(0, 0, -45)), percentageComplete*rotationSpeed);
            }
            

        }
    }


}
