using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
	public Camera cam;


	private int columns = GameManager.instance.Columns;
	public static int[] columnValue;
	private int rows = GameManager.instance.Rows;
	public static int[] rowValue;
	public GameObject numberGameObject;
	public GameObject totalGameObject;
	public static GameObject[, ] allNumbers;
	public List<GameObject> allTotals;
	private bool executeNextLevel = true;

	public static int LowestPossibleMoves;
	public static int NumberOfMovesPlayerHasMade;

	// Use this for initialization
	private void Awake()
	{
		GameManager.instance.ThisLevelsGrid = gameObject;
		columnValue = new int[columns];
		rowValue = new int[rows];
		allNumbers = new GameObject[columns, rows];
	}

	void Start()
	{
		if (GameManager.instance.CurrentLevel % 5 == 0) GameManager.instance.LoadBannerAd(); else GameManager.instance.HideBannerAd();
		LowestPossibleMoves = 0;
		NumberOfMovesPlayerHasMade = 0;
		GameManager.instance.LevelCounterText = GameObject.Find("LevelCounter").GetComponent<Text>();
		cam.GetComponent<Transform>().position = new Vector3(((columns + 1f) / 2f) - 1f, ((rows + 1f) / 2f) - 1f, -10f);

		int[] sumOfRowValues = new int[rows];

		for (int i = 0; i < columns; i++)
		{
			int k = 0;
			int sumOfColumnValues = 0;
			for (int j = 0; j < rows; j++, k++)
			{
				GameObject num = GameObject.Instantiate(numberGameObject, new Vector3(i, j, -1.6f), Quaternion.identity);
				num.GetComponent<Number>().inColumn = i + 1;
				num.GetComponent<Number>().inRow = j + 1;
				num.GetComponent<Number>().addToTotal = (0 != Random.Range(0, GameManager.instance.NumberAddedToTotalDifficulty));
				if (!num.GetComponent<Number>().addToTotal) LowestPossibleMoves++;
				sumOfColumnValues += (num.GetComponent<Number>().addToTotal) ? num.GetComponent<Number>().value : 0;
				sumOfRowValues[j] += (num.GetComponent<Number>().addToTotal) ? num.GetComponent<Number>().value : 0;
				allNumbers[i, j] = num;
			}

			GameObject columnTotalTop = GameObject.Instantiate(totalGameObject, new Vector3(i, k, -1.6f), Quaternion.identity);
			GameObject columnTotalBottom = GameObject.Instantiate(totalGameObject, new Vector3(i, -1, -1.6f), Quaternion.identity);
			allTotals.Add(columnTotalTop);
			allTotals.Add(columnTotalBottom);
			columnTotalTop.GetComponent<Total>().Value = columnTotalBottom.GetComponent<Total>().Value = sumOfColumnValues;
			columnTotalTop.GetComponent<Total>().inColumn = columnTotalBottom.GetComponent<Total>().inColumn = i + 1;
		}

		for (int i = 0; i < sumOfRowValues.Length; i++)
		{
			GameObject rowTotalRight = GameObject.Instantiate(totalGameObject, new Vector3(columns, i, -1.6f), Quaternion.identity);
			GameObject rowTotalLeft = GameObject.Instantiate(totalGameObject, new Vector3(-1, i, -1.6f), Quaternion.identity);
			allTotals.Add(rowTotalRight);
			allTotals.Add(rowTotalLeft);
			rowTotalRight.GetComponent<Total>().Value = rowTotalLeft.GetComponent<Total>().Value = sumOfRowValues[i];
			rowTotalRight.GetComponent<Total>().inRow = rowTotalLeft.GetComponent<Total>().inRow = i + 1;

		}

		GetColumnAndRowTotals();

		switch (GameManager.instance.Columns)
		{
			case 2:
			case 3:
				cam.orthographicSize = 4;
				break;
			case 4:
				cam.orthographicSize = 5;
				break;
			case 5:
			case 6:
				cam.orthographicSize = 6;
				break;
			default:
				break;
		}
	}

	// Update is called once per frame
	void Update()
	{
		IEnumerable<GameObject> completedColumnRowFilter = allTotals.Where(total => total.GetComponent<Total>().columnRowComplete == true);

		if (completedColumnRowFilter.Count() == allTotals.Count)
		{
			if (executeNextLevel) StartCoroutine(GameManager.instance.NextLevel());
			executeNextLevel = false;
		}
	}

	public static void GetColumnAndRowTotals()
	{
		int[] x = new int[allNumbers.GetLength(0)];
		int[] y = new int[allNumbers.GetLength(1)];

		for (int i = 0; i < allNumbers.GetLength(0); i++)
		{
			for (int j = 0; j < allNumbers.GetLength(1); j++)
			{
				x[i] += allNumbers[i, j].GetComponent<Number>().value;
				y[j] += allNumbers[i, j].GetComponent<Number>().value;
			}
		}

		for (int i = 0; i < x.Length; i++) columnValue[i] = x[i];

		for (int i = 0; i < y.Length; i++) rowValue[i] = y[i];

	}



}