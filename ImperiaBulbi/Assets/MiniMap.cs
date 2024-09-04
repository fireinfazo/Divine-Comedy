using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour

{

    [SerializeField] private Transform player;

    [SerializeField] private Transform target;

    [SerializeField] private RectTransform arrow; // зображення UI, вказівник мети, дочірній об'єкт фону

    [SerializeField] private RectTransform compassBG; // зображення UI, тло компаса, в межах якого рухатиметься покажчик

    [SerializeField] private Color arrowIn = Color.white;

    [SerializeField] private Color arrowOut = Color.gray;

    private float minSize;

    private float maxSize;

    void Start()

    {

        arrow.anchoredPosition = new Vector2(0, 0);

        maxSize = arrow.sizeDelta.x;

        minSize = maxSize / 2;

    }

    void LateUpdate()

    {

        float posX = Camera.main.WorldToScreenPoint(target.position).x; // знаходимо позицію мети у просторі екрану, по осі Х

        float center = Screen.width / 2; // визначаємо центр екрану

        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);

        Vector3 toOther = target.position - Camera.main.transform.position;

        if (Vector3.Dot(forward, toOther) < 0) posX = 0; // якщо мета позаду нас - позиція дорівнює нулю

        float minPos = center - compassBG.sizeDelta.x / 2;

        float maxPos = center + compassBG.sizeDelta.x / 2;

        posX = Mathf.Clamp(posX, minPos, maxPos); // фіксуємо позицію мети в межах бекграунду компасу

        posX = center - posX; // коригуємо позицію щодо центру

        arrow.anchoredPosition = new Vector2(-posX, 0); // інвертуємо

        Color tmp = Color.Lerp(arrowIn, arrowOut, Mathf.Abs(posX) / (compassBG.sizeDelta.x / 2));

        arrow.GetComponent<Image>().color = tmp; // перемикаємо кольори, значення від 0 до 1, центр екрану = 0

        // визначаємо розмір покажчика щодо відстані до мети

        float dis = Vector3.Distance(player.position, target.position);

        float size = maxSize - dis / 4;

        size = Mathf.Clamp(size, minSize, maxSize);

        arrow.sizeDelta = new Vector2(size, arrow.sizeDelta.y);

    }

}