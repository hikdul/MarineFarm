using MarineFarm.Entitys;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para mostrar los datos de las equipos
    /// </summary>
    public class EquipoDTO_out
    {
        #region props
        /// <summary>
        /// id del turno de equipo
        /// </summary>
        public int Turnoid { get; set; }
        /// <summary>
        /// nombre del turno
        /// </summary>
        public string NombreTurno { get; set; }
        /// <summary>
        /// descripcion del turno
        /// </summary>
        public string DescTurno { get; set; }
        /// <summary>
        /// lista de cargos
        /// </summary>
        public List<CargoEquipo_out> Cargos{ get; set; }
        /// <summary>
        /// operadores que necesita el turno
        /// </summary>
        public int operadoresNecesarios { get; set; }
        /// <summary>
        /// operadores que estan activos
        /// </summary>
        public int operadoresCubiertos { get; set; }

        #endregion

        #region ctor
        /// <summary>
        /// empty
        /// </summary>
        public EquipoDTO_out()
        {
            this.Turnoid = 0;
            this.NombreTurno = String.Empty;
            this.DescTurno = String.Empty;
            this.Cargos = new();
        }

        /// <summary>
        /// para un solo elemento
        /// </summary>
        /// <param name="list"></param>
        /// <param name="turno"></param>
        public EquipoDTO_out(List<Equipo> list, Turnos turno)
        {
            this.Turnoid = turno.id;
            this.DescTurno = turno.Desc;
            this.NombreTurno = turno.Name;
            this.Cargos = new();

            var flag = list.Where(x => x.Turnoid == turno.id).ToList();

            if (flag.Any())
                foreach (var element in flag)
                    this.Cargos.Add(new()
                    {
                        CantCubierta = element.CantCubierta,
                        CantOperadoresNecesario = element.Cargo.CantOperadoresNecesario,
                        CostoOperario = element.CostoOperario,
                        Desc = element.Cargo.Desc,
                        Name = element.Cargo.Name,
                        id = element.Cargo.id
                    });

        }

        #endregion

        #region llenar data
        /// <summary>
        /// para llenar los datos necesarios
        /// </summary>
        /// <param name="list"></param>
        /// <param name="turnos"></param>
        /// <returns></returns>
        public static List<EquipoDTO_out> Up(List<Equipo> list, List<Turnos>  turnos)
        {
            int SumOC = 0;
            int SumON = 0;
            List<EquipoDTO_out> ret = new();
            if(turnos == null || turnos.Count == 0 || list == null || list.Count == 0)
                return ret;

            foreach (var turno in turnos)
            {
                EquipoDTO_out aux = new();

                aux.Turnoid = turno.id;
                aux.DescTurno = turno.Desc;
                aux.NombreTurno = turno.Name;

                var flag = list.Where(x => x.Turnoid == turno.id).ToList();

                if (flag.Any())
                    foreach (var element in flag)
                    {
                        aux.Cargos.Add(new()
                        {
                            CantCubierta = element.CantCubierta,
                            CantOperadoresNecesario = element.Cargo.CantOperadoresNecesario,
                            CostoOperario = element.CostoOperario,
                            Desc = element.Cargo.Desc,
                            Name = element.Cargo.Name,
                            id = element.Cargo.id
                        });
                        SumOC = element.CantCubierta;
                        SumON = element.Cargo.CantOperadoresNecesario;
                    }
                aux.operadoresCubiertos = SumOC;
                aux.operadoresNecesarios = SumON;

                ret.Add(aux);
            }

            return ret;
        }

      

        #endregion
    }

    #region subclase
    /// <summary>
    /// los datos por equipo
    /// </summary>
    public class CargoEquipo_out 
    {

        public int id { get; set; }
        /// <summary>
        /// nombre del cargo
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// descripcion del cargo
        /// </summary>
        public string Desc { get; set; } = string.Empty;
        /// <summary>
        /// Cantidad Operadores Necesaria
        /// </summary>
        public int CantOperadoresNecesario { get; set; } = 1;
        /// <summary>
        /// cantidad cubierta
        /// </summary>
        public int CantCubierta { get; set; }
        /// <summary>
        /// Costo por operario
        /// </summary>
        public double CostoOperario { get; set; }

    }
    #endregion

}
