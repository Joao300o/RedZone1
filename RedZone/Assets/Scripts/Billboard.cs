using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform target;
    public bool canLookVertically;

    void Start()
    {
        target = FindAnyObjectByType<PlayerMove>().transform;
    }

    void Update()
    {
        if (canLookVertically)
        {
            transform.LookAt(Camera.main.transform);
        }
        else
        {
            Vector3 modifiedTarget = new Vector3(
                Camera.main.transform.position.x,
                transform.position.y,
                Camera.main.transform.position.z
            );
            transform.LookAt(modifiedTarget);
        }
    }
}