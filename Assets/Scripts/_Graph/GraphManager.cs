using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace JazzApps
{
	public class GraphManager : MonoBehaviour
	{
		// Externals
		[SerializeField] private GameObject pointPrefab;
		[SerializeField, Range(10, 100)] private int resolution = 10;
		
		// Internals
		Transform[] points;

		void Awake ()
		{
			points = new Transform[resolution];
			float step = 10f / resolution;
			var position = Vector3.zero;
			var scale = Vector3.one;
			for (int i = 0; i < resolution; i++)
			{
				points[i] = i != 0 ? Instantiate(pointPrefab, transform).transform : pointPrefab.transform;
				var coordinateX = ((-resolution / 2) + 1) + i;
				position.x = ((coordinateX + 0.5f) * step);
				//position.y = Mathf.Pow(position.x,3) * Mathf.Pow(scale.x,2);
				points[i].localPosition = position;
				points[i].localScale = scale;
			}
		}
		
		void Update () {
			float time = Time.time;
			for (int i = 0; i < points.Length; i++)
			{
				Transform point = points[i];
				Vector3 position = point.localPosition;
				position.y = Mathf.Sin(Mathf.PI * (position.x + time) /3) * 5;
				point.localPosition = position;
				float scaleScalar = Mathf.Max(Mathf.Abs(position.y/5), 0.3f);
				point.localScale = new Vector3(scaleScalar, scaleScalar, scaleScalar);
			}
		}
	}
}
