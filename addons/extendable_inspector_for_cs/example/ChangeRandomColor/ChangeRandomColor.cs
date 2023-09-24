using Godot;

[Tool]
public partial class ChangeRandomColor : Node {
	public void ChangeToRandomColor() {
		CsgBox3D box = GetNode<CsgBox3D>("CSGBox3D");
		StandardMaterial3D material = box.Material as StandardMaterial3D;
		material.AlbedoColor = new Color(GD.Randf(), GD.Randf(), GD.Randf());
	}

	#if TOOLS
	public void ExtendInspectorBegin(ExtendableInspector inspector) {
		Button button = new() {
			Text = "Change To Random Color"
		};
		button.Pressed += ChangeToRandomColor;
		inspector.AddCustomControl(button);
	}
	#endif
}
