//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Backend.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class info_usuario
    {
        public int idUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public System.DateTime Fecha_de_Nacimiento { get; set; }
        public decimal Peso { get; set; }
        public string Categoria_Edad { get; set; }
        public string Categoria_Peso { get; set; }
    }
}