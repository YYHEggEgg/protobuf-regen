﻿// Generated by ChatGPT
// Warning: Shit Code. DO NOT EDIT!

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections;
using System.Collections.ObjectModel;

namespace ProtobufRegen
{
    #region ChatGPT prompt
    // 我现在有如下代码文件：

    #region Markdown Code Block (C#)
    // ```cs
    // // <auto-generated>
    // //     Generated by the protocol buffer compiler.  DO NOT EDIT!
    // //     source: GCGGameCreateFailReasonNotify.proto
    // // </auto-generated>
    // #pragma warning disable 1591, 0612, 3021, 8981
    // #region Designer generated code

    // using pb = global::Google.Protobuf;
    // using pbc = global::Google.Protobuf.Collections;
    // using pbr = global::Google.Protobuf.Reflection;
    // using scg = global::System.Collections.Generic;
    // namespace OldProtos {

    //   /// <summary>Holder for reflection information generated from GCGGameCreateFailReasonNotify.proto</summary>
    //   public static partial class GCGGameCreateFailReasonNotifyReflection {

    //     #region Descriptor
    //     /// <summary>File descriptor for GCGGameCreateFailReasonNotify.proto</summary>
    //     public static pbr::FileDescriptor Descriptor {
    //       get { return descriptor; }
    //     }
    //     private static pbr::FileDescriptor descriptor;

    //     static GCGGameCreateFailReasonNotifyReflection() {
    //       byte[] descriptorData = global::System.Convert.FromBase64String(
    //           string.Concat(
    //             "CiNHQ0dHYW1lQ3JlYXRlRmFpbFJlYXNvbk5vdGlmeS5wcm90byL+AQodR0NH",
    //             "R2FtZUNyZWF0ZUZhaWxSZWFzb25Ob3RpZnkSQgoGcmVhc29uGA8gASgOMjIu",
    //             "R0NHR2FtZUNyZWF0ZUZhaWxSZWFzb25Ob3RpZnkuR0NHR2FtZUNyZWF0ZVJl",
    //             "YXNvbiKYAQoTR0NHR2FtZUNyZWF0ZVJlYXNvbhIPCgtSRUFTT05fTk9ORRAA",
    //             "EhMKD1JFQVNPTl9HQU1FX01BWBABEiUKIVJFQVNPTl9DTElFTlRfVkVSU0lP",
    //             "Tl9OT1RfTEFTVEVTVBACEiAKHFJFQVNPTl9SRVNPVVJDRV9OT1RfQ09NUExF",
    //             "VEUQAxISCg5SRUFTT05fVElNRU9VVBAEQgyqAglPbGRQcm90b3NiBnByb3Rv",
    //             "Mw=="));
    //       descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
    //           new pbr::FileDescriptor[] { },
    //           new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
    //             new pbr::GeneratedClrTypeInfo(typeof(global::OldProtos.GCGGameCreateFailReasonNotify), global::OldProtos.GCGGameCreateFailReasonNotify.Parser, new[]{ "Reason" }, null, new[]{ typeof(global::OldProtos.GCGGameCreateFailReasonNotify.Types.GCGGameCreateReason) }, null, null)
    //           }));
    //     }
    //     #endregion

