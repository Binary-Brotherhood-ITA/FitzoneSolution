using FitzoneConsoleApp.Domain;

namespace FitzoneConsoleApp.Interfaces
{

    public interface IMemberRepository
    {
        Member? GetByMemberNo(string memberNo);
    }
}

