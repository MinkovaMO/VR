// Клас для взаємодії з порталом.
// Відповідає за визначення, чи знаходиться пристрій в іншому світі через портал.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{
    // Посилання на пристрій (зазвичай камера)
    public Transform device;

    // Прапорець для перевірки, чи пристрій не перебуває в тому ж напрямку, що і раніше
    bool wasInFront;
    // Прапорець для визначення наступної зміни стану, що встановлюється для тестування трафарета
    bool inOtherWorld;

    // Цей прапорець увімкнений під час зіткнення пристрою з порталом, щоб ми могли переконатися, що шейдери оновлюються до кадру рендерингу
    // Уникнення мерехтіння
    bool isColliding;

    void Start()
    {
        // Знаходимо пристрій (зазвичай камеру)
        device = GameObject.Find("AR Camera").transform;
        // Починаємо з поза іншого світу
        SetMaterials(false);
    }

    // Встановлюємо тестування трафарета залежно від стану
    void SetMaterials(bool fullRender)
    {
        var stencilTest = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;
        Shader.SetGlobalInt("_StencilTest", (int)stencilTest);
    }

    // Визначаємо, чи пристрій знаходиться перед порталом
    bool GetIsInFront()
    {
        Vector3 worldPos = device.position + device.forward * Camera.main.nearClipPlane;

        Vector3 pos = transform.InverseTransformPoint(worldPos);
        return pos.z >= 0 ? true : false;
    }

    // Цей метод реєструє, чи пристрій натрапив на портал, змінюючи прапорець
    void OnTriggerEnter(Collider other)
    {
        if (other.transform != device)
            return;
        // Важливо зробити це, щоб уникнути входу користувача до порталу з того ж боку
        wasInFront = GetIsInFront();
        isColliding = true;
    }

    // Цей метод видаляє прапорець після виходу пристрою з порталу
    void OnTriggerExit(Collider other)
    {
        if (other.transform != device)
            return;
        isColliding = false;
    }

    // Якщо змінився відносний положення пристрою до порталу, змінюємо тестування трафарета
    void WhileCameraColliding()
    {
        if (!isColliding)
            return;
        bool isInFront = GetIsInFront();
        if ((isInFront && !wasInFront) || (wasInFront && !isInFront))
        {
            inOtherWorld = !inOtherWorld;
            SetMaterials(inOtherWorld);
        }
        wasInFront = isInFront;
    }

    // Під час знищення об'єкта гарантуємо відображення геометрії в редакторі
    void OnDestroy()
    {
        SetMaterials(true);
    }

    void Update()
    {
        WhileCameraColliding();
    }
}