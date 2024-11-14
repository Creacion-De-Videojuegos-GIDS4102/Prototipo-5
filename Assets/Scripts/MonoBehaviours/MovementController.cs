using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Velocidad de los personajes
    public float movementSpeed = 3.0f;

    // Representa la ubicaci�n del Player o Enemy
    Vector2 movement = new Vector2();

    //Referencia a RigidBody2D
    Rigidbody2D rb2D;

    Animator animator; // Referencia a componente animator
    string animationState = "AnimationState"; // Variable en Animator
    // Enumeraci�n de los estados
    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWeast = 3,
        walkNorth = 4,
        idleSouth = 5
    }


    // Start is called before the first frame update
    void Start()
    {
        // Establece el componente RigidBody2D enlazado
        rb2D = GetComponent<Rigidbody2D>();

        // Establece valor de componente Animator el objeto ligado
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState(); //Invoca el m�todo
    }

    private void UpdateState()
    {
        if (movement.x > 0)
        {
            // ESTE
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        }else if (movement.x < 0)
        {
            // OESTE
            animator.SetInteger(animationState, (int)CharStates.walkWeast);
        }else if (movement.y > 0)
        {
            // NORTE
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        }else if (movement.y < 0)
        {
            // SUR
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        }
        else
        {
            // IDLE
            animator.SetInteger(animationState, (int)CharStates.idleSouth);
        }

    }

    private void FixedUpdate()
    {
        MoveCharacter(); // M�todo definido para ingresar la direcci�n
    }

    private void MoveCharacter()
    {
        // Captura los datos de entrada del usuario
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Conservar el rango de velocidad
        movement.Normalize();
        rb2D.velocity = movement * movementSpeed;
    }

}
