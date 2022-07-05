using AutoMapper;
using MarineFarm.Data;
using MarineFarm.Entitys;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Services.SaveDailytest
{
    /// <summary>
    /// clase donde ocurre la magia
    /// </summary>
    public class SaveMuestrasDiarias : ISaveMuestrasDiarias
    {
        #region ctor
        private readonly IServiceProvider provider;
        private readonly IMapper mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="mapper"></param>
        public SaveMuestrasDiarias(IServiceProvider provider, IMapper mapper)
        {
            this.provider = provider;
            this.mapper = mapper;
        }
        #endregion
        

        #region save
        /// <summary>
        /// para almacenar las muestras diarias sin necesidad de pasarle el contexto de datos
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Save(MuestraDiaria ins)
        {
            try
            {
                await using(var scope = provider.CreateAsyncScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var ent = await context.MuestrasDiarias.Where(y => y.Empaquetadoid == ins.Empaquetadoid
                   && y.Calibreid == ins.Calibreid
                   && y.TipoProduccionid == ins.TipoProduccionid
                   && y.Mariscoid == ins.Mariscoid
                   && y.mes == ins.mes
                   && y.ano == ins.ano
                    ).FirstOrDefaultAsync();

                    if(ent == null)
                        context.Add(ins);
                    else
                    {
                        ent.TotalProducido += ins.ProduccionDiaria;
                        ent.ProduccionDiaria = (ent.ProduccionDiaria + ins.ProduccionDiaria) / 2;
                    }
                        await context.SaveChangesAsync();

                }
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }
        }


        #endregion
    }
}
