namespace SistemaMVC_Calapuja.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Semestre")]
    public partial class Semestre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Semestre()
        {
            Actividad = new HashSet<Actividad>();
        }

        [Key]
        public int semestre_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        public int? anio { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actividad> Actividad { get; set; }



        //metodo listar
        public List<Semestre> Listar()//Retorna una coleccion de registros
        {
            var objSemestre = new List<Semestre>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    objSemestre = db.Semestre.ToList();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return objSemestre;
        }

        //metodo obtener
        public Semestre Obtener(int id)//retorna solo un objeto
        {
            var objSemestre = new Semestre();
            try
            {
                using (var db = new Model_Sistema())
                {
                    objSemestre = db.Semestre
                        .Where(x=> x.semestre_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objSemestre;
        }

        //metodo guardar
        public void Guardar()//retorna solo un objeto
        {
            
            try
            {
                using (var db = new Model_Sistema())
                {
                    if (this.semestre_id > 0)
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
