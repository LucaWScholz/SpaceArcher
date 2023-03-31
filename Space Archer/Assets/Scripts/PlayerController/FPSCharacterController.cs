using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class FPSCharacterController : MonoBehaviour
{
    public Camera playerCamera; // Spieler-Kamera
    public float walkSpeed = 6f; // Gehgeschwindigkeit
    public float runSpeed = 12f; // Laufgeschwindigkeit
    public float jumpPower = 10f; // Sprungkraft
    public float gravity = 10f; // Schwerkraft
    public float lookSpeed = 2f; // Maus-Sens
    public float lookXLimit = 90f; // Kein Genickbruch
    Vector3 moveDirection = Vector3.zero; // Bewegungsrichtung
    float rotationX; // Rotation in X-Richtung

    private Rigidbody rb; // RigidBody
    private bool isJumping = false; // Springt der Charakter gerade?

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        Cursor.lockState = CursorLockMode.Locked; // Mauszeiger sperren
        Cursor.visible = false; // Mauszeiger unsichtbar machen
    }

    void Update()
    {
        // Transformiere die Vorwärts- und Rechtsrichtungen des Charakters in die Weltkoordinaten
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift); // Checkt, ob der Character läuft
        // Berechne die Bewegungsgeschwindigkeiten in X- und Y-Richtung
        float curSpeedX = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical");
        float curSpeedY = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal");

        // Setze die Bewegungsrichtung auf Basis der berechneten Geschwindigkeiten
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Prüfe, ob die Sprungtaste gedrückt wurde und der Charakter sich nicht bereits in der Luft befindet
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // Setze den Sprungstatus auf "wahr" und starte die Sprungroutine
            isJumping = true;
            StartCoroutine(PerformJump());
        }

        // Aktualisiere die Rotation in der X-Richtung auf Basis der Mausbewegung in Y-Richtung
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;

        // Begrenze die Rotation in der X-Richtung, um übermäßiges Kippen der Kamera zu verhindern
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        // Wende die berechnete Rotation in der X-Richtung auf die Kamera an
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Aktualisiere die Rotation des Charakters in der Y-Richtung auf Basis der Mausbewegung in X-Richtung
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    void FixedUpdate()
    {
        Vector3 targetVelocity = moveDirection;
        targetVelocity.y = rb.velocity.y;

        // Wende die berechnete Kraft an, um den Charakter zu bewegen
        rb.AddForce((targetVelocity - rb.velocity) * Time.fixedDeltaTime * 1000);

        // Schwerkraft anwenden, es sei denn der Charakter springt gerade
        if (!isJumping)
        {
            rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));
        }
    }

    IEnumerator PerformJump()
    {
        // Abwärtskräfte aufheben
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        // Schwerkraft vorübergehend deaktivieren
        rb.useGravity = false;
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

        // Warte kurz, bevor die Schwerkraft wieder aktiviert wird
        yield return new WaitForSeconds(0.2f);

        rb.useGravity = true;
        isJumping = false;
    }
}