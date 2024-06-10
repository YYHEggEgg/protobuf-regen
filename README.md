# protobuf-regen

Use existing .proto files and order their fields by name, then generate new ones (separated by message / enum name).

## Usage

### ProtobufRegen

`dotnet run` at its directory and follow the guide.

### Proto2jsonGen

Nothing..? `dotnet run -- --help` to see Command Line help.

## FAQs

### Want to change the notice?

```txt
// mihomo-protos - Public protocol APIs for miHomo software, open-sourced for compatibility.
...
```

Modify `ProtobufRegen/pre_license.txt`.

### Want to change the generated .proto's `package`?

Find `ProtobufRegen/Program.cs` and modify:

```cs
// Change if U need.
const string ProtoPackage = "miHomo.Protos";
```