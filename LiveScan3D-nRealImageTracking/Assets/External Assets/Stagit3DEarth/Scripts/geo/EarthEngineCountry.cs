using UnityEngine;
using System.Collections;

public class EarthEngineCountry : MonoBehaviour
{


	public Vector2[] coords;
	public string ADM0;
	public int detail = 2;
	public string countryName;

	private LineRenderer _line;
	private Transform[] _countryParts;
	private LineRenderer[] _lineRenderers;
	private bool _routineHighlighting = false;
	private bool _linescreated = false;

	void Start() {
		//startHighLight ();
	}


	public void startHighLight() {
		if (!_linescreated) {
			CreateLines ();
			_linescreated = true;
		}
		_routineHighlighting = true;
		StartCoroutine (routineHighlight ());
		for (int i = 0; i < _lineRenderers.Length-1; i++) {
			_lineRenderers [i].startWidth = StagitMainEarth.Instance.CountryBorderWidth;
			_lineRenderers [i].endWidth =  StagitMainEarth.Instance.CountryBorderWidth;
		}
	}

	public void stopHighLight() {
		_routineHighlighting = false;
		for (int i = 0; i < _lineRenderers.Length-1; i++) {
			_lineRenderers [i].startWidth = 0f;
			_lineRenderers [i].endWidth =  0f;
		}
		StopCoroutine (routineHighlight ());
	}

	IEnumerator routineHighlight() {

		// Simple coroutine to highlight a country. 

		while (_routineHighlighting) {
			for (int i = 0; i < _lineRenderers.Length-1; i++) {
				_lineRenderers [i].startColor = new Color32 (255, 255, 255, 255);
				_lineRenderers [i].endColor = new Color32 (255, 255, 255, 255);
			}
			yield return new WaitForSeconds (0.6f);
			for (int i = 0; i < _lineRenderers.Length-1; i++) {
				_lineRenderers [i].startColor = new Color32 (0, 0, 0, 100);
				_lineRenderers [i].endColor = new Color32 (0, 0, 0, 100);

			}
			yield return new WaitForSeconds (0.6f);

		}
	}

	void OnDrawGizmosSelected() {
		// Draw lines when needed
		GameObject mainEarth = GameObject.Find ("MainEarth");
		StagitMainEarth stagitMainEarth = mainEarth.GetComponent<StagitMainEarth>();
		if (stagitMainEarth.ShowCountryBorders) {

			// Draw lines
			drawGizmo ();

		}
	}

	public void drawGizmo(int detail = 5) {

		GameObject earth = GameObject.Find ("EarthObject");

		GeoLocator geo = new GeoLocator ();

		Gizmos.color = Color.blue;
		Component[] components = null;;
		components = this.GetComponents(typeof(EarthEngineEarthVectors));

		// Get all lat/long vectors
		foreach (EarthEngineEarthVectors component in components) {
			Vector3[] vertices3D_main;
			vertices3D_main = new Vector3[component.poslat.Length / detail];

			// fill vector3 array with all country world positions from the lat long positions
			for (int i = 0; i < (component.poslat.Length) / detail; i++) {

				// Set the position of the country to the first lat/long position found
				if (i == 0) {
					this.transform.position = earth.transform.position + geo.getVectorFromLatLong (earth.transform.localScale.x * 100 + 0.1f, component.poslat [i], component.poslong [i]);
				}
				if (component.poslat [i ] != 0f) {
					Vector3 startpos = earth.transform.position + geo.getVectorFromLatLong (earth.transform.localScale.x * 100 + 0.1f, component.poslat [i * detail], component.poslong [i * detail]);
					vertices3D_main [i] = startpos;				
				}
			}

			// Draw all lines to show up in the editor
			for (int i = 0; i < vertices3D_main.Length-1; i++) {
				Gizmos.DrawLine (vertices3D_main [i], vertices3D_main [i + 1]);
			}
		}
	}



	void CreateLines() {
		detail = 1;
		GameObject earth = GameObject.Find ("EarthObject");

		GeoLocator geo = new GeoLocator ();

		Component[] components = null;
		components = this.GetComponents(typeof(EarthEngineEarthVectors));

		// Since there can only be one linerender on an object we need to create different gameobjects
		// Countries  contain multiple parts for example islands
		foreach (EarthEngineEarthVectors component in components) {
			GameObject countrypart = new GameObject ("CountryPart");
			countrypart.transform.parent = this.transform;
		}

		_countryParts = GetComponentsInChildren<Transform> ();
		_lineRenderers = new LineRenderer[_countryParts.Length];

		// fill vector3 array with all country world positions from the lat long positions
		int c = 0;
		foreach (EarthEngineEarthVectors component in components) {
			Vector3[] vertices3D_main;
			vertices3D_main = new Vector3[component.poslat.Length / detail];

			for (int i = 0; i < (component.poslat.Length) / detail; i++) {
				if (i == 0) {
					this.transform.position = earth.transform.position + geo.getVectorFromLatLong (earth.transform.localScale.x * 100 + StagitMainEarth.Instance.CountryBorderOffset, component.poslat [i], component.poslong [i]);
				}
				if (component.poslat [i ] != 0f) {
					Vector3 startpos = earth.transform.position + geo.getVectorFromLatLong (earth.transform.localScale.x * 100 + StagitMainEarth.Instance.CountryBorderOffset, component.poslat [i * detail], component.poslong [i * detail]);
					vertices3D_main [i] = startpos;				
				}
			}

			_line = _countryParts[c].gameObject.AddComponent <LineRenderer> () as LineRenderer;

			_line.material = StagitMainEarth.Instance.CountryLineMaterial;

			// Set the width to 0.0 first as we will use it later to finally highlight a country
			_line.startWidth = 0.0f;
			_line.endWidth = 0.0f;

			// Set all vector3 positions of the line
			//_line.SetVertexCount (vertices3D_main.Length);
			_line.positionCount = vertices3D_main.Length;
			for (int i = 0; i < vertices3D_main.Length; i++) {
				_line.SetPosition (i, vertices3D_main [i]);
			}
			_lineRenderers [c] = _line;
			c++;
		}
	}

}