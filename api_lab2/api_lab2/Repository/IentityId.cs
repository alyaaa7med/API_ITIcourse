namespace api_lab2.Repository
{

    //i make it as the pk names in student , department are not the same and i need it same name to be used in the generic repo
    //but i need to keep their names in the database 
    public interface IentityId
    {
        public int Id { get; set; }
    }
}
