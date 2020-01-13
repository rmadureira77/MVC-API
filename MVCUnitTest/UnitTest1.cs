using Xunit;

namespace MVCUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var controller = new _03_PortalMVC.Controllers.EmpregadosController();

            // act
            var result = controller.Index();


            // assert

            Assert.Equal(1, result.Id);
        }
    }
}
