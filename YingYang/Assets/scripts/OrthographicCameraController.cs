using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicCameraController : MonoBehaviour
{
    public float zoomCoeff= 5;
    public float maxZoom = 4;
    public float minZoom = 30;
    private Vector3 movementDirection;
    private bool darkMode = false;

    private Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        this.cam = gameObject.GetComponent<Camera>();
    }

    void Start()
    {
        this.setVisualMode();
    }

    // Update is called once per frame
    void Update()
    {
        this.processInputs();

        this.Zoom();
    }

    void processInputs()
    {
        this.computeZoomDirection();
        this.switchVisualMode();
    }

    void switchVisualMode()
    {
        if (Input.GetKeyDown(KeyCode.N)) {
            if (this.cam.clearFlags == CameraClearFlags.Nothing) {
                return;
            }
            this.cam.clearFlags = CameraClearFlags.SolidColor;
            this.setVisualMode();
        }
    }

    void setVisualMode()
    {
        if (this.darkMode) {
            this.darkMode = false;
            cam.backgroundColor = new Color(183, 183, 183, 100) / 255;
        } else {
            this.darkMode = true;
            cam.backgroundColor = new Color(41, 41, 41, 100) / 255;
        }
    }

    void computeZoomDirection()
    {
        this.movementDirection = new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel"));
    }

    void Zoom()
    {
        if (this.maxZoom <= this.cam.orthographicSize && this.movementDirection.z > 0) {
            this.cam.orthographicSize -= this.movementDirection.z * this.zoomCoeff;
        }
        if (this.minZoom >= this.cam.orthographicSize && this.movementDirection.z < 0) {
            this.cam.orthographicSize -= this.movementDirection.z * this.zoomCoeff;
        }
    }
}
