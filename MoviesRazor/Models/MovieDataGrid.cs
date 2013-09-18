using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesRazor.Models
{
    public partial class MovieDataGrid
    {
        [MetadataType(typeof(Item_Meta))]
        public partial class Item
        {
        }

        public class Item_Meta
        {
            [DateTimeFormat("yyyy-MM-dd HH:mm")]
            public DateTime DateTimeValueField { get; set; }
        }

    }


}