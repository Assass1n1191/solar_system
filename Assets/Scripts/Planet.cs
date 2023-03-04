using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public PlanetName Name;
    public TextMeshPro NameText;

    private bool _isFixed;
    private Vector3 _initialPosition;

    private void Start()
    {
        NameText.text = Name.ToString();
        _initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetPlanet();
        }
    }

    private void OnMouseDrag()
    {
        if (!_isFixed)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            transform.position = mousePos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlanetPlaceholder>().TargetPlanet == Name)
        {
            FixPlanet(collider.transform.position);
        }
    }

    private void FixPlanet(Vector3 position)
    {
        _isFixed = true;
        transform.position = position;
        NameText.color = Color.green;
    }

    private void ResetPlanet()
    {
        _isFixed = false;
        NameText.color = Color.white;
        transform.position = _initialPosition;
    }
}
