using UnityEngine;
using System.Collections;

public class EarthEngineCity : MonoBehaviour
{

	public string locationName;
	public string adminA3;
	public int population;
	public int rank;
	public string province;
	public double latitude;
	public double longitude;


	private GameObject label;
	private GameObject labelHolder;
	private bool inititalized = false;
	private bool position_set = false;
	private bool routineupdateCityNameBusy = false;


	public Material material; 
	public Font font; 
	private GameObject earthCenter;
	private GameObject earthGeoHolder;


	public void showCity ()
	{
		earthCenter = GameObject.Find ("earthCenter");
		earthGeoHolder = GameObject.Find ("EarthGeoHolder");

		labelHolder = new GameObject (locationName);
		labelHolder.transform.parent = earthGeoHolder.transform;
		label = new GameObject ("label");
		label.SetActive (false);

		label.transform.parent = labelHolder.transform;
		labelHolder.transform.position = this.transform.position;
		font = Resources.Load<Font>("Fonts/Arial");

		label.AddComponent<MeshRenderer>(); // Throws Error
		label.GetComponent<Renderer>().material = material;

		TextMesh tm = label.AddComponent<TextMesh>(); // This too throws Error
		tm.text = locationName;
		tm.font = font;
		tm.characterSize = setRankToScale (rank) * 1f;
		tm.alignment = TextAlignment.Left;


		label.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
		labelHolder.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
		label.SetActive (true);
		inititalized = true;
	}

	public void hideCity() {
		inititalized = false;
		GameObject.Destroy (labelHolder);
	}



	public void Allign() {
		GeoLocator geo = new GeoLocator ();
		GameObject earth = GameObject.Find ("EarthObject");
		earthCenter = GameObject.Find ("earthCenter");
		this.transform.position = earth.transform.position + geo.getVectorFromLatLong (50.01f, latitude, longitude);
		this.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
		this.transform.LookAt (2 * this.transform.position - earthCenter.transform.position);
		this.transform.Rotate (180, 0f, 0f);

	}

	void Update() {
		if (!routineupdateCityNameBusy) {
			StartCoroutine (updateCityName ());
		}

	}

	IEnumerator updateCityName ()
	{
		routineupdateCityNameBusy = true;

		float camDistance = Vector3.Distance (Camera.main.gameObject.transform.position, this.gameObject.transform.position);

		if (!position_set && label) {
			label.transform.LookAt (2 * label.transform.position - earthCenter.transform.position);
			label.transform.Rotate (180, 0f, 0f);
			position_set = true;
		}
	
		//Debug.Log ("Distance:" + camDistance);

		if (camDistance < StagitMainEarth.Instance.CityCameraVisibility) {
			if (!inititalized) {
				showCity ();
			}
			labelHolder.SetActive (true);
		} else {
			if (inititalized) {
				labelHolder.SetActive (false);
			}
		}

		yield return new WaitForSeconds (StagitMainEarth.Instance.CityDistanceCalcTime);
		routineupdateCityNameBusy = false;
	}

	float setRankToScale(int rank) {
		float scale = 0;
		switch (rank) {
		case 0:
			scale = 0.16f;
			break;
		case 1:
			scale = 0.14f;
			break;
		case 2:
			scale = 0.11f;
			break;
		case 3:
			scale = 0.09f;			
			break;
		case 4:
		case 5:
		case 6:
			scale = 0.06f;
			break;
		case 7:
		case 8:
			scale = 0.05f;
			break;

		default:
			scale = 0.04f;
			break;
		}
		return scale;
	}

}

