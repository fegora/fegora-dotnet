using System;
using System.Collections.Generic;

namespace Fegora.Servicios.Model
{    
    [Serializable]
    public partial class ListadoPaginado<T>
    {        
        public List<T> Data { get; set; }
        
        public MetaPagina Meta { get; set; }
       
        public LinksPagina Links { get; set; }
    }

    [Serializable]   
    public partial class MetaPagina
    {        
        public Nullable<System.Int64> TotalItems { get; set; }
                    
        public Nullable<System.Int64> TotalPages { get; set; }
                    
        public Nullable<System.Int32> PageNumber { get; set; }
        
        public Nullable<System.Int32> PageSize { get; set; }
    }

    [Serializable]
    public partial class LinksPagina
    {        
        public System.String Self { get; set; }
        
        public System.String Prev { get; set; }
        
        public System.String Next { get; set; }
        
        public System.String First { get; set; }
        
        public System.String Last { get; set; }
    }
    
}
