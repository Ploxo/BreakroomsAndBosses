using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour {

    public Tilemap groundTilemap;
    public Tilemap obstaclesTilemap;
    public bool isMoving = false;
    public bool isInteracting = false;
    public float movementSpeed = 4.0f;
    [SerializeField] Animator animator;

    [SerializeField] KeyCode interactKey = KeyCode.E;
    [SerializeField] GameObject interactor;
    [SerializeField] float interactorDistance;

    void Start () {
        animator.SetFloat("xDirection", 0);
        animator.SetFloat("yDirection", -1);
        animator.SetBool("isWalking", false);
    }
	
	void Update () {
        if (!isMoving && !isInteracting) {
            int xDirection = 0;
            int yDirection = 0;

            xDirection = (int)(Input.GetAxisRaw("Horizontal"));
            yDirection = (int)(Input.GetAxisRaw("Vertical"));

            if (xDirection != 0) {
                yDirection = 0;

                MoveInteractor(true, xDirection, interactorDistance);
            }
            else if (yDirection != 0)
            {
                MoveInteractor(false, yDirection, interactorDistance);

            }

            if (xDirection != 0 || yDirection != 0) {
                Move(xDirection, yDirection);
            } else {
               animator.SetBool("isWalking", false);
            }

            Interaction();
        }
    }

    void MoveInteractor (bool isHorizontal, int value, float distance)
    {
        if(isHorizontal)
        {
            interactor.transform.position = transform.position + Vector3.right * distance * value;
            Debug.Log("Indicator localePosition: " + interactor.transform.localPosition);
        }
        else
        {
            interactor.transform.position = transform.position + Vector3.up * distance * value;
            Debug.Log("Indicator localePosition: " + interactor.transform.localPosition);

        }


    }

    void Interaction ()
    {
        if (Input.GetKeyDown(interactKey))
        {
            interactor.GetComponent<Interaction>().isInteracting = true;
        }

        if (Input.GetKeyUp(interactKey))
        {
            interactor.GetComponent<Interaction>().isInteracting = false;
        }
    }

    void Move(int xDirection, int yDirection) {
        animator.SetFloat("xDirection", xDirection);
        animator.SetFloat("yDirection", yDirection);

        Vector2 startCell = transform.position;
        Vector2 targetCell = startCell + new Vector2(xDirection, yDirection);

        bool hasGroundTile = getCell(groundTilemap, targetCell) != null;
        bool hasObstacleTile = getCell(obstaclesTilemap, targetCell) != null;

        if (hasGroundTile && !hasObstacleTile) {
            StartCoroutine(Movement(targetCell));
        } else {
            animator.SetBool("isWalking", false);
        }
        
    }

    private IEnumerator Movement(Vector3 targetPosition) {
        isMoving = true;
        animator.SetBool("isWalking", true);
        float sqrRemainingDistance = (transform.position - targetPosition).sqrMagnitude;

        while (sqrRemainingDistance > 0){
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

            transform.position = newPosition;
            sqrRemainingDistance = (transform.position - targetPosition).sqrMagnitude;
            yield return null;
        }
        isMoving = false;
    }

    private TileBase getCell(Tilemap tilemap, Vector2 cellWorldPos) {
        return tilemap.GetTile(tilemap.WorldToCell(cellWorldPos));
    }

}
