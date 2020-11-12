using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Route))]

class PathEditor : Editor
{
    List<Vector3> list = new List<Vector3>();
    Vector3[] points;
    bool b;

    Vector3[] gpoints;

    protected virtual void OnSceneGUI()
    {
        Route route = (Route)target;

        if (route == null)
        {
            return;
        }

        //if (!b)
        //{
        //    b = true;
        //    //points = route.Points;
        //    points = new Vector3[route.Points.Length];

        //    //list.CopyTo(route.Points);

        //}
        points = new Vector3[route.Points.Length];
        gpoints = new Vector3[route.Points.Length];


        Handles.color = route.pathColor;
        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.normal.textColor = route.pathColor;

        GUIStyle style2 = new GUIStyle();

        style2.normal.textColor = Color.white;
        Handles.Label(route.transform.position + Vector3.up,""+route.name,style);
        EditorGUI.BeginChangeCheck();


        //Draw All Handles in global space, cache changes in another array
        for (int i = 0; i < route.Points.Length; i++)
        {
            Handles.DrawWireDisc(route.transform.TransformPoint(route.Points[i]), Vector3.up, 0.5f);
            points[i] = Handles.DoPositionHandle(route.transform.TransformPoint(route.Points[i]), Quaternion.identity);
            gpoints[i] = route.transform.TransformPoint(route.Points[i]);
            Handles.DrawWireArc(route.transform.TransformPoint(route.Points[i]), Vector3.up, Vector3.forward, 20, 2);

            Handles.Label(gpoints[i] + Vector3.up, ""+i, style2);


        }


        //Assign values from cache to route in local space
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Rotated RotateAt Point");

            for (int i = 0; i < route.Points.Length; i++)
            {
                route.Points[i] = route.transform.InverseTransformPoint(points[i]);


            }

            b = true;


        }

        Handles.DrawAAPolyLine(gpoints);
        //for (int i= 0; i < route.Points.Length;i++)
        //{

        //    Handles.DoPositionHandle(route.transform.position + route.Points[i], Quaternion.identity);


        //}


        //for (int i = 0; i < route.Points.Length; i++)
        //{
        //    route.Points[i] = points[i];


        //}





        //foreach (Vector3 v in route.Points)
        //{
        //    Handles.color = Color.red;
        //    Handles.DrawWireDisc(route.transform.position + v,Vector3.up, 1);
        //    Handles.DoPositionHandle(route.transform.position + v+Vector3.up*2, Quaternion.identity);

        //}
        //Handles.DrawAAPolyLine(route.Points);


        //foreach (Vector3 v in route.Points)
        //{



        //    //v = Handles.DoPositionHandle(v + Vector3.up, Quaternion.identity);
        //}

    }



}