using UnityEngine;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(BoundsCaptureCamera))]
[RequireComponent(typeof(FigureShader))]
public class BoundsCaptureCameraVisualizer : MonoBehaviour
{
    #region Field

    protected new Camera          camera;
    protected BoundsCaptureCamera boundsCaptureCamera;
    protected FigureShader        figureShader;

    public bool visualize;

    #endregion Field

    protected void Awake()
    {
        this.camera              = base.GetComponent<Camera>();
        this.boundsCaptureCamera = base.GetComponent<BoundsCaptureCamera>();
        this.figureShader        = base.GetComponent<FigureShader>();
    }

    void Update()
    {
        if (this.visualize)
        {
            foreach (BoundsMonoBehaviour bounds in this.boundsCaptureCamera.bounds)
            {
                this.figureShader.DrawRect(this.camera.WorldToViewportPoint(bounds.Min),
                                           this.camera.WorldToViewportPoint(bounds.Max),
                                           bounds.gizmoColor);
            }
        }
    }
}