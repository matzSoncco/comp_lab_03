using UnityEngine;

public class ControlDeNave : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        ProcesarEntrada();
    }

    private void ProcesarEntrada(){
        ManagePropulsion();
        ManageRotacion();
    }

    private void ManagePropulsion(){
        if (Input.GetKey(KeyCode.Space)) {
            print("La nave está despegando");
            rigidBody.AddRelativeForce(Vector3.up * 30f);
            if (!audioSource.isPlaying) {
                print("Reproduciendo sonido de motor");
                audioSource.Play();
            }
        }
        else {
            //si la tecla no está presionada, detenemos el audio
            audioSource.Stop();
        }
    }

    private void ManageRotacion() {
        float rotacionInput = 0f;
        if (Input.GetKey(KeyCode.A)) {
            rotacionInput = 1f;
        } else if (Input.GetKey(KeyCode.D)) {
            rotacionInput = -1f;
        }

        transform.Rotate(Vector3.forward * rotacionInput * 50f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "ColisionSegura":
                print("Colisión con objeto amigable");
                break;
            default:
                print("Has chocado con un obstáculo!");
                break;
        }
    }
}
