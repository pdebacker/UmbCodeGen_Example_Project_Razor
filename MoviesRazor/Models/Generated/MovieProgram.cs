    //
    // Auto generated content. Do not modify.
    //
    namespace MoviesRazor.Models
    {
        using System;
        using System.Collections.Generic;

    [DocumentType("MovieProgram")]
            public partial class MovieProgram : ModelBase
          {
             [Property("movieProgram_name")]
      public string Name { get; set; }
    
                    [Property("movieProgram_showtimes")]
      public List<DateTime> Showtimes { get; set; }
    
                    [Property("movieProgram_additional_information")]
      public string AdditionalInformation { get; set; }
    
                    [Property("movieProgram_movie_link")]
      public Hyperlink MovieLink { get; set; }
    
                    [Property("movieProgram_spoken_language")]
      public Languages SpokenLanguage { get; set; }
    
                    [Property("movieProgram_subtitles")]
      public bool Subtitles { get; set; }
    
                    [Property("movieProgram_threeD")]
      public bool ThreeD { get; set; }
    
                            };

            }
    