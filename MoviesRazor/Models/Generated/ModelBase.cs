    //
    // Auto generated content. Do not modify.
    //
    namespace MoviesRazor.Models
    {
        using System;
        using System.Collections.Generic;

        using System.Runtime.Serialization;

    #region Attributes

        [AttributeUsage(AttributeTargets.Property)]
        public abstract class AliasAttribute : Attribute
        {
            public string Alias { get; set; }
            public AliasAttribute() { }
            public AliasAttribute(string alias)
            {
                this.Alias = alias;
            }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class PropertyAttribute : AliasAttribute
        {
            public PropertyAttribute() { }
            public PropertyAttribute(string alias) : base(alias)
            {
            }
        }

        [AttributeUsage(AttributeTargets.Class)]
        public class DocumentTypeAttribute : AliasAttribute
        {
            public DocumentTypeAttribute() { }
            public DocumentTypeAttribute(string alias) : base(alias)
            {
            }
        }


        [AttributeUsage(AttributeTargets.Property)]
        public class ChildrenAttribute : Attribute
        {
            public string NodeAlias { get; set; }
            public bool AllDescendants { get; set; }

            public ChildrenAttribute() { }
            public ChildrenAttribute(string nodeAlias) : this(nodeAlias, false) { }
            public ChildrenAttribute(string nodeAlias, bool allDescentants = false)
            {
                this.NodeAlias = nodeAlias;
                this.AllDescendants = allDescentants;
            }
        }

		[AttributeUsage(AttributeTargets.Property)]
        public class DateTimeFormatAttribute : Attribute
        {
			public string DateTimeFormat { get; set; }

            public DateTimeFormatAttribute() { }
            public DateTimeFormatAttribute(string format)
            {
				this.DateTimeFormat = format;
            }
        }
    #endregion
    #region Base Models

        public abstract partial class ModelBase
        {
           [Property("NodeId")]
           public int NodeId { get; set; }
           [Property("NodeName")]
           public string NodeName { get; set; }
           [Property("NodeUrl")]
           public string NodeUrl { get; set; }
        }

        public abstract partial class DataGrid
        {
        }

        public class MediaInfo
        {
           public int Id { get; set; }
           public string Url { get; set; }
        }

        public class Hyperlink
        {
            public bool NewWindow;
            public int NodeId;
            public string Url;
            public string LinkTitle;
        }

        public class HyperlinkList : List<Hyperlink> { }

    #endregion
    #region Default Serialization models

    
        [DataContract(Name = "MultiNodePickerContract", Namespace = "")]
        public class MultiNodePicker
        {
            [DataMember(Name = "MultiNodePicker")]
            public NodeIdList NodeIdList;
        }

		public class StringList : List<string> { }
		public class IntList : List<int> { }

        [CollectionDataContract(ItemName = "nodeId", Namespace = "")]
        public class NodeIdList : IntList { }


        [DataContract(Name = "MultiUrlPicker", Namespace = "")]
        public class MultiUrlPicker
        {
            [DataMember(Name = "multi-url-picker", Order = 0)]
            public _HyperlinkList Links;
        }

        [DataContract(Name = "url-picker", Namespace = "")]
        public class _Hyperlink
        {
            [DataMember(Name = "new-window", Order = 0)]
            public string NewWindow;

            [DataMember(Name = "node-id", Order = 1)]
            public string NodeId;

            [DataMember(Name = "url", Order = 2)]
            public string Url;

            [DataMember(Name = "link-title", Order = 3)]
            public string LinkTitle;
        }

        public class _HyperlinkList : List<_Hyperlink> { }

		[DataContract(Name = "SqlCheckBoxListContract", Namespace = "")]
		public class _SqlCheckBoxList
		{
			[DataMember(Name = "SqlCheckBoxList")]
			public SqlCheckBoxValues Values { get; set;}
		}

		[CollectionDataContract(ItemName = "value", Namespace = "")]
		public class SqlCheckBoxValues : StringList { } 

    #endregion

        }
    