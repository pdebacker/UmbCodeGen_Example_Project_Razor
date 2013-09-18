using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace MoviesRazor.Models
{
    [MetadataType(typeof(TestModelMetaData))]
    public partial class TestModel
    {
        public string Title { get; set; }
        public DateTime TimeStamp { get; set; }

        [Property("contentPicker")]
        public Movie ContentPickerMovie { get; set; }

        [Property("multiNodeTreePickerField")]
        public List<Movie> MultiNodeTreePickerMoviesField { get; set; }

        [ScriptIgnore()]
        public string NotInJsonOutputProperty { get; set; }

        [Children("Paragraph", true)]
        public List<Paragraph> Paragraphs { get; set; }
    }

    public class TestModelMetaData
    {
        [DateTimeFormat("M-d-yyyy HH:mm")]
        public DateTime DateTimeWithPrefix { get; set; }

        [DateTimeFormat("d/M/yyyy HH:mm")]
        public DateTime DateTimeWithPostfix { get; set; }
    }

}