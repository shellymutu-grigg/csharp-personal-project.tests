using csharp_personal_project.BusinessLogic;
using Moq;

namespace csharp_personal_project.tests.BusinessLogic
{
    public class GardenAreaServiceTests
	{
        private Mock<MetricSurfaceCalculator> _metricSurfaceCalculator;
		private Mock<ImperialSurfaceCalculator> _imperialSurfaceCalculator;
		private GardenAreaService? _underTest;

		[SetUp]
        public void Setup()
        {
			_metricSurfaceCalculator = new Mock<MetricSurfaceCalculator>();
			_imperialSurfaceCalculator = new Mock<ImperialSurfaceCalculator>();
		}

		[TestCase(0, 2, ExpectedResult = 0)]
		[TestCase(3, 0, ExpectedResult = 0)]
		[TestCase(2, 4, ExpectedResult = 8)]
		[TestCase(-1, 4, ExpectedResult = 0)]
		[TestCase(2, -1, ExpectedResult = 0)]
		[TestCase(2, -1, ExpectedResult = 0)]
		public double GivenGardenAreaService_WhenGetGardenAreaIsCalledWithValidData_ThenAMetricAreaIsReturned(double length, double width)
        {
			_underTest = new GardenAreaService(_metricSurfaceCalculator.Object);
			return _underTest.GetGardenArea(length,width).SurfaceArea;
        }

		[TestCase(0, 2, ExpectedResult = 0)]
		[TestCase(3, 0, ExpectedResult = 0)]
		[TestCase(2, 4, ExpectedResult = 86.111199999999997)]
		[TestCase(-1, 4, ExpectedResult = 0)]
		[TestCase(2, -1, ExpectedResult = 0)]
		public double GivenGardenAreaService_WhenGetGardenAreaIsCalledWithValidData_ThenAnImperialAreaIsReturned(double length, double width)
		{
			_underTest = new GardenAreaService(_imperialSurfaceCalculator.Object);
			return _underTest.GetGardenArea(length, width).SurfaceArea;
		}


	}
}