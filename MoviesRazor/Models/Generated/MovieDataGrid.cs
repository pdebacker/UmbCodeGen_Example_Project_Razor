    //
    // Auto generated content. Do not modify.
    //
    namespace MoviesRazor.Models
    {
        using System;
        using System.Collections.Generic;

    using System.Runtime.Serialization;
        
            public partial class MovieDataGrid : DataGrid
            {
                public MovieDataGrid()
                {
                    Items = new  List<Item>();
                }
                public List<Item> Items;

                public partial class Item
                {
                    public string TextField { get; set; }
                        public bool CheckboxField { get; set; }
                        public int IntegerField { get; set; }
                        public DropDownColors ColorField { get; set; }
                        public DateTime DateTimePickerField { get; set; }
                        public DateTime DateTimeValueField { get; set; }
                                        }
            }

            
            [DataContract(Name = "MovieDataGrid", Namespace = "")]
            internal class _MovieDataGrid
            {
                public _MovieDataGrid()
                {
                    Items = new List<Item>();
                }

                [DataMember(Name = "items")]
                public List<Item> Items;

                [DataContract(Name = "item", Namespace = "")]
                public class Item
                {
                                                                [DataMember(Name = "textField", Order = 0)]
                        public string textField;
                                                [DataMember(Name = "checkboxField", Order = 1)]
                        public string checkboxField;
                                                [DataMember(Name = "int_integerField", Order = 2)]
                        public string int_integerField;
                                                [DataMember(Name = "colorField", Order = 3)]
                        public string colorField;
                                                [DataMember(Name = "dateTimePickerField", Order = 4)]
                        public string dateTimePickerField;
                                                [DataMember(Name = "dateTimeValueField_datetime", Order = 5)]
                        public string dateTimeValueField_datetime;
                                        }
            }

                }
    