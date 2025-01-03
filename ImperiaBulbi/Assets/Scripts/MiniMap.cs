using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour

{

    [SerializeField] private Transform player;

    [SerializeField] private Transform target;

    [SerializeField] private RectTransform arrow; // ���������� UI, �������� ����, �������� ��'��� ����

    [SerializeField] private RectTransform compassBG; // ���������� UI, ��� �������, � ����� ����� ������������ ��������

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

        float posX = Camera.main.WorldToScreenPoint(target.position).x; // ��������� ������� ���� � ������� ������, �� �� �

        float center = Screen.width / 2; // ��������� ����� ������

        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);

        Vector3 toOther = target.position - Camera.main.transform.position;

        if (Vector3.Dot(forward, toOther) < 0) posX = 0; // ���� ���� ������ ��� - ������� ������� ����

        float minPos = center - compassBG.sizeDelta.x / 2;

        float maxPos = center + compassBG.sizeDelta.x / 2;

        posX = Mathf.Clamp(posX, minPos, maxPos); // ������� ������� ���� � ����� ���������� �������

        posX = center - posX; // �������� ������� ���� ������

        arrow.anchoredPosition = new Vector2(-posX, 0); // ���������

        Color tmp = Color.Lerp(arrowIn, arrowOut, Mathf.Abs(posX) / (compassBG.sizeDelta.x / 2));

        arrow.GetComponent<Image>().color = tmp; // ���������� �������, �������� �� 0 �� 1, ����� ������ = 0

        // ��������� ����� ��������� ���� ������� �� ����

        float dis = Vector3.Distance(player.position, target.position);

        float size = maxSize - dis / 4;

        size = Mathf.Clamp(size, minSize, maxSize);

        arrow.sizeDelta = new Vector2(size, arrow.sizeDelta.y);

    }

}