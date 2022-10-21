using Primeira_Tarefa.Types;

namespace Primeira_Tarefa.DataBase
{
    public class BrandDataBase
    {
        public static List<Brand> brandList = new List<Brand>()
        {
            new Brand() { Id = 1, Description = "Victoria Summa ", Status = true, MainProvider_Name =  "Igris"},
            new Brand() { Id = 2, Description = "Lux Mane", Status = false, MainProvider_Name =  "Lucius"},
            new Brand() { Id = 3, Description = "Ignis Vivus", Status = true, MainProvider_Name =  "Balerion" },
            new Brand() { Id = 4, Description = "Vozrozhdennoye Bratstvo", Status = false, MainProvider_Name =  "Irina" },
            new Brand() { Id = 5, Description = "Excidium Regnorum", Status = true, MainProvider_Name =  "Balerion" },
            new Brand() { Id = 6, Description = "Fall av Jotunheim", Status = true, MainProvider_Name =  "Wotan" }
        };

        public List<Brand> BrandList => brandList;
    }
}