    //   }
    //   #region Messages
    //   public sealed partial class GCGGameCreateFailReasonNotify : pb::IMessage<GCGGameCreateFailReasonNotify>
    //   #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    //       , pb::IBufferMessage
    //   #endif
    //   {
    //     private static readonly pb::MessageParser<GCGGameCreateFailReasonNotify> _parser = new pb::MessageParser<GCGGameCreateFailReasonNotify>(() => new GCGGameCreateFailReasonNotify());
    //     private pb::UnknownFieldSet _unknownFields;
    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public static pb::MessageParser<GCGGameCreateFailReasonNotify> Parser { get { return _parser; } }

    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public static pbr::MessageDescriptor Descriptor {
    //       get { return global::OldProtos.GCGGameCreateFailReasonNotifyReflection.Descriptor.MessageTypes[0]; }
    //     }

    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     pbr::MessageDescriptor pb::IMessage.Descriptor {
    //       get { return Descriptor; }
    //     }

    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public GCGGameCreateFailReasonNotify() {
    //       OnConstruction();
    //     }

    //     partial void OnConstruction();

    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public GCGGameCreateFailReasonNotify(GCGGameCreateFailReasonNotify other) : this() {
    //       reason_ = other.reason_;
    //       _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    //     }

    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public GCGGameCreateFailReasonNotify Clone() {
    //       return new GCGGameCreateFailReasonNotify(this);
    //     }

    //     /// <summary>Field number for the "reason" field.</summary>
    //     public const int ReasonFieldNumber = 15;
    //     private global::OldProtos.GCGGameCreateFailReasonNotify.Types.GCGGameCreateReason reason_ = global::OldProtos.GCGGameCreateFailReasonNotify.Types.GCGGameCreateReason.ReasonNone;
    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public global::OldProtos.GCGGameCreateFailReasonNotify.Types.GCGGameCreateReason Reason {
    //       get { return reason_; }
    //       set {
    //         reason_ = value;
    //       }
    //     }

    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public override bool Equals(object other) {
    //       return Equals(other as GCGGameCreateFailReasonNotify);
    //     }

    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public bool Equals(GCGGameCreateFailReasonNotify other) {
    //       if (ReferenceEquals(other, null)) {
    //         return false;
    //       }
    //       if (ReferenceEquals(other, this)) {
    //         return true;
    //       }
    //       if (Reason != other.Reason) return false;
    //       return Equals(_unknownFields, other._unknownFields);
    //     }

    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public override int GetHashCode() {
    //       int hash = 1;
    //       if (Reason != global::OldProtos.GCGGameCreateFailReasonNotify.Types.GCGGameCreateReason.ReasonNone) hash ^= Reason.GetHashCode();
    //       if (_unknownFields != null) {
    //         hash ^= _unknownFields.GetHashCode();
    //       }
    //       return hash;
    //     }

    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public override string ToString() {
    //       return pb::JsonFormatter.ToDiagnosticString(this);
    //     }

    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public void WriteTo(pb::CodedOutputStream output) {
    //     #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    //       output.WriteRawMessage(this);
    //     #else
    //       if (Reason != global::OldProtos.GCGGameCreateFailReasonNotify.Types.GCGGameCreateReason.ReasonNone) {
    //         output.WriteRawTag(120);
    //         output.WriteEnum((int) Reason);
    //       }
    //       if (_unknownFields != null) {
    //         _unknownFields.WriteTo(output);
    //       }
    //     #endif
    //     }

    //     #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    //       if (Reason != global::OldProtos.GCGGameCreateFailReasonNotify.Types.GCGGameCreateReason.ReasonNone) {
    //         output.WriteRawTag(120);
    //         output.WriteEnum((int) Reason);
    //       }
    //       if (_unknownFields != null) {
    //         _unknownFields.WriteTo(ref output);
    //       }
    //     }
    //     #endif

    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public int CalculateSize() {
    //       int size = 0;
    //       if (Reason != global::OldProtos.GCGGameCreateFailReasonNotify.Types.GCGGameCreateReason.ReasonNone) {
    //         size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Reason);
    //       }
    //       if (_unknownFields != null) {
    //         size += _unknownFields.CalculateSize();
    //       }
    //       return size;
    //     }

    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public void MergeFrom(GCGGameCreateFailReasonNotify other) {
    //       if (other == null) {
    //         return;
    //       }
    //       if (other.Reason != global::OldProtos.GCGGameCreateFailReasonNotify.Types.GCGGameCreateReason.ReasonNone) {
    //         Reason = other.Reason;
    //       }
    //       _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    //     }

    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public void MergeFrom(pb::CodedInputStream input) {
    //     #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    //       input.ReadRawMessage(this);
    //     #else
    //       uint tag;
    //       while ((tag = input.ReadTag()) != 0) {
    //         switch(tag) {
    //           default:
    //             _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
    //             break;
    //           case 120: {
    //             Reason = (global::OldProtos.GCGGameCreateFailReasonNotify.Types.GCGGameCreateReason) input.ReadEnum();
    //             break;
    //           }
    //         }
    //       }
    //     #endif
    //     }

    //     #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    //       uint tag;
    //       while ((tag = input.ReadTag()) != 0) {
    //         switch(tag) {
    //           default:
    //             _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
    //             break;
    //           case 120: {
    //             Reason = (global::OldProtos.GCGGameCreateFailReasonNotify.Types.GCGGameCreateReason) input.ReadEnum();
    //             break;
    //           }
    //         }
    //       }
    //     }
    //     #endif

    //     #region Nested types
    //     /// <summary>Container for nested types declared in the GCGGameCreateFailReasonNotify message type.</summary>
    //     [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    //     [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    //     public static partial class Types {
    //       public enum GCGGameCreateReason {
    //         [pbr::OriginalName("REASON_NONE")] ReasonNone = 0,
    //         [pbr::OriginalName("REASON_GAME_MAX")] ReasonGameMax = 1,
    //         [pbr::OriginalName("REASON_CLIENT_VERSION_NOT_LASTEST")] ReasonClientVersionNotLastest = 2,
    //         [pbr::OriginalName("REASON_RESOURCE_NOT_COMPLETE")] ReasonResourceNotComplete = 3,
    //         [pbr::OriginalName("REASON_TIMEOUT")] ReasonTimeout = 4,
    //       }

    //     }
    //     #endregion

    //   }

    //   #endregion

    // }

    // #endregion Designer generated code
    // ```
    #endregion

    // 如你所见，它是一个由 protobuf compiler (protoc) 生成的 C# 代码文件。  
    // 由 Visual Studio 打开它，可以看到 Visual Studio 分析出其中具有以下成员：（下列表述仅方便理解，并非代码中实际出现的完整代码段，并且只包含类或枚举定义）
    // ```
    // # static class GCGGameCreateFailReasonNotifyReflection # 可以不支持 static class
    // #     ...
    // class GCGGameCreateFailReasonNotify
    //     class Types
    //         enum GCGGameCreateReason
    // ```
    // 我现在意图做一个封装类，可以获取该代码中的定义树，支持遍历与查找。  
    // 例如，获取树的根节点即可获得叶子列表 `[GCGGameCreateFailReasonNotifyReflection, GCGGameCreateFailReasonNotify]`，查询 `GCGGameCreateFailReasonNotify` 下属节点可查询到 `Types`，以此类推，等等。  
    // 我还需要每个节点都知晓其完整路径，例如查询 `GCGGameCreateReason` 的完整路径可得到 `GCGGameCreateFailReasonNotify.Types.GCGGameCreateReason`。  
    // 你还应开放可查询 `class` 和 `enum` 完整路径与始末行号的完整列表，例如，`class` 的完整列表是：
    // ```
    // GCGGameCreateFailReasonNotifyReflection, 15, 43
    // GCGGameCreateFailReasonNotify, 45, 248
    // GCGGameCreateFailReasonNotify.Types, 236, 245
    // ```
    // `enum` 的完整列表是：
    // ```
    // GCGGameCreateFailReasonNotify.Types.GCGGameCreateReason, 237, 243
    // ```
    // 请你设计一种合理的封装形式。
    // 我说的“合理的封装形式”是你只需要给出该类型定义的成员。
    // 如果是字段或属性应包括类型、名称、描述等，
    // 如果是方法或构造器应包括返回值、参数类型与名称、每个参数的描述等。
    // 不需要现在就开始撰写具体实现，也暂时不需要告诉我内部实现的形式。
    #endregion

    public partial class CodeTree
    {
        public CodeTree(string name, string type, string fullPath, int startLine, int endLine, List<CodeTree> children)
        {
            Name = name;
            Type = type;
            FullPath = fullPath;
            StartLine = startLine;
            EndLine = endLine;
            Children = new(children);
        }

        public readonly string Name; // 节点名称
        public readonly string Type; // 节点类型，例如 class、enum 等
        public readonly string FullPath; // 节点完整路径
        public readonly int StartLine; // 节点开始行号
        public readonly int EndLine; // 节点结束行号
        public ReadOnlyCollection<CodeTree> Children { get; set; } // 子节点列表
    }

    public static class CodeTreeBuilder
    {
        public static CodeTree Build(string code)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            return BuildTree(root);
        }

        private static CodeTree BuildTree(SyntaxNode node, string parentPath = "")
        {
            string name = GetName(node);
            string type = GetType(node);
            string fullPath = GetFullPath(node, parentPath);
            int startLine = node.GetLocation().GetLineSpan().StartLinePosition.Line + 1;
            int endLine = node.GetLocation().GetLineSpan().EndLinePosition.Line + 1;
            List<CodeTree> children = new();
            foreach (SyntaxNode child in node.ChildNodes())
            {
                CodeTree childTree = BuildTree(child, fullPath);
                children.Add(childTree);
            }

            return new CodeTree(name, type, fullPath, startLine, endLine, children);
        }

        private static string GetName(SyntaxNode node)
        {
            if (node is BaseTypeDeclarationSyntax)
            {
                return ((BaseTypeDeclarationSyntax)node).Identifier.ValueText;
            }
            else if (node is EnumDeclarationSyntax)
            {
                return ((EnumDeclarationSyntax)node).Identifier.ValueText;
            }
            else
            {
                return "";
            }
        }

        private static string GetType(SyntaxNode node)
        {
            if (node is BaseTypeDeclarationSyntax)
            {
                return ((BaseTypeDeclarationSyntax)node).Kind().ToString();
            }
            else if (node is EnumDeclarationSyntax)
            {
                return "enum";
            }
            else
            {
                return "";
            }
        }

        private static string GetFullPath(SyntaxNode node, string parentPath)
        {
            string name = GetName(node);
            string type = GetType(node);
            string path = parentPath + "." + name;
            if (parentPath == "")
            {
                path = name;
            }
            if (type == "enum")
            {
                path = parentPath + "." + type + "." + name;
            }
            return path.TrimStart('.');
        }
    }

    public partial class CodeTree
    {
        // prompt:
        // 很好！请你现在实现 CodeTree 的以下功能：
        // - 对该树进行完整枚举（遍历方式自选），对于每个节点类型，生成一个节点完整路径的列表。
        // 返回值类型请自选。

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">The type, like class, enum, struct, etc.</param>
        /// <returns></returns>
        private List<CodeTree> GetPathsByType(string type)
        {
            List<CodeTree> paths = new List<CodeTree>();
            if (this.Type == type)
            {
                paths.Add(this);
            }
            foreach (CodeTree child in this.Children)
            {
                paths.AddRange(child.GetPathsByType(type));
            }
            return paths;
        }
    }

    #region Human Written
    public enum CodeTreeQueryType
    {
        Class = 0,
        Interface = 1,
        Enum = 2,
        Struct = 3
    }

    public partial class CodeTree
    {
        public List<CodeTree> GetPathsByType(CodeTreeQueryType query)
            => GetPathsByType($"{query}Declaration");
    }

    public partial class CodeTree : IEnumerable<CodeTree>
    {
        public IEnumerator<CodeTree> GetEnumerator()
        {
            return new CodeTreeEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
#pragma warning disable CS8625 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
    public class CodeTreeEnumerator : IEnumerator<CodeTree>
    {
        public readonly CodeTree Root;
        private int index = -1;
        private CodeTreeEnumerator? sub_enumerator;
        public CodeTree Current { get; private set; }

        object IEnumerator.Current => Current;

        public CodeTreeEnumerator(CodeTree root)
        {
            Root = root;
            Current = null;
        }

        public bool MoveNext()
        {
            if (index <= -1)
            {
                index = 0;
                Current = Root;
                if (Root.Children.Count > 0) sub_enumerator = new(Root.Children[index]);
                else sub_enumerator = null;
                return true;
            }
            else
            {
                if (sub_enumerator == null) return false;
                bool res = sub_enumerator.MoveNext();
                if (res)
                {
                    Current = sub_enumerator.Current;
                    return true;
                }
                else
                {
                    index++;
                    if (index >= Root.Children.Count) return false;
                    else
                    {
                        sub_enumerator = new(Root.Children[index]);
                        return MoveNext();
                    }
                }
            }
        }

        public void Reset()
        {
            // index = -1;
            // Current = null;
            // sub_enumerator = null;
            throw new NotSupportedException();
        }

        #region IDisposeable
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~CodeTreeEnumerator()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
#pragma warning restore CS8625 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
    #endregion
}
