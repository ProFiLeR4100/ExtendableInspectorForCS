#if TOOLS
using Godot;

[Tool]
public partial class ExtendableInspectorPlugin : EditorPlugin {
	private ExtendableInspector instance;

	public override void _EnterTree() {
		instance = new ExtendableInspector();
		AddInspectorPlugin(instance);
	}

	public override void _ExitTree() {
		RemoveInspectorPlugin(instance);
		instance.Free();
	}
}
#endif
