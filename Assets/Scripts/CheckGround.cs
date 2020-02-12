using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public float rayDistance = 1.5f;
    private GameObject movingObject;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayDistance))
        {
            if (hit.collider.tag == "movingObject")
            {
                if (movingObject == null || hit.collider.gameObject != movingObject)
                {
                    transform.parent = hit.collider.transform;
                    movingObject = hit.collider.gameObject;
                }
            }
            else if(movingObject != null)
                Detatch();

        }
        else if (movingObject != null)
            Detatch();
    }

    private void Detatch()
    {
        transform.parent = null;
        movingObject = null;
    }
}
