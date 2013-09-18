    //
    // Auto generated content. Do not modify.
    //
    namespace MoviesRazor.Models
    {
        using System;
        using System.Collections.Generic;

    [DocumentType("NewsItem")]
            public partial class NewsItem : ModelBase
          {
             [Property("newsItemTitle")]
      public string Title { get; set; }
    
                    [Property("newsItemIntroShort")]
      public string IntroShort { get; set; }
    
                    [Property("newsItemDate")]
      public DateTime Date { get; set; }
    
                    [Property("newsItemSource")]
      public string Source { get; set; }
    
                            };

            }
    