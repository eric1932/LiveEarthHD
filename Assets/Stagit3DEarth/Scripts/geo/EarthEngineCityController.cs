using UnityEngine;
using System.Collections;

public class EarthEngineCityController : MonoBehaviour
{

	private static EarthEngineCityController _instance;

	void Awake () {
		_instance = this;
	}

	public static EarthEngineCityController Instance {
		get { return _instance; }
	}

	public void showCity(string cityname, string ADM3 = "") {
		EarthEngineCity earthEngineCity = getCity (cityname, ADM3);
		if (earthEngineCity) {
			_showCityLabel (earthEngineCity);
		}
	}

	public void enableAllCitiesWithRank(int rank) {
		foreach(Transform child in transform)
		{
			EarthEngineCity earthEngineCity = child.GetComponent<EarthEngineCity> () as EarthEngineCity;
			if (earthEngineCity.rank == rank) {
				child.gameObject.SetActive (true);
			}
		}
	}


	public void disableAllCitiesWithRank(int rank) {
		foreach(Transform child in transform)
		{
			EarthEngineCity earthEngineCity = child.GetComponent<EarthEngineCity> () as EarthEngineCity;
			if (earthEngineCity.rank == rank) {
				child.gameObject.SetActive (false);
			}
		}
	}


	public void showAllCitiesWithRank(int rank) {
		foreach(Transform child in transform)
		{
			EarthEngineCity earthEngineCity = child.GetComponent<EarthEngineCity> () as EarthEngineCity;
			if (earthEngineCity.rank == rank) {
				_showCityLabel(earthEngineCity);
			}
		}
	}

	public void hideAllCitiesWithRank(int rank) {
		foreach(Transform child in transform)
		{
			EarthEngineCity earthEngineCity = child.GetComponent<EarthEngineCity> () as EarthEngineCity;
			if (earthEngineCity.rank == rank) {
				_hideCityLabel(earthEngineCity);
			}
		}
	}

	public EarthEngineCity getCity(string cityname, string ADM3 = "") {
		foreach(Transform child in transform)
		{
			if (child.name.ToLower() == cityname.ToLower()) {
				Debug.Log("Found city: " + cityname );
				EarthEngineCity earthEngineCity = child.GetComponent<EarthEngineCity> () as EarthEngineCity;
				if (ADM3 == "") {
					return earthEngineCity;
				} else {
					if (earthEngineCity.adminA3.ToLower() == ADM3.ToLower()) {
						return earthEngineCity;
					}
				}
			}
		}
		return null;
	}

	public EarthEngineCity searchCity(string cityname, string ADM3 = "") {
		foreach(Transform child in transform)
		{
			if (child.name.ToLower().Contains(cityname.ToLower())) {
				Debug.Log("Found city: " + cityname );
				EarthEngineCity earthEngineCity = child.GetComponent<EarthEngineCity> () as EarthEngineCity;
				if (ADM3 == "") {
					return earthEngineCity;
				} else {
					if (earthEngineCity.adminA3.ToLower().Contains(ADM3.ToLower())) {
						return earthEngineCity;
					}
				}
			}
		}
		return null;
	}


	public void updatePositions() {
		foreach(Transform child in transform)
		{
			EarthEngineCity earthEngineCity = child.GetComponent<EarthEngineCity> () as EarthEngineCity;
			earthEngineCity.Allign ();	

		}
	}


	private void _showCityLabel(EarthEngineCity earthEngineCity) {
		earthEngineCity.showCity ();
	}

	private void _hideCityLabel(EarthEngineCity earthEngineCity) {
		earthEngineCity.hideCity ();
	}


}

