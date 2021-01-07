using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private GameObject _laserPrefab;

    private float _upPosition = 0f;
    private float _downPosition = -4.0f;
    private float _leftPosition = -13.5f;
    private float _rightPosition = 13.5f;


    void Update() {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        }
    }

    private void Movement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        /* 1st approach. */
        // Vector3.right means new Vector3(1, 0, 0);
        // Vector3.left means new Vector3(-1, 0, 0);
        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        /* 2nd approach. */
        //transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);

        /* 3rd approach. */
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        // Checking Y bounds
        if (transform.position.y >= _upPosition) {
            transform.position = new Vector3(transform.position.x, 0, 0);
        } else if (transform.position.y <= _downPosition) {
            transform.position = new Vector3(transform.position.x, _downPosition, 0);
        }

        // Checking X bounds
        if (transform.position.x >= _rightPosition) {
            transform.position = new Vector3(_rightPosition, transform.position.y, 0);
        } else if (transform.position.x <= _leftPosition) {
            transform.position = new Vector3(_leftPosition, transform.position.y, 0);
        }
    }
}
