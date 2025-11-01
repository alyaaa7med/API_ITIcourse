namespace api_lab2.DTOs
{
    public class UnitStudentDTO
    {

        public int Id { get; set; }
        public string? St_FName { get; set; }
        public string? St_LName { get; set; }

        /*
        You want to send both student info and department info in one request.
        So your StudentCreateDTO will contain a nested DepartmentDTO
        */
        public UnitDepartmentDTO? ddto { get; set; }
    }
}
