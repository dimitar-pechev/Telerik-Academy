using Academy.Commands.Adding;
using Academy.Core.Contracts;

namespace Academy.Tests.Commands.Mocks
{
    internal class AddStudentToCourseCommandMock : AddStudentToCourseCommand
    {
        public AddStudentToCourseCommandMock(IAcademyFactory factory, IEngine engine) : base(factory, engine)
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
