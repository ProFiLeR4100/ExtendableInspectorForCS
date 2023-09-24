using Godot;

[Tool]
public partial class SayYourName : Node2D {
	#if TOOLS
	public void ExtendInspectorBegin(ExtendableInspector inspector) {
		Button button = new() {
			Text = "Say your name"
		};
		button.Pressed += () => GD.Print(Name);
		inspector.AddCustomControl(button);
	}
	#endif
}
