using Godot;

[Tool]
public partial class SpiralCurveCreator : Node3D {
	[Export] public float Radius { get; set; } = 5;

	[Export] public float Height { get; set; } = 10;

	[Export] public float AmountOfPoints { get; set; } = 10;

	Path3D path;

	public void DrawEspiral() {
		Curve3D curve = GetPathNode().Curve;
		curve.ClearPoints();
		float angle = 0;
		float y = 0;
		for (int i = 0; i < AmountOfPoints; i++) {
			float x = Radius * Mathf.Cos(angle);
			float z = Radius * Mathf.Sin(angle);

			curve.AddPoint(new Vector3(x, y, z));

			angle += Mathf.Pi / 4f;
			y += (Height / AmountOfPoints);
		}
	}

	private Path3D GetPathNode() {
		if (!HasNode("Path3D")) {
			Path3D path = new Path3D();
			AddChild(path);
			path.Owner = GetTree().EditedSceneRoot;
			return path;
		}

		return GetNode<Path3D>("Path3D");
	}

	#if TOOLS
	public void ExtendInspectorBegin(ExtendableInspector inspector) {
		Button button = new() {
			Text = "Draw Espiral"
		};
		button.Pressed += DrawEspiral;
		inspector.AddCustomControl(button);
	}
	#endif
}
