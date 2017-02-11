using Academy.Commands.Adding;
using Academy.Core.Contracts;

namespace Academy.Tests.Commands.Adding
{
    internal class AddStudentsToSeasonCommandMock : AddStudentToSeasonCommand
    {
        public AddStudentsToSeasonCommandMock(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public IAcademyFactory Factory
        {
            get
            {
                return this.factory;
            }
        }

        public IEngine Engine
        {
            get
            {
                return this.engine;
            }
        }
    }
}
