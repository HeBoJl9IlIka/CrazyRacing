﻿using CrazyRacing.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SplineMesh {
    /// <summary>
    /// Special component to extrude shape along a spline.
    /// 
    /// Note : This component is not lightweight and should be used as-is mostly for prototyping. It allows to quickly create meshes by
    /// drawing only the 2D shape to extrude along the spline. The result is not intended to be used in a production context and you will most likely
    /// create eventualy the mesh you need in a modeling tool to save performances and have better control.
    /// 
    /// The special editor of this component allow you to draw a 2D shape with vertices, normals and U texture coordinate. The V coordinate is set
    /// for the whole spline, by setting the number of times the texture must be repeated.
    /// 
    /// All faces of the resulting mesh are smoothed. If you want to obtain an edge without smoothing, you will have to overlap two vertices and set two normals.
    /// 
    /// You can expand the vertices list in the inspector to access data and enter precise values.
    /// 
    /// This component doesn't offer much control as Unity is not a modeling tool. That said, you should be able to create your own version easily.
    /// </summary>
    [ExecuteInEditMode]
    [RequireComponent(typeof(Spline))]
    public class SplineExtrusion : MonoBehaviour {
        private Spline spline;
        private bool toUpdate = true;
        private GameObject generated;

        public List<ExtrusionSegment.Vertex> shapeVertices = new List<ExtrusionSegment.Vertex>();
        public Material material;
        public float textureScale = 1;
        public float sampleSpacing = 0.1f;

        /// <summary>
        /// Clear shape vertices, then create three vertices with three normals for the extrusion to be visible
        /// </summary>
        private void Reset() {
            shapeVertices.Clear();
            shapeVertices.Add(new ExtrusionSegment.Vertex(new Vector2(0, 0.5f), new Vector2(0, 1), 0));
            shapeVertices.Add(new ExtrusionSegment.Vertex(new Vector2(1, -0.5f), new Vector2(1, -1), 0.33f));
            shapeVertices.Add(new ExtrusionSegment.Vertex(new Vector2(-1, -0.5f), new Vector2(-1, -1), 0.66f));
            toUpdate = true;
            OnEnable();
        }

        private void OnValidate() {
            toUpdate = true;
        }

        private void OnEnable() {
            string generatedName = "generated by " + GetType().Name;
            var generatedTranform = transform.Find(generatedName);
            generated = generatedTranform != null ? generatedTranform.gameObject : UOUtility.Create(generatedName, gameObject);

            spline = GetComponentInParent<Spline>();
            spline.NodeListChanged += (s, e) => toUpdate = true;
        }

        private void Update() {
            if (toUpdate) {
                GenerateMesh();
                toUpdate = false;
            }
        }

        private void GenerateMesh() {
            UOUtility.DestroyChildren(generated);

            int i = 0;
            float textureOffset = 0.0f;
            foreach (CubicBezierCurve curve in spline.GetCurves()) {
                GameObject go = UOUtility.Create("segment " + i++,
                    generated,
                    typeof(MeshFilter),
                    typeof(MeshRenderer),
                    typeof(ExtrusionSegment),
                    typeof(MeshCollider),
                    typeof(RoadPresenter));
                go.tag = Config.TagRoad;
                go.GetComponent<MeshRenderer>().material = material;
                ExtrusionSegment seg = go.GetComponent<ExtrusionSegment>();
                seg.ShapeVertices = shapeVertices;
                seg.TextureScale = textureScale;
                seg.TextureOffset = textureOffset;
                seg.SampleSpacing = sampleSpacing;
                seg.SetInterval(curve);

                textureOffset += curve.Length;
            }
        }

        public void SetToUpdate() {
            toUpdate = true;
        }
    }
}
