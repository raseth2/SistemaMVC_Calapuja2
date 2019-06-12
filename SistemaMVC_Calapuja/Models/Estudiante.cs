namespace SistemaMVC_Calapuja.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Estudiante")]
    public partial class Estudiante
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int estudiante_id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int estudiante_codigo { get; set; }

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

        [Required]
        [StringLength(250)]
        public string direccion { get; set; }

        [StringLength(15)]
        public string celular { get; set; }

        [StringLength(250)]
        public string foto { get; set; }

        [StringLength(1)]
        public string estado { get; set; }




        //metodo listar
        public List<Estudiante> Listar()//Retorna una coleccion de registros
        {
            var objEstudiante = new List<Estudiante>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    objEstudiante = db.Estudiante.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEstudiante;
        }

        //metodo obtener
        public Estudiante Obtener(int id)//retorna solo un objeto
        {
            var objEstudiante = new Estudiante();
            try
            {
                using (var db = new Model_Sistema())
                {
                    objEstudiante = db.Estudiante
                        .Where(x => x.estudiante_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEstudiante;
        }

        //metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Model_Sistema())
                {
                    if (this.estudiante_id > 0)
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
