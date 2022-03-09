using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        processMovement();
        processRotation();
    }

    void processMovement()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float xRawPosition = transform.localPosition.x + xOffset;
        float xNewPosition = Mathf.Clamp(xRawPosition, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float yRawPosition = transform.localPosition.y + yOffset;
        float yNewPosition = Mathf.Clamp(yRawPosition, -yRange, yRange);

        transform.localPosition = new Vector3(xNewPosition, yNewPosition, transform.localPosition.z);
    }
    
    void processRotation()
    {
        
    }
}
