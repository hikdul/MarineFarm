using AutoMapper;
using MarineFarm.Data;
using MarineFarm.Entitys;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{
    public class MateriaPrimaDTO_in
    {
        #region props
        /// <summary>
        /// marisco al que pertenece
        /// </summary>
        [Required]
        public int Mariscoid { get; set; }
        /// <summary>
        /// cantidad a agregar o restar
        /// </summary>
        [Range(double.MinValue, double.MaxValue)]
        public double Cantidad { get; set; } = 0;
        #endregion

        #region ctor
        /// <summary>
        /// empty
        /// </summary>
        public MateriaPrimaDTO_in()
        {

        }
        /// <summary>
        /// del dto que envia solo enteros
        /// </summary>
        /// <param name="dto"></param>
        public MateriaPrimaDTO_in(IntDTO_in dto)
        {
            this.Mariscoid = dto.id;
            this.Cantidad = dto.valor;
        }


        #endregion

        #region add
        /// <summary>
        /// para agregar mas datos a un marisco
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public async Task<MateriaPrimaDTO_out> Add(ApplicationDbContext context, IMapper mapper)
        {
            try
            {
                var exist = await context.MateriasPrimas.Where(x => x.Mariscoid == this.Mariscoid).FirstOrDefaultAsync();

                var ent = mapper.Map<MateriaPrima>(this);

                if (exist == null || exist.id < 1)
                {
                    context.Add(ent);
                    await context.SaveChangesAsync();
                    ent = await context.MateriasPrimas
                        .Include(x => x.Marisco)
                        .Where( x => x.id == ent.id)
                        .FirstOrDefaultAsync();

                    return mapper.Map<MateriaPrimaDTO_out>(ent);
                }
                else
                {
                    exist.Cantidad += this.Cantidad;
                    await context.SaveChangesAsync();
                    exist.Marisco = await context.Mariscos
                        .Where(x => x.id == this.Mariscoid)
                        .FirstOrDefaultAsync();

                    return mapper.Map<MateriaPrimaDTO_out>(exist);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new();
            }


        }

        #endregion

        #region Substract
        /// <summary>
        /// para agregar mas datos a un marisco
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public async Task<MateriaPrimaDTO_out> Substract(ApplicationDbContext context, IMapper mapper)
        {
            try
            {
                var exist = await context.MateriasPrimas.Where(x => x.Mariscoid == this.Mariscoid).FirstOrDefaultAsync();

                var ent = mapper.Map<MateriaPrima>(this);

                if (exist == null || exist.id < 1)
                {
                    ent.Cantidad = 0;
                    context.Add(ent);
                    await context.SaveChangesAsync();
                    ent = await context.MateriasPrimas
                  .Include(x => x.Marisco)
                  .Where(x => x.id == ent.id)
                  .FirstOrDefaultAsync();
                }
                else
                {
                    exist.Cantidad -= this.Cantidad;
                    if(exist.Cantidad < 0)
                        exist.Cantidad = 0;
                    await context.SaveChangesAsync();
                    ent = await context.MateriasPrimas
                  .Include(x => x.Marisco)
                  .Where(x => x.id == exist.id)
                  .FirstOrDefaultAsync();
                }

                ent = await context.MateriasPrimas
                   .Include(x => x.Marisco)
                   .Where(x => x.id == ent.id)
                   .FirstOrDefaultAsync();

                return mapper.Map<MateriaPrimaDTO_out>(ent);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new();
            }


        }

        #endregion


    }
}
