using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorMark : MonoBehaviour {
	protected virtual void OnDrawGizmos()
	{
		#if UNITY_EDITOR
		Gizmos.DrawIcon(transform.position, "Mark.png", true);
		#endif
	}
}
