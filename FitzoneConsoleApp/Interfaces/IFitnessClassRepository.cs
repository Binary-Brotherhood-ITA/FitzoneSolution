using FitzoneConsoleApp.Domain;

namespace FitzoneConsoleApp.Interfaces
{

    public interface IFitnessClassRepository
    {
        List<FitnessClass> GetUpcoming(DateTime now);

        FitnessClass? GetById(string classId);

        FitnessClass? getSelectedClass(string classId);
    }

}
