﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProyectoEntities1 : DbContext
    {
        public ProyectoEntities1()
            : base("name=ProyectoEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<info_usuario> info_usuario { get; set; }
        public virtual DbSet<reporte_formas> reporte_formas { get; set; }
    
        public virtual int calificar(Nullable<int> juez, Nullable<decimal> cal, Nullable<int> idTorneo, Nullable<int> idUsuario)
        {
            var juezParameter = juez.HasValue ?
                new ObjectParameter("juez", juez) :
                new ObjectParameter("juez", typeof(int));
    
            var calParameter = cal.HasValue ?
                new ObjectParameter("cal", cal) :
                new ObjectParameter("cal", typeof(decimal));
    
            var idTorneoParameter = idTorneo.HasValue ?
                new ObjectParameter("idTorneo", idTorneo) :
                new ObjectParameter("idTorneo", typeof(int));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("calificar", juezParameter, calParameter, idTorneoParameter, idUsuarioParameter);
        }
    
        public virtual int Categoria(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Categoria", idParameter);
        }
    
        public virtual int fichacombate(Nullable<int> id, Nullable<int> idTorneo, string color, Nullable<int> res)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var idTorneoParameter = idTorneo.HasValue ?
                new ObjectParameter("idTorneo", idTorneo) :
                new ObjectParameter("idTorneo", typeof(int));
    
            var colorParameter = color != null ?
                new ObjectParameter("color", color) :
                new ObjectParameter("color", typeof(string));
    
            var resParameter = res.HasValue ?
                new ObjectParameter("res", res) :
                new ObjectParameter("res", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("fichacombate", idParameter, idTorneoParameter, colorParameter, resParameter);
        }
    
        public virtual int fichaforma(Nullable<int> id, Nullable<int> idTorneo, string tipo, string nombre, Nullable<int> duracion, Nullable<int> res, Nullable<decimal> cal)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var idTorneoParameter = idTorneo.HasValue ?
                new ObjectParameter("idTorneo", idTorneo) :
                new ObjectParameter("idTorneo", typeof(int));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var duracionParameter = duracion.HasValue ?
                new ObjectParameter("duracion", duracion) :
                new ObjectParameter("duracion", typeof(int));
    
            var resParameter = res.HasValue ?
                new ObjectParameter("res", res) :
                new ObjectParameter("res", typeof(int));
    
            var calParameter = cal.HasValue ?
                new ObjectParameter("cal", cal) :
                new ObjectParameter("cal", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("fichaforma", idParameter, idTorneoParameter, tipoParameter, nombreParameter, duracionParameter, resParameter, calParameter);
        }
    
        public virtual int hacertorneo(string nombre, string sede, string logo, Nullable<System.DateTime> fecha, Nullable<System.DateTime> hora, Nullable<int> id)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var sedeParameter = sede != null ?
                new ObjectParameter("sede", sede) :
                new ObjectParameter("sede", typeof(string));
    
            var logoParameter = logo != null ?
                new ObjectParameter("logo", logo) :
                new ObjectParameter("logo", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var horaParameter = hora.HasValue ?
                new ObjectParameter("Hora", hora) :
                new ObjectParameter("Hora", typeof(System.DateTime));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("hacertorneo", nombreParameter, sedeParameter, logoParameter, fechaParameter, horaParameter, idParameter);
        }
    
        public virtual int promedio()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("promedio");
        }
    
        public virtual int registrar(string usuario, string email, string pass, string nombre, string apepat, string apemat, Nullable<System.DateTime> fnac, Nullable<decimal> peso, Nullable<int> grado, string genero, Nullable<int> idcatEdad, Nullable<int> idcatPeso)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("usuario", usuario) :
                new ObjectParameter("usuario", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apepatParameter = apepat != null ?
                new ObjectParameter("apepat", apepat) :
                new ObjectParameter("apepat", typeof(string));
    
            var apematParameter = apemat != null ?
                new ObjectParameter("apemat", apemat) :
                new ObjectParameter("apemat", typeof(string));
    
            var fnacParameter = fnac.HasValue ?
                new ObjectParameter("fnac", fnac) :
                new ObjectParameter("fnac", typeof(System.DateTime));
    
            var pesoParameter = peso.HasValue ?
                new ObjectParameter("Peso", peso) :
                new ObjectParameter("Peso", typeof(decimal));
    
            var gradoParameter = grado.HasValue ?
                new ObjectParameter("Grado", grado) :
                new ObjectParameter("Grado", typeof(int));
    
            var generoParameter = genero != null ?
                new ObjectParameter("Genero", genero) :
                new ObjectParameter("Genero", typeof(string));
    
            var idcatEdadParameter = idcatEdad.HasValue ?
                new ObjectParameter("idcatEdad", idcatEdad) :
                new ObjectParameter("idcatEdad", typeof(int));
    
            var idcatPesoParameter = idcatPeso.HasValue ?
                new ObjectParameter("idcatPeso", idcatPeso) :
                new ObjectParameter("idcatPeso", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("registrar", usuarioParameter, emailParameter, passParameter, nombreParameter, apepatParameter, apematParameter, fnacParameter, pesoParameter, gradoParameter, generoParameter, idcatEdadParameter, idcatPesoParameter);
        }
    }
}