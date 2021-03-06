using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : RaycastPlatformController
{
    public LayerMask passengerMask;
    public Vector2 move;
    public float platformSpeed = 2f;
    public float platformMoveeight = 3f;

    public List<PassengerMovement> passengerMovement;
   public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRaycastOrigins();
        //float newY = Mathf.Sin(Time.time * speed) * height + pos.y;

        Vector2 velocity = move * Time.deltaTime ;
        move.y = Mathf.Sin(Time.time ) * platformMoveeight ;
        CalculatePassengerMovement(velocity);
        MovePassengers(true);
        //transform.position = new Vector2(move.x, newY);
        transform.Translate(velocity);
        MovePassengers(false);
    }


    void MovePassengers(bool beforeMovePlatform) {
        foreach(PassengerMovement passenger in passengerMovement) {
            if(passenger.moveBeforePlatform == beforeMovePlatform) {
                passenger.transform.GetComponent<RayCast2DController>().Move(passenger.velocity, passenger.standingOnPlatform);
            }
        }
    }

    void CalculatePassengerMovement(Vector2 velocity) {
        HashSet<Transform> movedPassengers = new HashSet<Transform>();
        passengerMovement = new List<PassengerMovement>();

        float directionX = Mathf.Sign(velocity.x);
        float directionY = Mathf.Sign(velocity.y);

        if (velocity.y != 0) {
            float rayLength = Mathf.Abs(velocity.y) + skinWidth;

            for (int i = 0; i < verticalRayCount; i++) {
                Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
                rayOrigin += Vector2.right * (verticalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, passengerMask);

                if (hit) {
                    if (!movedPassengers.Contains(hit.transform)) {
                        movedPassengers.Add(hit.transform);
                        float pushX = (directionY == 1) ? velocity.x : 0;
                        float pushY = velocity.y - (hit.distance + skinWidth) * directionY;

                        passengerMovement.Add(new PassengerMovement(hit.transform, new Vector2(pushX, pushY), directionY == 1, true));
                    }
                }
            }

        }
        if (velocity.x != 0) {
            float rayLength = Mathf.Abs(velocity.y) + skinWidth;

            for (int i = 0; i < verticalRayCount; i++) {
                Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
                rayOrigin += Vector2.right * (verticalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, passengerMask);

                if (hit) {
                    if (!movedPassengers.Contains(hit.transform)) {
                        movedPassengers.Add(hit.transform);
                        float pushX = velocity.x - (hit.distance + skinWidth) * directionX;
                        float pushY = 0;

                        passengerMovement.Add(new PassengerMovement(hit.transform, new Vector2(pushX, pushY), false, true));
                    }
                }

            }
        }
        // passenger on top of a horizontally or downward moving 
        if(directionY == -1 || velocity.y == 0 && velocity.x != 0) {
            float rayLength = skinWidth * 1.2f;

            for (int i = 0; i < verticalRayCount; i++) {
                Vector2 rayOrigin =  raycastOrigins.topLeft + Vector2.right * (verticalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, passengerMask);

                if (hit) {
                    if (!movedPassengers.Contains(hit.transform)) {
                        movedPassengers.Add(hit.transform);
                        float pushX = velocity.x;
                        float pushY = velocity.y;

                        passengerMovement.Add(new PassengerMovement(hit.transform, new Vector2(pushX, pushY), true, false));
                    }
                }
            }
        }

    }

    public struct PassengerMovement {
        public Transform transform;
        public Vector2 velocity;
        public bool standingOnPlatform;
        public bool moveBeforePlatform;

        public PassengerMovement(Transform _transform, Vector2 _velocity, bool _standingOnPlatform, bool _moveBeforePlatform) {
            transform = _transform;
            velocity = _velocity;
            standingOnPlatform = _standingOnPlatform;
            moveBeforePlatform = _moveBeforePlatform;
        }

    }

}
