using UnityEngine;
using System.Collections;


public class StagitMainEarth : MonoBehaviour
{
	private static StagitMainEarth _instance;

	[Header("Editor Settings")]

	[Tooltip("Show country borders in the editor. Warning High CPU/LOAD. Don't use together with ShowSovCountryBorders")]
	public bool ShowCountryBorders = false;

	[Tooltip("Detail of country borders 1 High to 20 Low")]
	public int CountryBordersDetail = 5;

	[Tooltip("Show sovereign country borders in the editor. Warning High CPU/LOAD. Don't use together with ShowCountryBorders")]
	public bool ShowSovCountryBorders = false;

	[Header("Global Settings")]

	[Tooltip("Height of a country border above the Earth")]
	public float CountryBorderOffset = 0.02f;

	[Tooltip("Height of a city above the Earth")]
	public float CityOffset = 0.02f;


	[Tooltip("Country border width in game")]
	public float CountryBorderWidth = 0.005f;


	[Tooltip("Distance in which cities will be visible")]
	public float CityCameraVisibility = 20f;


	[Tooltip("Interval update time of city calculation distance")]
	public float CityDistanceCalcTime = 0.1f;

	public Material CountryLineMaterial;

	void Awake () {
		_instance = this;
	}

	public static StagitMainEarth Instance {
		get { return _instance; }
	}

}
