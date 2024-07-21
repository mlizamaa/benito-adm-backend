// importa las librerias de dapper
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Benito.Model {
    public class BenitoBaseEntity
    {

        [Key]
	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public Guid Id { get; set; }
        
        //[Column("FullName", TypeName="nvarchar(50)")]
        public DateTime FecCrea { get; set; }
        public DateTime? FecModifica { get; set; }
        public DateTime? FecElimina { get; set; }
        public bool McaActivo { get; set; }
        public bool? McaEliminado { get; set; }
        public  Guid     UsuCrea { get; set; }
        public Guid? UsuModifica { get; set; }
        public Guid? UsuElimina { get; set; }

        public BenitoBaseEntity()
        {
            this.Id = Guid.NewGuid();
            this.FecCrea = DateTime.Now;
            this.FecModifica = DateTime.Now;
            this.McaActivo = true;
            this.McaEliminado = false;
            this.UsuCrea = Guid.NewGuid();
            this.UsuModifica = null;
            this.UsuElimina = null;
        }

        public BenitoBaseEntity(Guid guid, 
            DateTime fecCrea, 
                DateTime fecModifica, 
                    bool mcaActivo, 
                        bool mcaEliminado, 
                            Guid usuCrea, 
                                Guid usuModifica, 
                                    Guid usuElimina)
        {
            this.Id = guid;
            this.FecCrea = fecCrea;
            this.FecModifica = fecModifica;
            this.McaActivo = mcaActivo;
            this.McaEliminado = mcaEliminado;
            this.UsuCrea = usuCrea;
            this.UsuModifica = usuModifica;
            this.UsuElimina = usuElimina;
        }
        

    }
    
}