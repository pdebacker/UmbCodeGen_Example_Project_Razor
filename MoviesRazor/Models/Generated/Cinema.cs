    //
    // Auto generated content. Do not modify.
    //
    namespace MoviesRazor.Models
    {
        using System;
        using System.Collections.Generic;

    [DocumentType("Cinema")]
            public partial class Cinema : ModelBase
          {
             [Property("cinemaName")]
      public string Name { get; set; }
    
                    [Property("cinemaAddressStreet")]
      public string AddressStreet { get; set; }
    
                    [Property("cinemaAddressNumber")]
      public string AddressNumber { get; set; }
    
                    [Property("cinemaAddressPostalCode")]
      public string AddressPostalCode { get; set; }
    
                    [Property("cinemaAddressCity")]
      public string AddressCity { get; set; }
    
                    [Property("cinemaContactEmail")]
      public string ContactEmail { get; set; }
    
                    [Property("cinemaContactPhoneNumber")]
      public string ContactPhoneNumber { get; set; }
    
                    [Property("cinemaContactWebsite")]
      public Hyperlink ContactWebsite { get; set; }
    
                            };

            }
    