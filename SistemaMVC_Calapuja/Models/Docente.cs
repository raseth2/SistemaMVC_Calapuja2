namespace SistemaMVC_Calapuja.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Docente")]
    public partial class Docente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Docente()
        {
            ControlAsignacion = new HashSet<ControlAsignacion>();
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int docente_id { get; set; }

        public int docente_codigo { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(100)]
        public string apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(1)]
        public string sexo { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(15)]
        public string celular { get; set; }

        [Required]
        [StringLength(250)]
        public string cargo { get; set; }

        [Required]
        [StringLength(30)]
        public string condicion { get; set; }

        [Required]
        [StringLength(50)]
        public string categoria { get; set; }

        [StringLength(250)]
        public string foto { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ControlAsignacion> ControlAsignacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }




        //metodo listar
        public List<Docente> Listar()//Retorna una coleccion de registros
        {
            var objDocente = new List<Docente>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    objDocente = db.Docente.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDocente;
        }

        //metodo obtener
        public Docente Obtener(int id)//retorna solo un objeto
        {
            var objDocente = new Docente();
            try
            {
                using (var db = new Model_Sistema())
                {
                    objDocente = db.Docente
                        .Where(x => x.docente_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDocente;
        }

        //metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Model_Sistema())
                {
                    if (this.docente_id > 0)
                    {
                        //si existe un valor mayor a 0 es porque existe un registro
                        db.Entry(this).State = EntityState.Modified;

                    }
                    else
                    {
                        //si no existe registro graba(nuevo registro)
                        db.Entry(this).State = EntityState.Added;

                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //metodo Eliminar
        public void Eliminar()
        {

            try
            {
                using (var db = new Model_Sistema())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
