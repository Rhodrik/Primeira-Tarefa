namespace Primeira_Tarefa.DataBase
{
    public class GroupDatabase
    {
        private static List<Group> groupList = new List<Group>()
        {
            new Group { Id = 1, Description = "Bellator", Status = true, UseSubgroup = true},
            new Group { Id = 2, Description = "Divinus", Status = true, UseSubgroup = true},
            new Group { Id = 3, Description = "Vastatio", Status = true, UseSubgroup = true},
            new Group { Id = 4, Description = "Vozrozhdeniye ", Status = true, UseSubgroup = true},
            new Group { Id = 5, Description = "Vastatio ", Status = true, UseSubgroup = true},
            new Group { Id = 6, Description = "Utryddelse ", Status = true, UseSubgroup = true},
        };

        public List<Group> GroupList => groupList;
    }
}
