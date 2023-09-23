# Extendable Inspector

Makes it easier to add custom inspector controls to nodes.

![Screenshot showing the example code in res://addons/extendable_inspector_for_cs/example/ChangeRandomColor/ChangeRandomColor.cs](https://github.com/ProFiLeR4100/ExtendableInspectorForCS/assets/9364958/acb2336e-532b-4bf7-9700-0c3d2c444fb8)
![3d scene of a cube with a button in the inspector that says 'Change To Random Color'](https://github.com/ProFiLeR4100/ExtendableInspectorForCS/assets/9364958/16db2d8e-3ee2-4489-98a3-158bb2b22ba2)
![3d scene of a cube with a button in the inspector that says 'Change To Random Color' but now the cube is of a different color](https://github.com/ProFiLeR4100/ExtendableInspectorForCS/assets/9364958/5bb39e97-5d02-4f9a-a388-2e6755cd9d54)

# How to install

Download the project and copy the addon folder into your godot project.

Go to Project Settings > Plugins, and enable Extendable Inspector (C#).

# Quick Start / Tutorial

Let's add a button that prints the node name in godot's output:
- Choose the node that should have this control, make sure its script has the `[Tool]` attribute at the class declaration, [this allows it to run code while in the editor](https://docs.godotengine.org/en/stable/tutorials/plugins/running_code_in_the_editor.html).
![image](https://github.com/ProFiLeR4100/ExtendableInspectorForCS/assets/11432672/7c84f2c1-e64f-40ee-a3f0-ef6f858eb78f)
- Define a method called `ExtendInspectorBegin` that receives a parameter, let's call that parameter `inspector`. If you want, you can type it as `ExtendableInspector` to get some autocomplete features:
![image](https://github.com/ProFiLeR4100/ExtendableInspectorForCS/assets/11432672/65f90976-adeb-4607-9d58-46fa214c2f0f)
- Create a button that when pressed, it prints the node's name. Then, simply add it to the inspector with `inspector.AddCustomControl(ourNewControl)`. You will have to unfocus the node and focus it again for the button to appear:
![image](https://github.com/ProFiLeR4100/ExtendableInspectorForCS/assets/11432672/2d4e62ef-7dcf-4cc5-b74c-c26bde55c70a)

Here's the entire code in case you want to try it out:

```csharp
using Godot;

[Tool]
public partial class SayYourName : Node2D {
    public void ExtendInspectorBegin(ExtendableInspector inspector) {
        Button button = new() {
            Text = "Say your name"
        };
        button.Pressed += () => GD.Print(Name);
        inspector.AddCustomControl(button);
    }
}
```


# How to use

What this plugin does is allow extending the inspector by declaring some methods in the script for which you want to add custom extensions to the inspector.

The supported methods are analogous to methods that can be defined in an `EditorInspectorPlugin` to add new features to the inspector.
https://docs.godotengine.org/en/latest/classes/class_editorinspectorplugin.html#class-editorinspectorplugin-method-add-property-editor-for-multiple-properties

These methods are:
```csharp
void ExtendInspectorBegin(ExtendableInspector inspector)
```
Allows adding controls at the beginning of the inspector.

```csharp
void ExtendInspectorEnd(ExtendableInspector inspector)
```

Allows adding controls at the end of the inspector.

```csharp
void ExtendInspectorCategory(inspector: ExtendableInspector, string category)
```

Allows adding controls at the beginning of a category in the property list for object.

```csharp
bool ExtendInspectorProperty(ExtendableInspector inspector, Variant.Type type, string name, PropertyHint hintType, string hintString, PropertyUsageFlags usageFlags, bool wide)
```

Allows adding property-specific editors to the property list for object. The added editor control must extend `EditorProperty`. Returning `true` removes the built-in editor for this property, otherwise allows to insert a custom editor before the built-in one.

## Examples

Examples can be found in the [example folder](https://github.com/ProFiLeR4100/ExtendableInspectorForCS/tree/godot-4/addons/extendable_inspector_for_cs/example)
