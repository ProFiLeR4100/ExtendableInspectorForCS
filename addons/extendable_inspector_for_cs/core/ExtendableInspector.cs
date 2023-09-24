#if TOOLS
using Godot;

[Tool]
public partial class ExtendableInspector : EditorInspectorPlugin {
	public GodotObject target;

	private static string[] Methods = {
		"ExtendInspectorBegin",
		"ExtendInspectorEnd",
		"ExtendInspectorGroup",
		"ExtendInspectorProperty",
		"ExtendInspectorCategory"
	};
	
	public override bool _CanHandle(GodotObject godotObject) {
		foreach(string methodName in Methods) {
			if (godotObject.HasMethod(methodName)) {
				target = godotObject;
				return true;
			}
		}

		return false;
	}

	public override void _ParseBegin(GodotObject godotObject) {
		if (godotObject?.HasMethod("ExtendInspectorBegin") ?? false) {
			godotObject.Call("ExtendInspectorBegin", this);
		}
	}

	public override void _ParseEnd(GodotObject godotObject) {
		if (godotObject?.HasMethod("ExtendInspectorEnd") ?? false) {
			godotObject.Call("ExtendInspectorEnd", this);
		}
	}

	public override void _ParseCategory(GodotObject godotObject, string category) {
		if (godotObject?.HasMethod("ExtendInspectorCategory") ?? false) {
			godotObject.Call("ExtendInspectorCategory", this, category);
		}
	}

	public override  bool _ParseProperty(GodotObject godotObject, Variant.Type type, string name, PropertyHint hintType, string hintString, PropertyUsageFlags usageFlags, bool wide) {
		if (godotObject?.HasMethod("ExtendInspectorProperty") ?? false) {
			return godotObject.Call("ExtendInspectorProperty", this, (long) type, name, (long) hintType, hintString, (long) usageFlags, wide).AsBool();
		}

		return false;
	}

	public override void _ParseGroup(GodotObject godotObject, string group) {
		if (godotObject?.HasMethod("ExtendInspectorGroup") ?? false) {
			godotObject.Call("ExtendInspectorGroup", this, group);
		}
	}
}
#endif
