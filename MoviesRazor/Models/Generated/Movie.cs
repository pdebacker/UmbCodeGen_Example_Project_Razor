    //
    // Auto generated content. Do not modify.
    //
    namespace MoviesRazor.Models
    {
        using System;
        using System.Collections.Generic;

    [DocumentType("Movie")]
            public partial class Movie : ModelBase
          {
             [Property("movieTitle")]
      public string Title { get; set; }
    
                    [Property("movieIntroduction")]
      public string Introduction { get; set; }
    
                    [Property("movieGenre")]
      public int Genre { get; set; }
    
                    [Property("movieImage")]
      public MediaInfo Image { get; set; }
    
                    [Property("movieRelatedMovies")]
      public List<int> RelatedMovies { get; set; }
    
                    [Property("movieDirectedBy")]
      public string DirectedBy { get; set; }
    
                    [Property("movieWriter")]
      public string Writer { get; set; }
    
                    [Property("movieCast")]
      public string Cast { get; set; }
    
                    [Property("movieRunningLength_int")]
      public int RunningLength { get; set; }
    
                            };

            }
    